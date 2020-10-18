using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorawanCollisionsSimulator
{
    struct GatewayTransmissionLog
    {
        /// <summary>
        /// Номер канала, на котором БС отвечает конечному устройству в первом приемном окне
        /// </summary>
        public uint Rx1Channel;
        public uint Rx1StartTimeMs;
        public uint Rx1EndTimeMs;

        public const uint Rx2Channel = 0;
        public uint Rx2StartTimeMs;
        public uint Rx2EndTimeMs;
    }

	/// <summary>
	/// Имитирует работу БС
	/// В случае отправки подтверждений задействуется 2 приемных окна
	/// </summary>
	class Gateway
	{
        private const uint GATEWAY_DOWNLINK_PACKET_SIZE_BYTES = 13;

        public Gateway()
		{
			_gatewayTransmissionLog = new List<GatewayTransmissionLog>();
		}

        public List<GatewayTransmissionLog> GetGatewayTransmissionLog()
        {
            return _gatewayTransmissionLog;
        }

        /// <summary>
        /// Возвращает количество принятых БС пакетов
        /// </summary>
        /// <returns></returns>
        public uint GetPacketsThatNotInEndNodeCollisions(IEndNode[] endNodes)
        {
            uint packetsCount = 0;
            for (uint i = 0; i < endNodes.Length; i++)
            {
                var endNode = endNodes[i];
                var endNodeTransmissionLog = endNode.GetTransmissionLog();
                for (uint j = 0; j < endNodeTransmissionLog.Length; j++)
                {
                    if (!endNodeTransmissionLog[j].IsPacketCollisionsWithOtherEndNodes)
                    {
                        packetsCount++;
                    }
                }
            }

            return packetsCount;
        }

        /// <summary>
        /// Возвращает следующую сессию передачи конечного устройства.
        /// Пропускаются пакеты, которые попали во взаимную коллизию 
        /// с другими конечными устройствами и те, которые не будут услышаны БС,
        /// из-за того, что БС занята передачей downlink-пакетов.
        /// </summary>
        /// <param name="startTime">Дата начала поиска</param>
        /// <returns></returns>
        public static EndNodeTransmissionLog GetNextReceivedPacket(IEndNode[] endNodes,
            uint startTime)
        {
            var minimumTransmissionLog = new EndNodeTransmissionLog();
            minimumTransmissionLog.StartMs = uint.MaxValue;
            for (uint i = 0; i < endNodes.Length; i++)
            {
                var endNode = endNodes[i];
                var endNodeTransmissionLog = endNode.GetTransmissionLog();
                for (uint j = 0; j < endNodeTransmissionLog.Length; j++)
                {
                    if (!endNodeTransmissionLog[j].IsPacketCollisionsWithOtherEndNodes)
                    {
                        // Этот пакет не попал в коллизию с остальными
                        var currentTransmissionLog = endNodeTransmissionLog[j];
                        if (currentTransmissionLog.IsPacketCanBeListenByGateway &&
                            currentTransmissionLog.StartMs >= startTime)
                        {
                            // Этот пакет был отправлен позже даты поиска,
                            // ищем наименьший по дате пакет среди тех,
                            // которые не были проигнорированы БС
                            if (currentTransmissionLog.StartMs < minimumTransmissionLog.StartMs)
                            {
                                minimumTransmissionLog = currentTransmissionLog;
                            }
                        }
                    }
                }
            }

            return minimumTransmissionLog;
        }

        private bool IsUnreceivedPacketsExist(IEndNode[] endNodes, uint startTime)
        {
            var transmissionLog = Gateway.GetNextReceivedPacket(endNodes, startTime);
            return transmissionLog.StartMs != uint.MaxValue;
        }

        public void CalculateGatewayTx(IEndNode[] endNodes)
		{
			if (Settings.IsConfirmed)
			{
                // Нужно найти самый ранний пакет от конечного устройства.
                // Прием uplink-пакета базовой станцией инициирует 
                // отправку двух подтверждений (downlink-пакетов):
                // Первый пакет будет передан на скорости передачи пакета,
                // второй пакет всегда будет передан по 1-му каналу на 
                // фиксированной скорости DR_0
                uint gatewayTransmitStartTimeMs = 0;
                uint safetyCounter = 0;
                while(IsUnreceivedPacketsExist(endNodes, gatewayTransmitStartTimeMs))
                {
                    safetyCounter++;
                    if (safetyCounter > Settings.PacketsPerHour * Settings.EndNodesCount)
                    {
                        Console.WriteLine("CRITICAL ERROR safetyCounter={0}",
                            safetyCounter);
                        break;
                    }

                    var transmissionLog = GetNextReceivedPacket(
                        endNodes, gatewayTransmitStartTimeMs);

                    AddGatewayTransmission(transmissionLog);

                    MarkPacketsThatNotBeListenByGateway(endNodes);

                    // Теперь поиск следует начинать с даты завершения
                    // передачи пакета
                    gatewayTransmitStartTimeMs =
                        transmissionLog.EndMs;
                }
			}
			else
			{
				// В режиме приема без подтверждения БС не может
				// "пропустить" пакет, т.к. всегда находится в режиме прослушивания
			}
		}

        private void AddGatewayTransmission(EndNodeTransmissionLog endNodeTransmission)
        {
            var gatewayTransmissionLog = new GatewayTransmissionLog();

            // Передача в RX1
            gatewayTransmissionLog.Rx1Channel = endNodeTransmission.ChannelNumber;
            gatewayTransmissionLog.Rx1StartTimeMs =
                endNodeTransmission.EndMs +
                Settings.Rx1PeriodS * 1000;
            gatewayTransmissionLog.Rx1EndTimeMs =
                gatewayTransmissionLog.Rx1StartTimeMs +
                GetRx1DownlinkTimeMs();

            // Передача в RX2
            gatewayTransmissionLog.Rx2StartTimeMs =
                endNodeTransmission.EndMs +
                Settings.Rx2PeriodS * 1000;
            gatewayTransmissionLog.Rx2EndTimeMs =
                gatewayTransmissionLog.Rx2StartTimeMs +
                GetRx2DownlinkTimeMs();

            _gatewayTransmissionLog.Add(gatewayTransmissionLog);
        }

        /// <summary>
        /// Помечает пакеты, которые были пропущены GW из-за
        /// того, чтоб в это время выполнялась переда downlink-пакета
        /// самими GW
        /// </summary>
        /// <param name="endNodes"></param>
        private void MarkPacketsThatNotBeListenByGateway(IEndNode[] endNodes)
        {
            foreach (var gateweayTransmissionLog in _gatewayTransmissionLog)
            {
                for (uint i = 0; i < endNodes.Length; i++)
                {
                    var endNode = endNodes[i];
                    var endNodeTransmissionLog = endNode.GetTransmissionLog();
                    for (uint j = 0; j < endNodeTransmissionLog.Length; j++)
                    {
                        bool isRx1Collision =
                            ((gateweayTransmissionLog.Rx1StartTimeMs >=
                            endNodeTransmissionLog[j].StartMs) &&
                            (gateweayTransmissionLog.Rx1StartTimeMs <=
                            endNodeTransmissionLog[j].EndMs));

                        bool isRx2Collision =
                            ((gateweayTransmissionLog.Rx2StartTimeMs >=
                            endNodeTransmissionLog[j].StartMs) &&
                            (gateweayTransmissionLog.Rx2StartTimeMs <=
                            endNodeTransmissionLog[j].EndMs));

                        if (isRx1Collision || isRx2Collision)
                        {
                            endNodeTransmissionLog[j].IsPacketCanBeListenByGateway = false;
                        }
                    }
                }
            }
        }

        private uint GetRx1DownlinkTimeMs()
        {
            return GATEWAY_DOWNLINK_PACKET_SIZE_BYTES *
                Settings.OneByteTransmitTimeUs / 1000;
        }

        private uint GetRx2DownlinkTimeMs()
        {
            uint maxOneByteTransmitTimeUs = EndNode.GetByteTimeUsBySf(Settings.SF_MAX);
            return GATEWAY_DOWNLINK_PACKET_SIZE_BYTES *
                maxOneByteTransmitTimeUs / 1000;
        }

        private List<GatewayTransmissionLog> _gatewayTransmissionLog;
	}
}

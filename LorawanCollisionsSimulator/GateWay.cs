﻿using System;
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
		public Gateway()
		{
			_gateweayTransmissionLog = new List<GatewayTransmissionLog>();
		}

        private const uint GATEWAY_DOWNLINK_PACKET_SIZE_BYTES = 13;

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

        /// <summary>
        /// Возвращает количество принятый на БС пакетов
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
        public static TransmissionLog GetNextReceivedPacket(IEndNode[] endNodes,
            uint startTime)
        {
            var minimumTransmissionLog = new TransmissionLog();
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

            Console.WriteLine("minimumTransmissionLog.StartMs={0}",
                minimumTransmissionLog.StartMs);
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
                // #TODO Рассчитать время передачи исходя из знания о том,
                // что некоторые пакеты от конечных устройств будут пропущены,
                // пока БС занята передачей

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

                    // Теперь поиск следует начинать с даты завершения отправки
                    // downlink-пакета в RX1
                    gatewayTransmitStartTimeMs = 
                        _gateweayTransmissionLog.Last<GatewayTransmissionLog>().Rx1EndTimeMs;
                }
			}
			else
			{
				// В режиме приема без подтверждения БС не может
				// "пропустить" пакет, т.к. всегда находится в режиме прослушивания
			}
		}

        public List<GatewayTransmissionLog> GetGateweayTransmissionLog()
        {
            return _gateweayTransmissionLog;
        }

        private void AddGatewayTransmission(TransmissionLog endNodeTransmission)
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

            _gateweayTransmissionLog.Add(gatewayTransmissionLog);
        }

        /// <summary>
        /// Помечает пакеты, которые были пропущены GW из-за
        /// того, чтоб в это время выполнялась переда downlink-пакета
        /// </summary>
        /// <param name="endNodes"></param>
        private void MarkPacketsThatNotBeListenByGateway(IEndNode[] endNodes)
        {
            foreach (var gateweayTransmissionLog in _gateweayTransmissionLog)
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

		private List<GatewayTransmissionLog> _gateweayTransmissionLog;
	}
}

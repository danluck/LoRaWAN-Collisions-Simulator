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
        uint Rx1Channel;
        uint Rx1StartTimeMs;
        uint Rx1EndTimeMs;

        uint Rx2Channel;
        uint Rx2StartTimeMs;
        uint Rx2EndTimeMs;
    }

	/// <summary>
	/// Имитирует работу БС
	/// В случае отправки подтверждений задействуется 2 приемных окна
	/// </summary>
	class Gateway
	{
		public Gateway()
		{
			_transmissionLog = new List<GatewayTransmissionLog>();
		}

        private const uint GATEWAY_DOWNLINK_PACKET_SIZE_BYTES = 13;

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

        public List<GatewayTransmissionLog> GetGatewayTx(IEndNode[] endNodes)
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
                }
				
				return _transmissionLog;
			}
			else
			{
				// В режиме приема без подтверждения БС не может
				// "пропустить" пакет, т.к. всегда находится в режиме прослушивания
				return _transmissionLog;
			}
		}

		private List<GatewayTransmissionLog> _transmissionLog;
	}
}

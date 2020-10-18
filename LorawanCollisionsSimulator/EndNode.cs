using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorawanCollisionsSimulator
{
	class EndNode : IEndNode
	{
		public EndNode()
		{
			CalculateTransmitTime();
		}

		public TransmissionLog[] GetTransmissionLog()
		{
			return _transmissionLogs;
		}

		public uint GetOnePacketTransmitTimeMs()
		{
			return (Settings.PacketSizeBytes * Settings.OneByteTransmitTimeUs) /
				1000;
		}

		public void CalculateTransmitTime()
		{
			_transmissionLogs = new TransmissionLog[Settings.PacketsPerHour];

			const uint MS_IN_HOUR = 60 * 60 * 1000;
			uint transmitPeriodMs = MS_IN_HOUR / Settings.PacketsPerHour;
			Console.WriteLine("transmitPeriodMs={0}", transmitPeriodMs);
			Console.WriteLine("GetOnePacketTransmitTimeMs()={0}", 
				GetOnePacketTransmitTimeMs());

			uint slotTimeMs = 0;
			for (uint i = 0; i < Settings.PacketsPerHour; i++)
			{
				_transmissionLogs[i].StartMs = slotTimeMs;
				_transmissionLogs[i].EndMs = slotTimeMs + GetOnePacketTransmitTimeMs();
				_transmissionLogs[i].ChannelNumber = GetRandomChannelNumber();
				_transmissionLogs[i].IsPacketCanBeListenByGateway = true;

				slotTimeMs += transmitPeriodMs;
			}
		}

		private uint GetRandomChannelNumber()
		{
			var random = RandomAccessPoint.GetRandomObject();
			return (uint)random.Next((int)Settings.ChannelsCount);
		}

		private TransmissionLog[] _transmissionLogs;
	}
}

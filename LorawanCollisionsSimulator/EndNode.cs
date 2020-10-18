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

        public static uint GetByteTimeUsBySf(uint sf)
		{
			if (sf < Settings.SF_MIN)
				sf = Settings.SF_MIN;
			if (sf > Settings.SF_MAX)
				sf = Settings.SF_MAX;

			switch(sf)
			{
				case 7:
					return 2313;
				case 8:
					return 4215;
				case 9:
					return 7647;
				case 10:
					return 13686;
				case 11:
					return 30588;
				case 12:
					return 57764;
				default:
					return 57764;
			}
		}

		public static uint GetOnePacketTransmitTimeMs()
		{
			return (Settings.PacketSizeBytes * Settings.OneByteTransmitTimeUs) /
				1000;
		}

		public void CalculateTransmitTime()
		{
			_transmissionLogs = new TransmissionLog[Settings.PacketsPerHour];

			const uint MS_IN_HOUR = 60 * 60 * 1000;
			uint transmitPeriodMs = MS_IN_HOUR / Settings.PacketsPerHour;
			//Console.WriteLine("transmitPeriodMs={0}", transmitPeriodMs);
			//Console.WriteLine("GetOnePacketTransmitTimeMs()={0}", 
			//	GetOnePacketTransmitTimeMs());

			uint slotTimeMs = 0;
			for (uint i = 0; i < Settings.PacketsPerHour; i++)
			{
				var random = RandomAccessPoint.GetRandomObject();
				uint randomWait = (uint)random.Next((int)transmitPeriodMs);
				_transmissionLogs[i].StartMs = slotTimeMs + randomWait;
				_transmissionLogs[i].EndMs = _transmissionLogs[i].StartMs + 
					GetOnePacketTransmitTimeMs();
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

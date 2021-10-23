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

		public EndNodeTransmissionLog[] GetTransmissionLog()
		{
			return _transmissionLogs;
		}

        public static uint GetByteTimeUsBySf(uint sf)
		{
			// Source:
			// Lora modem calculator tool
			// https://avbentem.github.io/airtime-calculator/ttn/eu868/0
			if (sf < Settings.SF_MIN)
				sf = Settings.SF_MIN;
			if (sf > Settings.SF_MAX)
				sf = Settings.SF_MAX;

			switch(sf)
			{
				case 7:
					return 1440; // 1020 - original
				case 8:
					return 2050;
				case 9:
					return 4100;
				case 10:
					return 8190;
				case 11:
					return 16380;
				case 12:
					return 32770;
				default:
					return 32770;
			}
		}

		public static uint GetOnePacketTransmitTimeMs()
		{
			return ((Settings.PacketHeaderSizeBytes + Settings.PacketPayloadSizeBytes) * 
				Settings.OneByteTransmitTimeUs) / 1000;
		}

		public void CalculateTransmitTime()
		{
			_transmissionLogs = new EndNodeTransmissionLog[
                Settings.GetPacketsCountFromOneNode()];

			uint transmitPeriodMs = Settings.MS_IN_HOUR / Settings.PacketsPerHour;

			uint slotTimeMs = 0;
			for (uint i = 0; i < Settings.GetPacketsCountFromOneNode(); i++)
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

		private EndNodeTransmissionLog[] _transmissionLogs;
	}
}

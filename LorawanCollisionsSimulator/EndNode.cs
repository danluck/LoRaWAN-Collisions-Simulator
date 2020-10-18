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

		public TimeTx[] GetTransmitTimes()
		{
			return _transmitTimes;
		}

		public uint GetOnePacketTransmitTimeMs()
		{
			return (Settings.PacketSizeBytes * Settings.OneByteTransmitTimeUs) /
				1000;
		}

		public void CalculateTransmitTime()
		{
			_transmitTimes = new TimeTx[Settings.PacketsPerHour];

			const uint MS_IN_HOUR = 60 * 60 * 1000;
			uint transmitPeriodMs = MS_IN_HOUR / Settings.PacketsPerHour;
			Console.WriteLine("transmitPeriodMs={0}", transmitPeriodMs);
			Console.WriteLine("GetOnePacketTransmitTimeMs()={0}", 
				GetOnePacketTransmitTimeMs());

			uint slotTimeMs = 0;
			for (uint i = 0; i < Settings.PacketsPerHour; i++)
			{
				_transmitTimes[i].StartMs = slotTimeMs;
				_transmitTimes[i].EndMs = slotTimeMs + GetOnePacketTransmitTimeMs();

				slotTimeMs += transmitPeriodMs;
			}
		}

		private TimeTx[] _transmitTimes;
	}
}

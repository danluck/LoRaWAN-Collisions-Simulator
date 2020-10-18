using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorawanCollisionsSimulator
{
	static class Settings
	{
		public static uint Rx1PeriodS = 3;
		public static uint Rx2PeriodS = Rx1PeriodS + 1;

		public static bool IsConfirmed = true;

		public static uint EndNodesCount;

		public static uint SimulateLengthMs = 60 * 60 * 1000;

		public static uint ChannelsCount = 7;

		public static uint PacketsPerHour = 10;

		public static uint PacketSizeBytes = 10;

		/// <summary>
		/// Длительность передачи одного байта, с
		/// </summary>
		public static uint OneByteTransmitTimeUs = 58000;
	}
}

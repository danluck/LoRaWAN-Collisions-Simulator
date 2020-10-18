using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorawanCollisionsSimulator
{
	static class Settings
	{
		public static uint Rx1PeriodS;

		public static uint EndNodesCount;

		public static uint SimulateLengthMs = 60 * 60 * 1000;

		public static uint ChannelsCount = 7;
	}
}

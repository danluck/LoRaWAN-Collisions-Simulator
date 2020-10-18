using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorawanCollisionsSimulator
{
	struct TimeTx
	{
		public uint StartMs;
		public uint EndMs;
	}

	interface IEndNode
	{
		TimeTx[] GetTransmitTimes();

		uint GetOnePacketTransmitTimeMs();
	}
}

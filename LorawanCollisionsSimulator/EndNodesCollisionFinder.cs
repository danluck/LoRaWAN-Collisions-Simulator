using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorawanCollisionsSimulator
{
	static class EndNodesCollisionFinder
	{
		public static void DoCollisionFind(IEndNode[] endNodes)
		{
			for (uint endNodeIndex = 0; endNodeIndex < endNodes.Length; endNodeIndex++)
			{
				for (uint k = 0; k < endNodes.Length; k++)
				{
					if (k == endNodeIndex)
						break;

					var transmissionLogInitial = endNodes[endNodeIndex].GetTransmissionLog();
					for (uint j = 0; j < transmissionLogInitial.Length; j++)
					{
						var transmissionLogSecond = endNodes[k].GetTransmissionLog();
						for (uint m = 0; m < transmissionLogSecond.Length; m++)
						{
							if ((transmissionLogInitial[j].StartMs >= 
								transmissionLogSecond[m].StartMs) &&
								(transmissionLogInitial[j].StartMs <= 
								transmissionLogSecond[m].EndMs) &&
								(transmissionLogInitial[j].ChannelNumber ==
								transmissionLogSecond[m].ChannelNumber))
							{
								transmissionLogInitial[j].IsPacketCollisionsWithOtherEndNodes = true;
								transmissionLogSecond[m].IsPacketCollisionsWithOtherEndNodes = true;

// 								Console.WriteLine("endNodeIndex=[{0}][n={1}], k=[{2}][n={3}]", 
// 									endNodeIndex, j, k, m);
							}
						}
					}
				}
			}
		}
	}
}

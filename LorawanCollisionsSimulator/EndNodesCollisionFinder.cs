﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorawanCollisionsSimulator
{
	static class EndNodesCollisionFinder
	{
		public static void DoCollisionFind(IEndNode[] endNodes, 
			System.Windows.Forms.ProgressBar progressBar)
		{
			progressBar.Value = 0;
			progressBar.Maximum = endNodes.Length - 1;

			for (uint endNodeIndex = 0; endNodeIndex < endNodes.Length; endNodeIndex++)
			{
				progressBar.Value = (int)endNodeIndex;
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
							}
						}
					}
				}
			}
		}
	}
}

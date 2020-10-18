using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LorawanCollisionsSimulator
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

            Console.WindowHeight = Console.LargestWindowHeight - 10;
			Console.WindowWidth = Console.LargestWindowWidth - 10;
           
            numericUpDownSf.Minimum = Settings.SF_MIN;
			numericUpDownSf.Maximum = Settings.SF_MAX;
			numericUpDownSf.Value = Settings.SF_DEFAULT;

			numericUpDownEndNodesCount.Value = Settings.EndNodesCount;
			checkBoxIsConfirmed.Checked = Settings.IsConfirmed;
			numericUpDownPacketsPerHour.Value = Settings.PacketsPerHour;
			numericUpDownPacketSize.Value = Settings.PacketSizeBytes;

			ShowCalculatedParameters();
		}

		private void ShowOnePacketLengthMs()
		{
			labelOnePacketLengthMs.Text = 
				EndNode.GetOnePacketTransmitTimeMs().ToString();
		}

		private void ShowAirTime()
		{
			float hoursTimeMs = 60 * 60 * 1000;
			float endNodeTransmitTimeMs = EndNode.GetOnePacketTransmitTimeMs() *
				Settings.PacketsPerHour;
			labelAirTimePercents.Text = (endNodeTransmitTimeMs * 100 / hoursTimeMs).ToString();
		}

		private void ShowCalculatedParameters()
		{
			ShowOnePacketLengthMs();
			ShowAirTime();
		}

		private void ReadPacketsPerHour()
		{
			Settings.PacketsPerHour = (uint)numericUpDownPacketsPerHour.Value;
		}

		private void ReadPacketSize()
		{
			Settings.PacketSizeBytes = (uint)numericUpDownPacketSize.Value;
		}

		private void ReadSf()
		{
			Settings.OneByteTransmitTimeUs = 
				EndNode.GetByteTimeUsBySf(
					(uint)numericUpDownSf.Value);
		}

		private void ReadEndNodesCount()
		{
			Settings.EndNodesCount = (uint)numericUpDownEndNodesCount.Value;
		}

		private void ReadParametersFromForm()
		{
			// Чтение параметров с формы в настройки
			ReadEndNodesCount();
			Settings.IsConfirmed = checkBoxIsConfirmed.Checked;
			ReadPacketSize();
			ReadPacketsPerHour();
			ReadSf();

			Console.WriteLine("Settings.EndNodesCount={0}", Settings.EndNodesCount);
			Console.WriteLine("Settings.PacketsPerHour={0}", Settings.PacketsPerHour);
			Console.WriteLine("Settings.IsConfirmed={0}", Settings.IsConfirmed);
			Console.WriteLine("Settings.PacketsPerHour={0}", Settings.PacketsPerHour);
			Console.WriteLine("Settings.PacketSizeBytes={0}", Settings.PacketSizeBytes);
			Console.WriteLine("Settings.OneByteTransmitTimeUs={0}", Settings.OneByteTransmitTimeUs);

			ShowOnePacketLengthMs();
		}

		private void buttonDoEmulation_Click(object sender, EventArgs e)
		{
			Console.WriteLine("####################################");
			ReadParametersFromForm();

			CreateEndNodes();
			EndNodesCollisionFinder.DoCollisionFind(_endNodes);
			ShowEndNodesTransmitTimes();

			CreateGateway();
            _gateway.CalculateGatewayTx(_endNodes);
			ShowGatewayTxTime();
            ShowPacketsThatWasSkippedByGateway();
            ShowSuccessfullyReceivedPackets();

            // Количество пакетов, которое могло бы быть принято, если бы БС могла
            // слушать эфир во время передачи
            uint theoreticalPacketsReceived = 
                _gateway.GetPacketsThatNotInEndNodeCollisions(_endNodes);
            Console.WriteLine("theoretical packetsReceived={0}", 
                theoreticalPacketsReceived);
        }

        private void ShowPacketsThatWasSkippedByGateway()
        {
            uint skippedPacketsCount = 0;
            for (uint i = 0; i < _endNodes.Length; i++)
            {
                var endNode = _endNodes[i];
                var endNodeTransmissionLog = endNode.GetTransmissionLog();
                for (uint j = 0; j < endNodeTransmissionLog.Length; j++)
                {
                    if (!endNodeTransmissionLog[j].IsPacketCollisionsWithOtherEndNodes &&
                        !endNodeTransmissionLog[j].IsPacketCanBeListenByGateway)
                    {
                        skippedPacketsCount++;
                    }
                }
            }

            labelGatewaySkippedPackets.Text = skippedPacketsCount.ToString();
        }

		private void CreateEndNodes()
		{
			_endNodes = new EndNode[Settings.EndNodesCount];
			for (uint i = 0; i < _endNodes.Length; i++)
			{
				_endNodes[i] = new EndNode();
			}
		}

		private void ShowEndNodesTransmitTimes()
		{
			uint totalCollisionsCount = 0;
			bool isFullTrace = false;
			for (uint i = 0; i < _endNodes.Length; i++)
			{
				if (isFullTrace)
				{
					Console.WriteLine("Node {0}", i);
				}
				
				var transmitTimes = _endNodes[i].GetTransmissionLog();
				for (uint j = 0; j < transmitTimes.Length; j++)
				{
					if (isFullTrace)
					{
						Console.WriteLine("[{0}][ch={1}]\t[{2}..{3}]\t[gw={4}][c={5}]",
						j,
						transmitTimes[j].ChannelNumber,
						transmitTimes[j].StartMs,
						transmitTimes[j].EndMs,
						transmitTimes[j].IsPacketCanBeListenByGateway ? 1 : 0,
						transmitTimes[j].IsPacketCollisionsWithOtherEndNodes ? 1 : 0);
					}

					if (transmitTimes[j].IsPacketCollisionsWithOtherEndNodes)
					{
						totalCollisionsCount++;
					}
				}
			}
            uint totalPacketsCount = Settings.GetTotalPacketsCount();
            float collsionsPercents = (float)totalCollisionsCount * 100.0f / 
				(float)totalPacketsCount;
			Console.WriteLine("totalCollisionsCount={0}, totalPacketsCount={1}",
				totalCollisionsCount,
				totalPacketsCount);
			Console.WriteLine("collsionsPercents={0}",
				collsionsPercents);

			labelEndNodeInitiatedCollisions.Text = 
				collsionsPercents.ToString();
		}

		private void CreateGateway()
		{
			_gateway = new Gateway();
		}
		private void ShowGatewayTxTime()
		{
			var gatewayTransmissionLog = _gateway.GetGateweayTransmissionLog();
			Console.WriteLine("gatewayTransmissionLog.Count={0}",
				gatewayTransmissionLog.Count);
		}

        private void ShowSuccessfullyReceivedPackets()
        {
            uint successPackets = 0;

            for (uint i = 0; i < _endNodes.Length; i++)
            {
                var endNode = _endNodes[i];
                var endNodeTransmissionLog = endNode.GetTransmissionLog();
                for (uint j = 0; j < endNodeTransmissionLog.Length; j++)
                {
                    if (!endNodeTransmissionLog[j].IsPacketCollisionsWithOtherEndNodes &&
                        endNodeTransmissionLog[j].IsPacketCanBeListenByGateway)
                    {
                        successPackets++;
                    }
                }
            }

            Console.WriteLine("successPackets={0}", successPackets);
            labelSuccessfullyReceivedPackets.Text = successPackets.ToString();

            float totalPackets = Settings.GetTotalPacketsCount();
            float successPercent = (float)successPackets * 100.0f / totalPackets;
            labelSuccessPacketsPercents.Text = successPercent.ToString();

        }

		private IEndNode[] _endNodes;
		private Gateway _gateway;

		private void numericUpDownPacketsPerHour_ValueChanged(object sender, EventArgs e)
		{
			ReadPacketsPerHour();
			ShowCalculatedParameters();
		}

		private void numericUpDownPacketSize_ValueChanged(object sender, EventArgs e)
		{
			ReadPacketSize();
			ShowCalculatedParameters();
		}

		private void numericUpDownSf_ValueChanged(object sender, EventArgs e)
		{
			ReadSf();
			ShowCalculatedParameters();
		}

		private void numericUpDownEndNodesCount_ValueChanged(object sender, EventArgs e)
		{
			ReadEndNodesCount();
			ShowCalculatedParameters();
		}

        private void checkBoxIsConfirmed_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}

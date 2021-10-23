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

            numericUpDownSf.Minimum = Settings.SF_MIN;
			numericUpDownSf.Maximum = Settings.SF_MAX;
			numericUpDownSf.Value = Settings.SF_DEFAULT;

			numericUpDownEndNodesCount.Value = Settings.EndNodesCount;
			checkBoxIsConfirmed.Checked = Settings.IsConfirmed;
			numericUpDownPacketsPerHour.Value = Settings.PacketsPerHour;
			numericUpDownChannelsCount.Value = Settings.ChannelsCount;
			numericUpDownPacketSize.Value = Settings.PacketSizeBytes;

            numericUpDownRx1.Value = Settings.Rx1PeriodS;

            checkBoxGwRx1Enabled.Checked = Settings.IsRx1GatewayEnabled;
            checkBoxGwRx1Enabled.Enabled = checkBoxIsConfirmed.Checked;
            checkBoxGwRx2Enabled.Enabled = checkBoxIsConfirmed.Checked;

            ShowCalculatedParameters();
		}

		private void CreateEndNodes()
		{
			_endNodes = new EndNode[Settings.EndNodesCount];
			for (uint i = 0; i < _endNodes.Length; i++)
			{
				_endNodes[i] = new EndNode();
			}
		}

		private void CreateGateway()
		{
			_gateway = new Gateway();
		}

        #region PrintToForm

        private void ShowGatewayTxTime()
        {
            var gatewayTransmissionLog = _gateway.GetGatewayTransmissionLog();
            Console.WriteLine("gatewayTransmissionLog.Count={0}",
                gatewayTransmissionLog.Count);
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

        private void ShowGatewayAirTime()
        {
            uint transmitTimeMs = 0;
            var gatewayTransmissionLog = _gateway.GetGatewayTransmissionLog();
            foreach(var gw in gatewayTransmissionLog)
            {
                var rx1TimeMs = gw.Rx1EndTimeMs - gw.Rx1StartTimeMs;
                var rx2TimeMs = gw.Rx2EndTimeMs - gw.Rx2StartTimeMs;

                transmitTimeMs += (rx1TimeMs + rx2TimeMs);
            }

            float gatewayAirTimePercents = (float)transmitTimeMs * 100.0f / 
                (float)Settings.SimulateLengthMs;
            labelGatewayAirTime.Text = gatewayAirTimePercents.ToString();
        }

        private void ShowOnePacketLengthMs()
        {
            labelOnePacketLengthMs.Text =
                EndNode.GetOnePacketTransmitTimeMs().ToString();
        }

        private void ShowAirTime()
        {
            float endNodeTransmitTimeMs = EndNode.GetOnePacketTransmitTimeMs() *
                Settings.PacketsPerHour;
            labelAirTimePercents.Text = (endNodeTransmitTimeMs * 100 / 
                Settings.SimulateLengthMs).ToString();
        }

        private void ShowCalculatedParameters()
        {
            ShowOnePacketLengthMs();
            ShowAirTime();
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

        #endregion

        #region ReadFromForm

        private void ReadPacketsPerHour()
        {
            Settings.PacketsPerHour = (uint)numericUpDownPacketsPerHour.Value;
        }

		private void ReadChannelsCount()
		{
			Settings.ChannelsCount = (uint)numericUpDownChannelsCount.Value;
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

        private void ReadRx1()
        {
            Settings.Rx1PeriodS = (uint)numericUpDownRx1.Value;
            Settings.Rx2PeriodS = Settings.Rx1PeriodS + 1;
        }

        private void ReadSimulateHours()
        {
            Settings.SimulateLengthMs = 
                (uint)numericUpDownSimulateHours.Value * Settings.MS_IN_HOUR;
        }

        private void ReadParametersFromForm()
        {
            // Чтение параметров с формы в настройки
            ReadEndNodesCount();
            Settings.IsConfirmed = checkBoxIsConfirmed.Checked;
            ReadPacketSize();
            ReadPacketsPerHour();
			ReadChannelsCount();
            ReadSf();
            ReadRx1();
            ReadSimulateHours();
            ReadGatewayRx1Enabled();
            ReadGatewayRx2Enabled();

            Console.WriteLine("Settings.EndNodesCount={0}", Settings.EndNodesCount);
            Console.WriteLine("Settings.PacketsPerHour={0}", Settings.PacketsPerHour);
            Console.WriteLine("Settings.IsConfirmed={0}", Settings.IsConfirmed);
            Console.WriteLine("Settings.PacketsPerHour={0}", Settings.PacketsPerHour);
            Console.WriteLine("Settings.PacketSizeBytes={0}", Settings.PacketSizeBytes);
            Console.WriteLine("Settings.OneByteTransmitTimeUs={0}", Settings.OneByteTransmitTimeUs);
            Console.WriteLine("Settings.Rx1PeriodS={0}", Settings.Rx1PeriodS);
            Console.WriteLine("Settings.SimulateLengthMs={0}", Settings.SimulateLengthMs);
            Console.WriteLine("Settings.IsRx1GatewayEnabled={0}", Settings.IsRx1GatewayEnabled);
            Console.WriteLine("Settings.IsRx2GatewayEnabled={0}", Settings.IsRx2GatewayEnabled);

            ShowOnePacketLengthMs();
        }

        private void ReadGatewayRx1Enabled()
        {
            Settings.IsRx1GatewayEnabled = checkBoxGwRx1Enabled.Checked;
        }

        private void ReadGatewayRx2Enabled()
        {
            Settings.IsRx2GatewayEnabled = checkBoxGwRx2Enabled.Checked;
        }

        #endregion

        #region EventHandlers

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
            ShowGatewayAirTime();
        }

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
            checkBoxGwRx1Enabled.Enabled = checkBoxIsConfirmed.Checked;
            checkBoxGwRx2Enabled.Enabled = checkBoxIsConfirmed.Checked;
        }

        private void checkBoxGwRx1Enabled_CheckedChanged(object sender, EventArgs e)
        {
            ReadGatewayRx1Enabled();
        }

        private void checkBoxGwRx2Enabled_CheckedChanged(object sender, EventArgs e)
        {
            ReadGatewayRx2Enabled();
        }

        #endregion

        private IEndNode[] _endNodes;
        private Gateway _gateway;
	}
}

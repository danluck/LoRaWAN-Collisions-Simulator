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

			Console.WindowHeight = 60;
			Console.WindowWidth = 200;

			checkBoxIsConfirmed.Checked = Settings.IsConfirmed;
			numericUpDownPacketsPerHour.Value = Settings.PacketsPerHour;
			numericUpDownPacketSize.Value = Settings.PacketSizeBytes;

			ShowOnePacketLengthMs();
		}

		private void ShowOnePacketLengthMs()
		{
			labelOnePacketLengthMs.Text = 
				EndNode.GetOnePacketTransmitTimeMs().ToString();
		}

		private void ReadPacketsPerHour()
		{
			Settings.PacketsPerHour = (uint)numericUpDownPacketsPerHour.Value;
		}

		private void ReadPacketSize()
		{
			Settings.PacketSizeBytes = (uint)numericUpDownPacketSize.Value;
		}

		private void ReadParametersFromForm()
		{
			// Чтение параметров с формы в настройки
			Settings.EndNodesCount = (uint)numericUpDownEndNodesCount.Value;
			Settings.IsConfirmed = checkBoxIsConfirmed.Checked;
			ReadPacketSize();
			ReadPacketsPerHour();

			Console.WriteLine("Settings.EndNodesCount={0}", Settings.EndNodesCount);
			Console.WriteLine("Settings.PacketsPerHour={0}", Settings.PacketsPerHour);
			Console.WriteLine("Settings.IsConfirmed={0}", Settings.IsConfirmed);
			Console.WriteLine("Settings.PacketsPerHour={0}", Settings.PacketsPerHour);
			Console.WriteLine("Settings.PacketSizeBytes={0}", Settings.PacketSizeBytes);

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
			ShowGatewayTxTime();
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
			for (uint i = 0; i < _endNodes.Length; i++)
			{
				Console.WriteLine("Node {0}", i);
				var transmitTimes = _endNodes[i].GetTransmissionLog();
				for (uint j = 0; j < transmitTimes.Length; j++)
				{
					Console.WriteLine("[{0}][ch={1}][{2}..{3}][gw={4}][c={5}]",
						j,
						transmitTimes[j].ChannelNumber,
						transmitTimes[j].StartMs,
						transmitTimes[j].EndMs,
						transmitTimes[j].IsPacketCanBeListenByGateway,
						transmitTimes[j].IsPacketCollisionsWithOtherEndNodes);
					if (transmitTimes[j].IsPacketCollisionsWithOtherEndNodes)
					{
						totalCollisionsCount++;
					}
				}
			}
			Console.WriteLine("totalCollisionsCount={0}",
				totalCollisionsCount);
		}

		private void CreateGateway()
		{
			_gateway = new Gateway();
		}
		private void ShowGatewayTxTime()
		{
			var gatewayTransmissionLog = _gateway.GetGatewayTx(_endNodes);
			Console.WriteLine("gatewayTransmissionLog.Count={0}",
				gatewayTransmissionLog.Count);
		}

		private IEndNode[] _endNodes;
		private Gateway _gateway;

		private void numericUpDownPacketsPerHour_ValueChanged(object sender, EventArgs e)
		{
			ReadPacketsPerHour();
			ShowOnePacketLengthMs();
		}

		private void numericUpDownPacketSize_ValueChanged(object sender, EventArgs e)
		{
			ReadPacketSize();
			ShowOnePacketLengthMs();
		}
	}
}

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

			checkBoxIsConfirmed.Checked = Settings.IsConfirmed;
		}

		private void buttonDoEmulation_Click(object sender, EventArgs e)
		{
			// Чтение параметров с формы в настройки
			Settings.EndNodesCount = (uint)numericUpDownEndNodesCount.Value;
			Settings.IsConfirmed = checkBoxIsConfirmed.Checked;

			Console.WriteLine("Settings.EndNodesCount={0}", Settings.EndNodesCount);
			Console.WriteLine("Settings.PacketsPerHour={0}", Settings.PacketsPerHour);
			Console.WriteLine("Settings.IsConfirmed={0}", Settings.IsConfirmed);

			CreateEndNodes();
			ShowEndNodesTransmitTimes();
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
			for (uint i = 0; i < _endNodes.Length; i++)
			{
				Console.Write("Node {0}.", i);
				var transmitTimes = _endNodes[i].GetTransmitTimes();
				for (uint j = 0; j < transmitTimes.Length; j++)
				{
					Console.Write("[{0}..{1}] ", transmitTimes[j].StartMs,
						transmitTimes[j].EndMs);
				}
				Console.WriteLine("");
			}
		}

		private IEndNode[] _endNodes;
	}
}

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
		}

		private void buttonDoEmulation_Click(object sender, EventArgs e)
		{
			Settings.EndNodesCount = (uint)numericUpDownEndNodesCount.Value;

			Console.WriteLine("Settings.EndNodesCount={0}", Settings.EndNodesCount);
		}
	}
}

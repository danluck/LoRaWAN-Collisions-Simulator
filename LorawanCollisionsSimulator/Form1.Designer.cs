namespace LorawanCollisionsSimulator
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.labelEndNodesCount = new System.Windows.Forms.Label();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.buttonDoEmulation = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// labelEndNodesCount
			// 
			this.labelEndNodesCount.AutoSize = true;
			this.labelEndNodesCount.Location = new System.Drawing.Point(12, 9);
			this.labelEndNodesCount.Name = "labelEndNodesCount";
			this.labelEndNodesCount.Size = new System.Drawing.Size(94, 13);
			this.labelEndNodesCount.TabIndex = 0;
			this.labelEndNodesCount.Text = "End Nodes Count:";
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(314, 45);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(563, 142);
			this.chart1.TabIndex = 1;
			this.chart1.Text = "chart1";
			// 
			// buttonDoEmulation
			// 
			this.buttonDoEmulation.Location = new System.Drawing.Point(12, 25);
			this.buttonDoEmulation.Name = "buttonDoEmulation";
			this.buttonDoEmulation.Size = new System.Drawing.Size(75, 23);
			this.buttonDoEmulation.TabIndex = 2;
			this.buttonDoEmulation.Text = "DoEmulation";
			this.buttonDoEmulation.UseVisualStyleBackColor = true;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(121, 7);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(67, 20);
			this.numericUpDown1.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1083, 296);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.buttonDoEmulation);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.labelEndNodesCount);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelEndNodesCount;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Button buttonDoEmulation;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
	}
}


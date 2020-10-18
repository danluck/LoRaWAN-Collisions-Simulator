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
			this.labelEndNodesCount = new System.Windows.Forms.Label();
			this.buttonDoEmulation = new System.Windows.Forms.Button();
			this.numericUpDownEndNodesCount = new System.Windows.Forms.NumericUpDown();
			this.checkBoxIsConfirmed = new System.Windows.Forms.CheckBox();
			this.numericUpDownPacketsPerHour = new System.Windows.Forms.NumericUpDown();
			this.labelPacketsPerHourText = new System.Windows.Forms.Label();
			this.numericUpDownPacketSize = new System.Windows.Forms.NumericUpDown();
			this.labelPacketSizeText = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.labelOnePacketLengthMs = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndNodesCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketsPerHour)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).BeginInit();
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
			// buttonDoEmulation
			// 
			this.buttonDoEmulation.Location = new System.Drawing.Point(15, 148);
			this.buttonDoEmulation.Name = "buttonDoEmulation";
			this.buttonDoEmulation.Size = new System.Drawing.Size(75, 23);
			this.buttonDoEmulation.TabIndex = 2;
			this.buttonDoEmulation.Text = "DoEmulation";
			this.buttonDoEmulation.UseVisualStyleBackColor = true;
			this.buttonDoEmulation.Click += new System.EventHandler(this.buttonDoEmulation_Click);
			// 
			// numericUpDownEndNodesCount
			// 
			this.numericUpDownEndNodesCount.Location = new System.Drawing.Point(121, 7);
			this.numericUpDownEndNodesCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownEndNodesCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownEndNodesCount.Name = "numericUpDownEndNodesCount";
			this.numericUpDownEndNodesCount.Size = new System.Drawing.Size(67, 20);
			this.numericUpDownEndNodesCount.TabIndex = 3;
			this.numericUpDownEndNodesCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// checkBoxIsConfirmed
			// 
			this.checkBoxIsConfirmed.AutoSize = true;
			this.checkBoxIsConfirmed.Location = new System.Drawing.Point(15, 125);
			this.checkBoxIsConfirmed.Name = "checkBoxIsConfirmed";
			this.checkBoxIsConfirmed.Size = new System.Drawing.Size(121, 17);
			this.checkBoxIsConfirmed.TabIndex = 4;
			this.checkBoxIsConfirmed.Text = "IsConfirmedTransmit";
			this.checkBoxIsConfirmed.UseVisualStyleBackColor = true;
			// 
			// numericUpDownPacketsPerHour
			// 
			this.numericUpDownPacketsPerHour.Location = new System.Drawing.Point(121, 33);
			this.numericUpDownPacketsPerHour.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownPacketsPerHour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPacketsPerHour.Name = "numericUpDownPacketsPerHour";
			this.numericUpDownPacketsPerHour.Size = new System.Drawing.Size(67, 20);
			this.numericUpDownPacketsPerHour.TabIndex = 6;
			this.numericUpDownPacketsPerHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPacketsPerHour.ValueChanged += new System.EventHandler(this.numericUpDownPacketsPerHour_ValueChanged);
			// 
			// labelPacketsPerHourText
			// 
			this.labelPacketsPerHourText.AutoSize = true;
			this.labelPacketsPerHourText.Location = new System.Drawing.Point(12, 35);
			this.labelPacketsPerHourText.Name = "labelPacketsPerHourText";
			this.labelPacketsPerHourText.Size = new System.Drawing.Size(94, 13);
			this.labelPacketsPerHourText.TabIndex = 5;
			this.labelPacketsPerHourText.Text = "Packets Per Hour:";
			// 
			// numericUpDownPacketSize
			// 
			this.numericUpDownPacketSize.Location = new System.Drawing.Point(121, 62);
			this.numericUpDownPacketSize.Maximum = new decimal(new int[] {
            222,
            0,
            0,
            0});
			this.numericUpDownPacketSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPacketSize.Name = "numericUpDownPacketSize";
			this.numericUpDownPacketSize.Size = new System.Drawing.Size(67, 20);
			this.numericUpDownPacketSize.TabIndex = 8;
			this.numericUpDownPacketSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPacketSize.ValueChanged += new System.EventHandler(this.numericUpDownPacketSize_ValueChanged);
			// 
			// labelPacketSizeText
			// 
			this.labelPacketSizeText.AutoSize = true;
			this.labelPacketSizeText.Location = new System.Drawing.Point(39, 69);
			this.labelPacketSizeText.Name = "labelPacketSizeText";
			this.labelPacketSizeText.Size = new System.Drawing.Size(67, 13);
			this.labelPacketSizeText.TabIndex = 7;
			this.labelPacketSizeText.Text = "Packet Size:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(208, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "OnePacketTimeMs:";
			// 
			// labelOnePacketLengthMs
			// 
			this.labelOnePacketLengthMs.AutoSize = true;
			this.labelOnePacketLengthMs.Location = new System.Drawing.Point(309, 68);
			this.labelOnePacketLengthMs.Name = "labelOnePacketLengthMs";
			this.labelOnePacketLengthMs.Size = new System.Drawing.Size(10, 13);
			this.labelOnePacketLengthMs.TabIndex = 10;
			this.labelOnePacketLengthMs.Text = "-";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(703, 415);
			this.Controls.Add(this.labelOnePacketLengthMs);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDownPacketSize);
			this.Controls.Add(this.labelPacketSizeText);
			this.Controls.Add(this.numericUpDownPacketsPerHour);
			this.Controls.Add(this.labelPacketsPerHourText);
			this.Controls.Add(this.checkBoxIsConfirmed);
			this.Controls.Add(this.numericUpDownEndNodesCount);
			this.Controls.Add(this.buttonDoEmulation);
			this.Controls.Add(this.labelEndNodesCount);
			this.Name = "Form1";
			this.Text = "LorawanCollisionsSimulator";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndNodesCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketsPerHour)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelEndNodesCount;
		private System.Windows.Forms.Button buttonDoEmulation;
		private System.Windows.Forms.NumericUpDown numericUpDownEndNodesCount;
		private System.Windows.Forms.CheckBox checkBoxIsConfirmed;
		private System.Windows.Forms.NumericUpDown numericUpDownPacketsPerHour;
		private System.Windows.Forms.Label labelPacketsPerHourText;
		private System.Windows.Forms.NumericUpDown numericUpDownPacketSize;
		private System.Windows.Forms.Label labelPacketSizeText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelOnePacketLengthMs;
	}
}


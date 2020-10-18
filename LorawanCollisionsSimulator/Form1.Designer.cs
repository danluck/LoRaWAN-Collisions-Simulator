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
            this.numericUpDownSf = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAirTimePercents = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelEndNodeInitiatedCollisions = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelGatewaySkippedPackets = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndNodesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketsPerHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSf)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEndNodesCount
            // 
            this.labelEndNodesCount.AutoSize = true;
            this.labelEndNodesCount.Location = new System.Drawing.Point(16, 11);
            this.labelEndNodesCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEndNodesCount.Name = "labelEndNodesCount";
            this.labelEndNodesCount.Size = new System.Drawing.Size(123, 17);
            this.labelEndNodesCount.TabIndex = 0;
            this.labelEndNodesCount.Text = "End Nodes Count:";
            // 
            // buttonDoEmulation
            // 
            this.buttonDoEmulation.Location = new System.Drawing.Point(48, 266);
            this.buttonDoEmulation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDoEmulation.Name = "buttonDoEmulation";
            this.buttonDoEmulation.Size = new System.Drawing.Size(100, 28);
            this.buttonDoEmulation.TabIndex = 2;
            this.buttonDoEmulation.Text = "DoEmulation";
            this.buttonDoEmulation.UseVisualStyleBackColor = true;
            this.buttonDoEmulation.Click += new System.EventHandler(this.buttonDoEmulation_Click);
            // 
            // numericUpDownEndNodesCount
            // 
            this.numericUpDownEndNodesCount.Location = new System.Drawing.Point(161, 9);
            this.numericUpDownEndNodesCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.numericUpDownEndNodesCount.Size = new System.Drawing.Size(89, 22);
            this.numericUpDownEndNodesCount.TabIndex = 3;
            this.numericUpDownEndNodesCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownEndNodesCount.ValueChanged += new System.EventHandler(this.numericUpDownEndNodesCount_ValueChanged);
            // 
            // checkBoxIsConfirmed
            // 
            this.checkBoxIsConfirmed.AutoSize = true;
            this.checkBoxIsConfirmed.Location = new System.Drawing.Point(48, 238);
            this.checkBoxIsConfirmed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxIsConfirmed.Name = "checkBoxIsConfirmed";
            this.checkBoxIsConfirmed.Size = new System.Drawing.Size(159, 21);
            this.checkBoxIsConfirmed.TabIndex = 4;
            this.checkBoxIsConfirmed.Text = "IsConfirmedTransmit";
            this.checkBoxIsConfirmed.UseVisualStyleBackColor = true;
            this.checkBoxIsConfirmed.CheckedChanged += new System.EventHandler(this.checkBoxIsConfirmed_CheckedChanged);
            // 
            // numericUpDownPacketsPerHour
            // 
            this.numericUpDownPacketsPerHour.Location = new System.Drawing.Point(161, 41);
            this.numericUpDownPacketsPerHour.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.numericUpDownPacketsPerHour.Size = new System.Drawing.Size(89, 22);
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
            this.labelPacketsPerHourText.Location = new System.Drawing.Point(16, 43);
            this.labelPacketsPerHourText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPacketsPerHourText.Name = "labelPacketsPerHourText";
            this.labelPacketsPerHourText.Size = new System.Drawing.Size(123, 17);
            this.labelPacketsPerHourText.TabIndex = 5;
            this.labelPacketsPerHourText.Text = "Packets Per Hour:";
            // 
            // numericUpDownPacketSize
            // 
            this.numericUpDownPacketSize.Location = new System.Drawing.Point(161, 76);
            this.numericUpDownPacketSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.numericUpDownPacketSize.Size = new System.Drawing.Size(89, 22);
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
            this.labelPacketSizeText.Location = new System.Drawing.Point(52, 85);
            this.labelPacketSizeText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPacketSizeText.Name = "labelPacketSizeText";
            this.labelPacketSizeText.Size = new System.Drawing.Size(86, 17);
            this.labelPacketSizeText.TabIndex = 7;
            this.labelPacketSizeText.Text = "Packet Size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 172);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "OnePacketTimeMs:";
            // 
            // labelOnePacketLengthMs
            // 
            this.labelOnePacketLengthMs.AutoSize = true;
            this.labelOnePacketLengthMs.Location = new System.Drawing.Point(187, 172);
            this.labelOnePacketLengthMs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOnePacketLengthMs.Name = "labelOnePacketLengthMs";
            this.labelOnePacketLengthMs.Size = new System.Drawing.Size(13, 17);
            this.labelOnePacketLengthMs.TabIndex = 10;
            this.labelOnePacketLengthMs.Text = "-";
            // 
            // numericUpDownSf
            // 
            this.numericUpDownSf.Location = new System.Drawing.Point(161, 117);
            this.numericUpDownSf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownSf.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownSf.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownSf.Name = "numericUpDownSf";
            this.numericUpDownSf.Size = new System.Drawing.Size(89, 22);
            this.numericUpDownSf.TabIndex = 12;
            this.numericUpDownSf.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownSf.ValueChanged += new System.EventHandler(this.numericUpDownSf_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "SF:";
            // 
            // labelAirTimePercents
            // 
            this.labelAirTimePercents.AutoSize = true;
            this.labelAirTimePercents.Location = new System.Drawing.Point(187, 199);
            this.labelAirTimePercents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAirTimePercents.Name = "labelAirTimePercents";
            this.labelAirTimePercents.Size = new System.Drawing.Size(13, 17);
            this.labelAirTimePercents.TabIndex = 14;
            this.labelAirTimePercents.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 199);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "End Node Air time, %:";
            // 
            // labelEndNodeInitiatedCollisions
            // 
            this.labelEndNodeInitiatedCollisions.AutoSize = true;
            this.labelEndNodeInitiatedCollisions.Location = new System.Drawing.Point(231, 316);
            this.labelEndNodeInitiatedCollisions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEndNodeInitiatedCollisions.Name = "labelEndNodeInitiatedCollisions";
            this.labelEndNodeInitiatedCollisions.Size = new System.Drawing.Size(13, 17);
            this.labelEndNodeInitiatedCollisions.TabIndex = 16;
            this.labelEndNodeInitiatedCollisions.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 316);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "End Node Initiated Collisions, %:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 347);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Gateway Skipped Packets:";
            // 
            // labelGatewaySkippedPackets
            // 
            this.labelGatewaySkippedPackets.AutoSize = true;
            this.labelGatewaySkippedPackets.Location = new System.Drawing.Point(231, 347);
            this.labelGatewaySkippedPackets.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGatewaySkippedPackets.Name = "labelGatewaySkippedPackets";
            this.labelGatewaySkippedPackets.Size = new System.Drawing.Size(13, 17);
            this.labelGatewaySkippedPackets.TabIndex = 18;
            this.labelGatewaySkippedPackets.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 533);
            this.Controls.Add(this.labelGatewaySkippedPackets);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelEndNodeInitiatedCollisions);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelAirTimePercents);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownSf);
            this.Controls.Add(this.label2);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "LorawanCollisionsSimulator";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndNodesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketsPerHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSf)).EndInit();
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
		private System.Windows.Forms.NumericUpDown numericUpDownSf;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelAirTimePercents;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label labelEndNodeInitiatedCollisions;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelGatewaySkippedPackets;
    }
}


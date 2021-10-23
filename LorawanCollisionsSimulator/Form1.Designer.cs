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
			this.label6 = new System.Windows.Forms.Label();
			this.labelSuccessfullyReceivedPackets = new System.Windows.Forms.Label();
			this.labelSuccessPacketsPercents = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.labelGatewayAirTime = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericUpDownRx1 = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.numericUpDownSimulateHours = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.checkBoxGwRx1Enabled = new System.Windows.Forms.CheckBox();
			this.checkBoxGwRx2Enabled = new System.Windows.Forms.CheckBox();
			this.labelChannelsCount = new System.Windows.Forms.Label();
			this.numericUpDownChannelsCount = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndNodesCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketsPerHour)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSf)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRx1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSimulateHours)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownChannelsCount)).BeginInit();
			this.SuspendLayout();
			// 
			// labelEndNodesCount
			// 
			this.labelEndNodesCount.AutoSize = true;
			this.labelEndNodesCount.Location = new System.Drawing.Point(58, 7);
			this.labelEndNodesCount.Name = "labelEndNodesCount";
			this.labelEndNodesCount.Size = new System.Drawing.Size(94, 13);
			this.labelEndNodesCount.TabIndex = 0;
			this.labelEndNodesCount.Text = "End Nodes Count:";
			// 
			// buttonDoEmulation
			// 
			this.buttonDoEmulation.Location = new System.Drawing.Point(10, 274);
			this.buttonDoEmulation.Name = "buttonDoEmulation";
			this.buttonDoEmulation.Size = new System.Drawing.Size(303, 48);
			this.buttonDoEmulation.TabIndex = 2;
			this.buttonDoEmulation.Text = "Do Emulation";
			this.buttonDoEmulation.UseVisualStyleBackColor = true;
			this.buttonDoEmulation.Click += new System.EventHandler(this.buttonDoEmulation_Click);
			// 
			// numericUpDownEndNodesCount
			// 
			this.numericUpDownEndNodesCount.Location = new System.Drawing.Point(155, 6);
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
			this.numericUpDownEndNodesCount.ValueChanged += new System.EventHandler(this.numericUpDownEndNodesCount_ValueChanged);
			// 
			// checkBoxIsConfirmed
			// 
			this.checkBoxIsConfirmed.AutoSize = true;
			this.checkBoxIsConfirmed.Location = new System.Drawing.Point(155, 165);
			this.checkBoxIsConfirmed.Name = "checkBoxIsConfirmed";
			this.checkBoxIsConfirmed.Size = new System.Drawing.Size(73, 17);
			this.checkBoxIsConfirmed.TabIndex = 4;
			this.checkBoxIsConfirmed.Text = "Confirmed";
			this.checkBoxIsConfirmed.UseVisualStyleBackColor = true;
			this.checkBoxIsConfirmed.CheckedChanged += new System.EventHandler(this.checkBoxIsConfirmed_CheckedChanged);
			// 
			// numericUpDownPacketsPerHour
			// 
			this.numericUpDownPacketsPerHour.Location = new System.Drawing.Point(155, 28);
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
			this.labelPacketsPerHourText.Location = new System.Drawing.Point(2, 29);
			this.labelPacketsPerHourText.Name = "labelPacketsPerHourText";
			this.labelPacketsPerHourText.Size = new System.Drawing.Size(149, 13);
			this.labelPacketsPerHourText.TabIndex = 5;
			this.labelPacketsPerHourText.Text = "Packets Per Hour From Node:";
			// 
			// numericUpDownPacketSize
			// 
			this.numericUpDownPacketSize.Location = new System.Drawing.Point(155, 74);
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
			this.labelPacketSizeText.Location = new System.Drawing.Point(52, 75);
			this.labelPacketSizeText.Name = "labelPacketSizeText";
			this.labelPacketSizeText.Size = new System.Drawing.Size(99, 13);
			this.labelPacketSizeText.TabIndex = 7;
			this.labelPacketSizeText.Text = "Packet Size, Bytes:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(33, 235);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "One Packet Duration Time Ms:";
			// 
			// labelOnePacketLengthMs
			// 
			this.labelOnePacketLengthMs.AutoSize = true;
			this.labelOnePacketLengthMs.Location = new System.Drawing.Point(188, 235);
			this.labelOnePacketLengthMs.Name = "labelOnePacketLengthMs";
			this.labelOnePacketLengthMs.Size = new System.Drawing.Size(10, 13);
			this.labelOnePacketLengthMs.TabIndex = 10;
			this.labelOnePacketLengthMs.Text = "-";
			// 
			// numericUpDownSf
			// 
			this.numericUpDownSf.Location = new System.Drawing.Point(155, 96);
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
			this.numericUpDownSf.Size = new System.Drawing.Size(67, 20);
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
			this.label2.Location = new System.Drawing.Point(128, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "SF:";
			// 
			// labelAirTimePercents
			// 
			this.labelAirTimePercents.AutoSize = true;
			this.labelAirTimePercents.Location = new System.Drawing.Point(188, 257);
			this.labelAirTimePercents.Name = "labelAirTimePercents";
			this.labelAirTimePercents.Size = new System.Drawing.Size(10, 13);
			this.labelAirTimePercents.TabIndex = 14;
			this.labelAirTimePercents.Text = "-";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(81, 257);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(109, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "End Node Air time, %:";
			// 
			// labelEndNodeInitiatedCollisions
			// 
			this.labelEndNodeInitiatedCollisions.AutoSize = true;
			this.labelEndNodeInitiatedCollisions.Location = new System.Drawing.Point(253, 19);
			this.labelEndNodeInitiatedCollisions.Name = "labelEndNodeInitiatedCollisions";
			this.labelEndNodeInitiatedCollisions.Size = new System.Drawing.Size(10, 13);
			this.labelEndNodeInitiatedCollisions.TabIndex = 16;
			this.labelEndNodeInitiatedCollisions.Text = "-";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(162, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "End Nodes Caused Collisions, %:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(241, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Gateway Skipped Packets While Send Downlink:";
			// 
			// labelGatewaySkippedPackets
			// 
			this.labelGatewaySkippedPackets.AutoSize = true;
			this.labelGatewaySkippedPackets.Location = new System.Drawing.Point(253, 44);
			this.labelGatewaySkippedPackets.Name = "labelGatewaySkippedPackets";
			this.labelGatewaySkippedPackets.Size = new System.Drawing.Size(10, 13);
			this.labelGatewaySkippedPackets.TabIndex = 18;
			this.labelGatewaySkippedPackets.Text = "-";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 71);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(154, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "Successfully received packets:";
			// 
			// labelSuccessfullyReceivedPackets
			// 
			this.labelSuccessfullyReceivedPackets.AutoSize = true;
			this.labelSuccessfullyReceivedPackets.Location = new System.Drawing.Point(253, 71);
			this.labelSuccessfullyReceivedPackets.Name = "labelSuccessfullyReceivedPackets";
			this.labelSuccessfullyReceivedPackets.Size = new System.Drawing.Size(10, 13);
			this.labelSuccessfullyReceivedPackets.TabIndex = 20;
			this.labelSuccessfullyReceivedPackets.Text = "-";
			// 
			// labelSuccessPacketsPercents
			// 
			this.labelSuccessPacketsPercents.AutoSize = true;
			this.labelSuccessPacketsPercents.Location = new System.Drawing.Point(253, 98);
			this.labelSuccessPacketsPercents.Name = "labelSuccessPacketsPercents";
			this.labelSuccessPacketsPercents.Size = new System.Drawing.Size(10, 13);
			this.labelSuccessPacketsPercents.TabIndex = 22;
			this.labelSuccessPacketsPercents.Text = "-";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(4, 98);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(168, 13);
			this.label8.TabIndex = 21;
			this.label8.Text = "Successfully received packets, %:";
			// 
			// labelGatewayAirTime
			// 
			this.labelGatewayAirTime.AutoSize = true;
			this.labelGatewayAirTime.Location = new System.Drawing.Point(253, 119);
			this.labelGatewayAirTime.Name = "labelGatewayAirTime";
			this.labelGatewayAirTime.Size = new System.Drawing.Size(10, 13);
			this.labelGatewayAirTime.TabIndex = 24;
			this.labelGatewayAirTime.Text = "-";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(38, 119);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(103, 13);
			this.label9.TabIndex = 23;
			this.label9.Text = "Gateway Air time, %:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.labelGatewayAirTime);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.labelEndNodeInitiatedCollisions);
			this.groupBox1.Controls.Add(this.labelSuccessPacketsPercents);
			this.groupBox1.Controls.Add(this.labelGatewaySkippedPackets);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.labelSuccessfullyReceivedPackets);
			this.groupBox1.Location = new System.Drawing.Point(10, 328);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(303, 163);
			this.groupBox1.TabIndex = 25;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Output";
			// 
			// numericUpDownRx1
			// 
			this.numericUpDownRx1.Location = new System.Drawing.Point(155, 118);
			this.numericUpDownRx1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.numericUpDownRx1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownRx1.Name = "numericUpDownRx1";
			this.numericUpDownRx1.Size = new System.Drawing.Size(67, 20);
			this.numericUpDownRx1.TabIndex = 27;
			this.numericUpDownRx1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(120, 120);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(31, 13);
			this.label7.TabIndex = 26;
			this.label7.Text = "RX1:";
			// 
			// numericUpDownSimulateHours
			// 
			this.numericUpDownSimulateHours.Location = new System.Drawing.Point(155, 140);
			this.numericUpDownSimulateHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
			this.numericUpDownSimulateHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownSimulateHours.Name = "numericUpDownSimulateHours";
			this.numericUpDownSimulateHours.Size = new System.Drawing.Size(67, 20);
			this.numericUpDownSimulateHours.TabIndex = 29;
			this.numericUpDownSimulateHours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(68, 142);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(81, 13);
			this.label10.TabIndex = 28;
			this.label10.Text = "Simulate Hours:";
			// 
			// checkBoxGwRx1Enabled
			// 
			this.checkBoxGwRx1Enabled.AutoSize = true;
			this.checkBoxGwRx1Enabled.Location = new System.Drawing.Point(155, 188);
			this.checkBoxGwRx1Enabled.Name = "checkBoxGwRx1Enabled";
			this.checkBoxGwRx1Enabled.Size = new System.Drawing.Size(127, 17);
			this.checkBoxGwRx1Enabled.TabIndex = 30;
			this.checkBoxGwRx1Enabled.Text = "GatewayRx1Transmit";
			this.checkBoxGwRx1Enabled.UseVisualStyleBackColor = true;
			this.checkBoxGwRx1Enabled.CheckedChanged += new System.EventHandler(this.checkBoxGwRx1Enabled_CheckedChanged);
			// 
			// checkBoxGwRx2Enabled
			// 
			this.checkBoxGwRx2Enabled.AutoSize = true;
			this.checkBoxGwRx2Enabled.Location = new System.Drawing.Point(155, 211);
			this.checkBoxGwRx2Enabled.Name = "checkBoxGwRx2Enabled";
			this.checkBoxGwRx2Enabled.Size = new System.Drawing.Size(127, 17);
			this.checkBoxGwRx2Enabled.TabIndex = 31;
			this.checkBoxGwRx2Enabled.Text = "GatewayRx2Transmit";
			this.checkBoxGwRx2Enabled.UseVisualStyleBackColor = true;
			this.checkBoxGwRx2Enabled.CheckedChanged += new System.EventHandler(this.checkBoxGwRx2Enabled_CheckedChanged);
			// 
			// labelChannelsCount
			// 
			this.labelChannelsCount.AutoSize = true;
			this.labelChannelsCount.Location = new System.Drawing.Point(21, 53);
			this.labelChannelsCount.Name = "labelChannelsCount";
			this.labelChannelsCount.Size = new System.Drawing.Size(130, 13);
			this.labelChannelsCount.TabIndex = 32;
			this.labelChannelsCount.Text = "Gateway Channels Count:";
			// 
			// numericUpDownChannelsCount
			// 
			this.numericUpDownChannelsCount.Location = new System.Drawing.Point(155, 51);
			this.numericUpDownChannelsCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownChannelsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownChannelsCount.Name = "numericUpDownChannelsCount";
			this.numericUpDownChannelsCount.Size = new System.Drawing.Size(67, 20);
			this.numericUpDownChannelsCount.TabIndex = 33;
			this.numericUpDownChannelsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 548);
			this.Controls.Add(this.numericUpDownChannelsCount);
			this.Controls.Add(this.labelChannelsCount);
			this.Controls.Add(this.checkBoxGwRx2Enabled);
			this.Controls.Add(this.checkBoxGwRx1Enabled);
			this.Controls.Add(this.numericUpDownSimulateHours);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.numericUpDownRx1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.groupBox1);
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
			this.Name = "Form1";
			this.Text = "LorawanCollisionsSimulator";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndNodesCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketsPerHour)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSf)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRx1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSimulateHours)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownChannelsCount)).EndInit();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelSuccessfullyReceivedPackets;
        private System.Windows.Forms.Label labelSuccessPacketsPercents;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelGatewayAirTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownRx1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownSimulateHours;
        private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox checkBoxGwRx1Enabled;
		private System.Windows.Forms.CheckBox checkBoxGwRx2Enabled;
		private System.Windows.Forms.Label labelChannelsCount;
		private System.Windows.Forms.NumericUpDown numericUpDownChannelsCount;
	}
}


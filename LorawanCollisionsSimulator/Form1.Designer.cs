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
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndNodesCount)).BeginInit();
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
			this.buttonDoEmulation.Location = new System.Drawing.Point(15, 87);
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
			this.checkBoxIsConfirmed.Location = new System.Drawing.Point(15, 37);
			this.checkBoxIsConfirmed.Name = "checkBoxIsConfirmed";
			this.checkBoxIsConfirmed.Size = new System.Drawing.Size(121, 17);
			this.checkBoxIsConfirmed.TabIndex = 4;
			this.checkBoxIsConfirmed.Text = "IsConfirmedTransmit";
			this.checkBoxIsConfirmed.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(703, 415);
			this.Controls.Add(this.checkBoxIsConfirmed);
			this.Controls.Add(this.numericUpDownEndNodesCount);
			this.Controls.Add(this.buttonDoEmulation);
			this.Controls.Add(this.labelEndNodesCount);
			this.Name = "Form1";
			this.Text = "LorawanCollisionsSimulator";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndNodesCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelEndNodesCount;
		private System.Windows.Forms.Button buttonDoEmulation;
		private System.Windows.Forms.NumericUpDown numericUpDownEndNodesCount;
		private System.Windows.Forms.CheckBox checkBoxIsConfirmed;
	}
}


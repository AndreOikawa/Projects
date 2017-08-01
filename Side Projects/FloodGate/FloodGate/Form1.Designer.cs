namespace FloodGate
{
	partial class frmSettings
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
			this.btnStart = new System.Windows.Forms.Button();
			this.lblSize = new System.Windows.Forms.Label();
			this.lblColors = new System.Windows.Forms.Label();
			this.nudField = new System.Windows.Forms.NumericUpDown();
			this.nudColors = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.nudField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudColors)).BeginInit();
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 55);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(130, 23);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "Begin Game";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.button1_Click);
			// 
			// lblSize
			// 
			this.lblSize.AutoSize = true;
			this.lblSize.Location = new System.Drawing.Point(13, 13);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(52, 13);
			this.lblSize.TabIndex = 1;
			this.lblSize.Text = "Field Size";
			// 
			// lblColors
			// 
			this.lblColors.AutoSize = true;
			this.lblColors.Location = new System.Drawing.Point(71, 13);
			this.lblColors.Name = "lblColors";
			this.lblColors.Size = new System.Drawing.Size(88, 13);
			this.lblColors.TabIndex = 2;
			this.lblColors.Text = "Number of Colors";
			// 
			// nudField
			// 
			this.nudField.Location = new System.Drawing.Point(12, 29);
			this.nudField.Name = "nudField";
			this.nudField.Size = new System.Drawing.Size(50, 20);
			this.nudField.TabIndex = 3;
			this.nudField.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudField.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// nudColors
			// 
			this.nudColors.Location = new System.Drawing.Point(92, 29);
			this.nudColors.Name = "nudColors";
			this.nudColors.Size = new System.Drawing.Size(50, 20);
			this.nudColors.TabIndex = 4;
			this.nudColors.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudColors.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(173, 93);
			this.Controls.Add(this.nudColors);
			this.Controls.Add(this.nudField);
			this.Controls.Add(this.lblColors);
			this.Controls.Add(this.lblSize);
			this.Controls.Add(this.btnStart);
			this.Name = "frmSettings";
			this.Text = "Settings";
			((System.ComponentModel.ISupportInitialize)(this.nudField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudColors)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.Label lblColors;
		private System.Windows.Forms.NumericUpDown nudField;
		private System.Windows.Forms.NumericUpDown nudColors;
	}
}


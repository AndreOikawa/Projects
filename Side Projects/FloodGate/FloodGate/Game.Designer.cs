namespace FloodGate
{
	partial class Game
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
			this.picField = new System.Windows.Forms.PictureBox();
			this.lblChange = new System.Windows.Forms.Label();
			this.picPickColor = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picPickColor)).BeginInit();
			this.SuspendLayout();
			// 
			// picField
			// 
			this.picField.Location = new System.Drawing.Point(0, 0);
			this.picField.Name = "picField";
			this.picField.Size = new System.Drawing.Size(300, 300);
			this.picField.TabIndex = 0;
			this.picField.TabStop = false;
			// 
			// lblChange
			// 
			this.lblChange.AutoSize = true;
			this.lblChange.Location = new System.Drawing.Point(306, 19);
			this.lblChange.Name = "lblChange";
			this.lblChange.Size = new System.Drawing.Size(56, 13);
			this.lblChange.TabIndex = 3;
			this.lblChange.Text = "New Color";
			// 
			// picPickColor
			// 
			this.picPickColor.Location = new System.Drawing.Point(377, 0);
			this.picPickColor.Name = "picPickColor";
			this.picPickColor.Size = new System.Drawing.Size(60, 300);
			this.picPickColor.TabIndex = 4;
			this.picPickColor.TabStop = false;
			this.picPickColor.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 301);
			this.Controls.Add(this.picPickColor);
			this.Controls.Add(this.lblChange);
			this.Controls.Add(this.picField);
			this.Name = "Game";
			this.Text = "Game";
			this.Load += new System.EventHandler(this.Game_Load);
			((System.ComponentModel.ISupportInitialize)(this.picField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picPickColor)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picField;
		private System.Windows.Forms.Label lblChange;
		private System.Windows.Forms.PictureBox picPickColor;
	}
}
namespace ShortestPath
{
	partial class Map
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
            this.components = new System.ComponentModel.Container();
            this.Update = new System.Windows.Forms.Timer(this.components);
            this.MapCanvas = new System.Windows.Forms.PictureBox();
            this.Return = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MapCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // Update
            // 
            this.Update.Enabled = true;
            this.Update.Interval = 10;
            this.Update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // MapCanvas
            // 
            this.MapCanvas.Location = new System.Drawing.Point(0, 0);
            this.MapCanvas.Name = "MapCanvas";
            this.MapCanvas.Size = new System.Drawing.Size(500, 500);
            this.MapCanvas.TabIndex = 0;
            this.MapCanvas.TabStop = false;
            // 
            // Return
            // 
            this.Return.Location = new System.Drawing.Point(417, 13);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(75, 23);
            this.Return.TabIndex = 1;
            this.Return.Text = "Return";
            this.Return.UseVisualStyleBackColor = true;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 503);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.MapCanvas);
            this.Name = "Map";
            this.Text = "Map";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Map_FormClosing);
            this.Load += new System.EventHandler(this.Map_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MapCanvas)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer Update;
		private System.Windows.Forms.PictureBox MapCanvas;
		private System.Windows.Forms.Button Return;
	}
}


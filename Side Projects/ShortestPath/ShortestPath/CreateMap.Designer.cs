namespace ShortestPath
{
	partial class CreateMap
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
			this.Done = new System.Windows.Forms.Button();
			this.Map = new System.Windows.Forms.PictureBox();
			this.Back = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Map)).BeginInit();
			this.SuspendLayout();
			// 
			// Done
			// 
			this.Done.Location = new System.Drawing.Point(369, 12);
			this.Done.Name = "Done";
			this.Done.Size = new System.Drawing.Size(120, 23);
			this.Done.TabIndex = 0;
			this.Done.Text = "Finish Map";
			this.Done.UseVisualStyleBackColor = true;
			this.Done.Click += new System.EventHandler(this.Done_Click);
			// 
			// Map
			// 
			this.Map.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.Map.Location = new System.Drawing.Point(0, 0);
			this.Map.Name = "Map";
			this.Map.Size = new System.Drawing.Size(500, 500);
			this.Map.TabIndex = 1;
			this.Map.TabStop = false;
			this.Map.Click += new System.EventHandler(this.Map_Click);
			this.Map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Map_MouseMove);
			// 
			// Back
			// 
			this.Back.Location = new System.Drawing.Point(12, 12);
			this.Back.Name = "Back";
			this.Back.Size = new System.Drawing.Size(120, 23);
			this.Back.TabIndex = 2;
			this.Back.Text = "Back";
			this.Back.UseVisualStyleBackColor = true;
			this.Back.Click += new System.EventHandler(this.Back_Click);
			// 
			// CreateMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(501, 500);
			this.Controls.Add(this.Back);
			this.Controls.Add(this.Done);
			this.Controls.Add(this.Map);
			this.Name = "CreateMap";
			this.Text = "CreateMap";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateMap_FormClosing);
			this.Load += new System.EventHandler(this.CreateMap_Load);
			((System.ComponentModel.ISupportInitialize)(this.Map)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Done;
		private System.Windows.Forms.PictureBox Map;
		private System.Windows.Forms.Button Back;
	}
}
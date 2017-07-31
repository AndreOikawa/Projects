namespace Reaction_Memory
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
			this.components = new System.ComponentModel.Container();
			this.Field = new System.Windows.Forms.PictureBox();
			this.spacing = new System.Windows.Forms.Timer(this.components);
			this.display = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
			this.SuspendLayout();
			// 
			// Field
			// 
			this.Field.BackColor = System.Drawing.Color.White;
			this.Field.Location = new System.Drawing.Point(0, 0);
			this.Field.Name = "Field";
			this.Field.Size = new System.Drawing.Size(300, 300);
			this.Field.TabIndex = 0;
			this.Field.TabStop = false;
			// 
			// spacing
			// 
			this.spacing.Tick += new System.EventHandler(this.spacing_Tick);
			// 
			// display
			// 
			this.display.Tick += new System.EventHandler(this.display_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(298, 298);
			this.Controls.Add(this.Field);
			this.Name = "Form1";
			this.Text = "Reaction Memory";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
			((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox Field;
		private System.Windows.Forms.Timer spacing;
		private System.Windows.Forms.Timer display;
	}
}


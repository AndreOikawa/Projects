namespace Tetris
{
	partial class Tetris
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
			this.fieldPb = new System.Windows.Forms.PictureBox();
			this.scoreLbl = new System.Windows.Forms.Label();
			this.nextPiecePb = new System.Windows.Forms.PictureBox();
			this.nextPieceLbl = new System.Windows.Forms.Label();
			this.pauseResumeBtn = new System.Windows.Forms.Button();
			this.gameTick = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.fieldPb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nextPiecePb)).BeginInit();
			this.SuspendLayout();
			// 
			// fieldPb
			// 
			this.fieldPb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.fieldPb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.fieldPb.Location = new System.Drawing.Point(13, 13);
			this.fieldPb.Name = "fieldPb";
			this.fieldPb.Size = new System.Drawing.Size(250, 500);
			this.fieldPb.TabIndex = 0;
			this.fieldPb.TabStop = false;
			// 
			// scoreLbl
			// 
			this.scoreLbl.AutoSize = true;
			this.scoreLbl.Location = new System.Drawing.Point(269, 13);
			this.scoreLbl.Name = "scoreLbl";
			this.scoreLbl.Size = new System.Drawing.Size(47, 13);
			this.scoreLbl.TabIndex = 1;
			this.scoreLbl.Text = "Score: 0";
			// 
			// nextPiecePb
			// 
			this.nextPiecePb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.nextPiecePb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nextPiecePb.Location = new System.Drawing.Point(272, 78);
			this.nextPiecePb.Name = "nextPiecePb";
			this.nextPiecePb.Size = new System.Drawing.Size(100, 100);
			this.nextPiecePb.TabIndex = 3;
			this.nextPiecePb.TabStop = false;
			// 
			// nextPieceLbl
			// 
			this.nextPieceLbl.AutoSize = true;
			this.nextPieceLbl.Location = new System.Drawing.Point(269, 51);
			this.nextPieceLbl.Name = "nextPieceLbl";
			this.nextPieceLbl.Size = new System.Drawing.Size(59, 13);
			this.nextPieceLbl.TabIndex = 4;
			this.nextPieceLbl.Text = "Next Piece";
			// 
			// pauseResumeBtn
			// 
			this.pauseResumeBtn.Location = new System.Drawing.Point(272, 490);
			this.pauseResumeBtn.Name = "pauseResumeBtn";
			this.pauseResumeBtn.Size = new System.Drawing.Size(75, 23);
			this.pauseResumeBtn.TabIndex = 5;
			this.pauseResumeBtn.Text = "Pause";
			this.pauseResumeBtn.UseVisualStyleBackColor = true;
			this.pauseResumeBtn.Click += new System.EventHandler(this.pauseResumeBtn_Click);
			// 
			// gameTick
			// 
			this.gameTick.Tick += new System.EventHandler(this.gameTick_Tick);
			// 
			// Tetris
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(397, 534);
			this.Controls.Add(this.pauseResumeBtn);
			this.Controls.Add(this.nextPieceLbl);
			this.Controls.Add(this.nextPiecePb);
			this.Controls.Add(this.scoreLbl);
			this.Controls.Add(this.fieldPb);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Tetris";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Tetris_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.fieldPb)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nextPiecePb)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox fieldPb;
		private System.Windows.Forms.Label scoreLbl;
		private System.Windows.Forms.PictureBox nextPiecePb;
		private System.Windows.Forms.Label nextPieceLbl;
		private System.Windows.Forms.Button pauseResumeBtn;
		private System.Windows.Forms.Timer gameTick;
	}
}


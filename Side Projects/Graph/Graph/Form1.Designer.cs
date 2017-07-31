namespace Graph
{
	partial class Graph
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
			this.addBtn = new System.Windows.Forms.Button();
			this.delBtn = new System.Windows.Forms.Button();
			this.deleteBox = new System.Windows.Forms.ComboBox();
			this.connectABox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.connectBBox = new System.Windows.Forms.ComboBox();
			this.conBtn = new System.Windows.Forms.Button();
			this.Refresh = new System.Windows.Forms.Timer(this.components);
			this.Canvas = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
			this.SuspendLayout();
			// 
			// addBtn
			// 
			this.addBtn.Location = new System.Drawing.Point(620, 13);
			this.addBtn.Name = "addBtn";
			this.addBtn.Size = new System.Drawing.Size(121, 23);
			this.addBtn.TabIndex = 1;
			this.addBtn.Text = "Add Node";
			this.addBtn.UseVisualStyleBackColor = true;
			this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
			// 
			// delBtn
			// 
			this.delBtn.Location = new System.Drawing.Point(619, 92);
			this.delBtn.Name = "delBtn";
			this.delBtn.Size = new System.Drawing.Size(121, 23);
			this.delBtn.TabIndex = 3;
			this.delBtn.Text = "Delete Node";
			this.delBtn.UseVisualStyleBackColor = true;
			this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
			// 
			// deleteBox
			// 
			this.deleteBox.FormattingEnabled = true;
			this.deleteBox.Location = new System.Drawing.Point(619, 65);
			this.deleteBox.Name = "deleteBox";
			this.deleteBox.Size = new System.Drawing.Size(121, 21);
			this.deleteBox.TabIndex = 4;
			// 
			// connectABox
			// 
			this.connectABox.FormattingEnabled = true;
			this.connectABox.Location = new System.Drawing.Point(619, 206);
			this.connectABox.Name = "connectABox";
			this.connectABox.Size = new System.Drawing.Size(121, 21);
			this.connectABox.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(619, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Node to Delete";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(619, 187);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Nodes to Connect";
			// 
			// connectBBox
			// 
			this.connectBBox.FormattingEnabled = true;
			this.connectBBox.Location = new System.Drawing.Point(619, 234);
			this.connectBBox.Name = "connectBBox";
			this.connectBBox.Size = new System.Drawing.Size(121, 21);
			this.connectBBox.TabIndex = 8;
			// 
			// conBtn
			// 
			this.conBtn.Location = new System.Drawing.Point(619, 262);
			this.conBtn.Name = "conBtn";
			this.conBtn.Size = new System.Drawing.Size(121, 23);
			this.conBtn.TabIndex = 9;
			this.conBtn.Text = "Connect Nodes";
			this.conBtn.UseVisualStyleBackColor = true;
			this.conBtn.Click += new System.EventHandler(this.conBtn_Click);
			// 
			// Refresh
			// 
			this.Refresh.Enabled = true;
			this.Refresh.Tick += new System.EventHandler(this.Refresh_Tick);
			// 
			// Canvas
			// 
			this.Canvas.BackColor = System.Drawing.Color.White;
			this.Canvas.Location = new System.Drawing.Point(13, 13);
			this.Canvas.Name = "Canvas";
			this.Canvas.Size = new System.Drawing.Size(600, 600);
			this.Canvas.TabIndex = 10;
			this.Canvas.TabStop = false;
			this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
			this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(636, 370);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "label3";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(636, 446);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "label4";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(636, 469);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "label5";
			// 
			// Graph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(904, 638);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Canvas);
			this.Controls.Add(this.conBtn);
			this.Controls.Add(this.connectBBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.connectABox);
			this.Controls.Add(this.deleteBox);
			this.Controls.Add(this.delBtn);
			this.Controls.Add(this.addBtn);
			this.Name = "Graph";
			this.Text = "Graph";
			((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button addBtn;
		private System.Windows.Forms.Button delBtn;
		private System.Windows.Forms.ComboBox deleteBox;
		private System.Windows.Forms.ComboBox connectABox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox connectBBox;
		private System.Windows.Forms.Button conBtn;
		private System.Windows.Forms.Timer Refresh;
		private System.Windows.Forms.PictureBox Canvas;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}


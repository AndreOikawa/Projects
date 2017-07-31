namespace ShortestPath
{
	partial class Main
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
			this.label1 = new System.Windows.Forms.Label();
			this.newMap = new System.Windows.Forms.Button();
			this.oldMap = new System.Windows.Forms.Button();
			this.xMap = new System.Windows.Forms.NumericUpDown();
			this.yMap = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.xMap)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yMap)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Map Dimension";
			// 
			// newMap
			// 
			this.newMap.Location = new System.Drawing.Point(16, 56);
			this.newMap.Name = "newMap";
			this.newMap.Size = new System.Drawing.Size(106, 23);
			this.newMap.TabIndex = 3;
			this.newMap.Text = "Create New Map";
			this.newMap.UseVisualStyleBackColor = true;
			this.newMap.Click += new System.EventHandler(this.newMap_Click);
			// 
			// oldMap
			// 
			this.oldMap.Location = new System.Drawing.Point(16, 86);
			this.oldMap.Name = "oldMap";
			this.oldMap.Size = new System.Drawing.Size(106, 23);
			this.oldMap.TabIndex = 4;
			this.oldMap.Text = "Use Existing Map";
			this.oldMap.UseVisualStyleBackColor = true;
			this.oldMap.Click += new System.EventHandler(this.oldMap_Click);
			// 
			// xMap
			// 
			this.xMap.Location = new System.Drawing.Point(16, 30);
			this.xMap.Name = "xMap";
			this.xMap.Size = new System.Drawing.Size(50, 20);
			this.xMap.TabIndex = 5;
			this.xMap.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.xMap.ValueChanged += new System.EventHandler(this.xMap_ValueChanged);
			// 
			// yMap
			// 
			this.yMap.Location = new System.Drawing.Point(72, 30);
			this.yMap.Name = "yMap";
			this.yMap.Size = new System.Drawing.Size(50, 20);
			this.yMap.TabIndex = 6;
			this.yMap.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.yMap.ValueChanged += new System.EventHandler(this.yMap_ValueChanged);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(142, 121);
			this.Controls.Add(this.yMap);
			this.Controls.Add(this.xMap);
			this.Controls.Add(this.oldMap);
			this.Controls.Add(this.newMap);
			this.Controls.Add(this.label1);
			this.Name = "Main";
			this.Text = "Main";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.xMap)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yMap)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button newMap;
		private System.Windows.Forms.Button oldMap;
		private System.Windows.Forms.NumericUpDown xMap;
		private System.Windows.Forms.NumericUpDown yMap;
	}
}
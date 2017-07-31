namespace UWScheduler
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
			this.termList = new System.Windows.Forms.ComboBox();
			this.yearList = new System.Windows.Forms.ComboBox();
			this.courseList = new System.Windows.Forms.ComboBox();
			this.courseNumTxt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// termList
			// 
			this.termList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.termList.FormattingEnabled = true;
			this.termList.Items.AddRange(new object[] {
            "Fall",
            "Spring",
            "Winter"});
			this.termList.Location = new System.Drawing.Point(13, 13);
			this.termList.Name = "termList";
			this.termList.Size = new System.Drawing.Size(121, 21);
			this.termList.TabIndex = 0;
			// 
			// yearList
			// 
			this.yearList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.yearList.FormattingEnabled = true;
			this.yearList.Location = new System.Drawing.Point(13, 41);
			this.yearList.Name = "yearList";
			this.yearList.Size = new System.Drawing.Size(121, 21);
			this.yearList.TabIndex = 1;
			// 
			// courseList
			// 
			this.courseList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.courseList.FormattingEnabled = true;
			this.courseList.Location = new System.Drawing.Point(13, 69);
			this.courseList.Name = "courseList";
			this.courseList.Size = new System.Drawing.Size(121, 21);
			this.courseList.TabIndex = 2;
			// 
			// courseNumTxt
			// 
			this.courseNumTxt.Location = new System.Drawing.Point(13, 97);
			this.courseNumTxt.Name = "courseNumTxt";
			this.courseNumTxt.Size = new System.Drawing.Size(121, 20);
			this.courseNumTxt.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(282, 152);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "label1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(513, 423);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.courseNumTxt);
			this.Controls.Add(this.courseList);
			this.Controls.Add(this.yearList);
			this.Controls.Add(this.termList);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox termList;
		private System.Windows.Forms.ComboBox yearList;
		private System.Windows.Forms.ComboBox courseList;
		private System.Windows.Forms.TextBox courseNumTxt;
		private System.Windows.Forms.Label label1;
	}
}


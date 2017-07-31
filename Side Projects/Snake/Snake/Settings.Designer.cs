namespace Snake
{
    partial class Settings
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
            this.lblMap = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.cbMap = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(13, 13);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(51, 13);
            this.lblMap.TabIndex = 1;
            this.lblMap.Text = "Map Size";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(138, 94);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(38, 13);
            this.lblSpeed.TabIndex = 4;
            this.lblSpeed.Text = "Speed";
            // 
            // cbMap
            // 
            this.cbMap.FormattingEnabled = true;
            this.cbMap.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
            this.cbMap.Location = new System.Drawing.Point(12, 29);
            this.cbMap.MaxDropDownItems = 3;
            this.cbMap.Name = "cbMap";
            this.cbMap.Size = new System.Drawing.Size(121, 21);
            this.cbMap.TabIndex = 5;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cbMap);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblMap);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.ComboBox cbMap;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloodGate
{
	public partial class frmSettings : Form
	{
		public frmSettings()
		{
			InitializeComponent();
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (nudField.Value < 10)
				nudField.Value = 10;
			if (nudField.Value > 50)
				nudField.Value = 50;
		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			if (nudColors.Value < 2)
				nudColors.Value = 2;
			if (nudColors.Value > 10)
				nudColors.Value = 10;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var frm = new Game();
			frm._fieldSize = Convert.ToInt32(nudField.Value);
			frm._numColors = Convert.ToInt32(nudColors.Value);
			frm.Location = this.Location;
			frm.StartPosition = FormStartPosition.Manual;
			frm.FormClosing += delegate { this.Show(); };
			frm.Show();
			this.Hide();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPath
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}


		private void xMap_ValueChanged(object sender, EventArgs e)
		{
			if (xMap.Value < 10)
			{
				xMap.Value = 10;
			}
			else if (xMap.Value > 100)
			{
				xMap.Value = 100;
			}
		}

		private void yMap_ValueChanged(object sender, EventArgs e)
		{
			if (yMap.Value < 10)
			{
				yMap.Value = 10;
			}
			else if (yMap.Value > 100)
			{
				yMap.Value = 100;
			}
		}

		private void newMap_Click(object sender, EventArgs e)
		{
			var frm = new CreateMap();
			frm._height = Convert.ToInt32(yMap.Value);
			frm._width = Convert.ToInt32(xMap.Value);
			frm.Location = this.Location;
			frm.StartPosition = FormStartPosition.Manual;
			frm.FormClosing += delegate { this.Show(); };
			frm.Show();
			this.Hide();
		}

		private void oldMap_Click(object sender, EventArgs e)
		{
			var frm = new Map();
			frm.Location = this.Location;
			frm.StartPosition = FormStartPosition.Manual;
			frm.FormClosing += delegate { this.Show(); };
			frm.Show();
			this.Hide();
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}
	}
}

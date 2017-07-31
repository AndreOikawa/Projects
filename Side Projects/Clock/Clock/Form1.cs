using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
	public partial class Form1 : Form
	{
		int h = 0, m = 0, s = 0, ms = 0;

		private void Form1_Load(object sender, EventArgs e)
		{
			label1.Text = h.ToString();
			label2.Text = m.ToString();
			label3.Text = s.ToString();
			label4.Text = ms.ToString();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Text = h.ToString();
			label2.Text = m.ToString();
			label3.Text = s.ToString();
			label4.Text = ms.ToString();
			ms += 1;
			if (ms == 9)
			{
				s += 1;
				ms = 0;
			}
			if (s == 59)
			{
				s = 0;
				m += 1;
			}
			if (m == 59)
			{
				m = 0;
				h += 1;
			}
		}

		private void reset_Click(object sender, EventArgs e)
		{
			h = 0; m = 0; s = 0; ms = 0;
			timer1.Stop();
			label1.Text = h.ToString();
			label2.Text = m.ToString();
			label3.Text = s.ToString();
			label4.Text = ms.ToString();
		}

		private void start_Click(object sender, EventArgs e)
		{
			timer1.Start();
		}

		public Form1()
		{
			InitializeComponent();
		}

	}
}

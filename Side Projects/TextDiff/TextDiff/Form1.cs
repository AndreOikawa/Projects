using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDiff
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		int _max, _curr = 0;
		private void button1_Click(object sender, EventArgs e)
		{
			textBox1.Text = Regex.Replace(Regex.Replace(textBox1.Text, @" +", ""), @"\n+", "\n");
			textBox2.Text = Regex.Replace(Regex.Replace(textBox2.Text, @" +", ""), @"\n+", "\n");
			_max = (textBox1.Text.Length > textBox2.Text.Length) ? textBox1.Text.Length : textBox2.Text.Length;
			//timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (_curr < _max)
			{
				if (textBox1.Text[_curr] != textBox2.Text[_curr])
				{
					//textBox3.Text += textBox1.Text[_curr];
					textBox1.Text=textBox1.Text.Remove(0, 1);
					textBox2.Text=textBox2.Text.Remove(0, 1);
					
				}
				
			}
            else timer1.Stop();
            _curr++;
        }
	}
}

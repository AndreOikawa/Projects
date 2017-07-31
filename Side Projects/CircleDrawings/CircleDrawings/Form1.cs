using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleDrawings
{
	public partial class Form1 : Form
	{
		Point _center, _current, _end;
		int _radius = 100;
		double _rad = 0;
		public Form1()
		{
			InitializeComponent();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			_current = new Point(Convert.ToInt32(_radius * Math.Cos(_rad)) + _center.X, Convert.ToInt32(_radius * Math.Sin(_rad)+_center.Y));
			_end = new Point(Convert.ToInt32(_radius / 2 * Math.Cos(_rad/2 * -1)) + _current.X, Convert.ToInt32(_radius / 2 * Math.Sin(_rad/2 * -1)) + _current.Y);
			//pictureBox1.Paint += new PaintEventHandler(Circle_Paint);
			pictureBox1.Refresh();
			_rad += 0.1;
			
		}

		private void DrawIt(Point center, Point end, Color colour, Graphics g)
		{
			//System.Drawing.Graphics graphics = this.CreateGraphics();
			SolidBrush myBrush = new SolidBrush(colour);

			//g.FillEllipse(
			//	myBrush,
			//	x, y, width, height);
			g.DrawLine(new Pen(colour, 2f), center, end);
		}
		private void Circle_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			// Create a local version of the graphics object for the PictureBox.
			Graphics g = e.Graphics;

			// Draw a line in the PictureBox.
			DrawIt(_center, _current, Color.Black, g);
			DrawIt(_current, _end, Color.Red, g);


		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
			pictureBox1.Paint += new PaintEventHandler(Circle_Paint);
		}
	}
}

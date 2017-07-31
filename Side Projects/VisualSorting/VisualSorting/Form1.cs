using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualSorting.Algorithms;

namespace VisualSorting
{
	public partial class Form1 : Form
	{
		List<IAlgorithm> _algorithms;

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//int x = 10;
			//int y = 10;
			//DrawIt(x, y, 90, 90, Color.Red);
			//x += 100;
			//y += 100;
			//DrawIt(x, y, 90, 90, Color.Red);
			//x += 100;
			//y += 100;
			//DrawIt(x, y, 90, 90, Color.Red);
			//x += 100;
			//y += 100;
			//DrawIt(x, y, 90, 90, Color.Red);
			//x += 100;
			//y += 100;
		}

		private void DrawIt(int x, int y, int width, int height, Color colour, Graphics g)
		{
			//System.Drawing.Graphics graphics = this.CreateGraphics();
			System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(x, y, width, height);
			System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(colour);
			g.FillRectangle(myBrush, rectangle);
			myBrush.Dispose();
		}

		private List<PictureBox> _box = new List<PictureBox>();
		private int _items = 10;
		private int _width = 130;

		private void Form1_Load(object sender, System.EventArgs e)
		{
			_algorithms = new List<IAlgorithm>();
			_algorithms.Add(new SelectionSort());

			List<int> array = new List<int>();

			for (int i = 1; i <= _items; i++)
			{
				array.Add(i);
			}

			int len = _algorithms.Count;

			for (int x = 10; x < len * _width; x += _width + 10)
			{
				for (int y = 10; y < 4 * _width; y += _width + 10)
				{
					PictureBox box = new PictureBox();
					// Dock the PictureBox to the form and set its background to white.
					box.Location = new Point(x, y);
					box.Size = new Size(_width, _width);
					box.BackColor = Color.White;
					// Connect the Paint event of the PictureBox to the event handler method.
					box.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);

					// Add the PictureBox control to the Form.
					this.Controls.Add(box);
					_box.Add(box);	
				}
			}
		}

		private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			// Create a local version of the graphics object for the PictureBox.
			Graphics g = e.Graphics;

			// Draw a line in the PictureBox.
			DrawIt(10, 10, 140, 140, Color.Red, g);
			DrawIt(50, 50, 20, 20, Color.Green, g);
			g.Dispose();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			label1.Text = e.Location.ToString();
		}
	}
}

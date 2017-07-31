using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reaction_Memory
{
	public partial class Form1 : Form
	{
		Size _pieceSize;
		int _numPieces = 3, _pick, _level = 1, _maxBlink = 1,_currentBlinks = 0;
		List<int> _correctBlinks;
		List<Tuple<Point, Color>> _grid;
		bool _oneTick = false, _finishedBlinking = false;
		public Form1()
		{
			InitializeComponent();
		}

		private void spacing_Tick(object sender, EventArgs e)
		{
			if (_oneTick)
			{
				_grid[_pick] = new Tuple<Point, Color>(_grid[_pick].Item1, Color.White);
				Field.Refresh();
				_oneTick = !_oneTick;
				spacing.Stop();
				display.Start();

			}
			else
			{
				_oneTick = !_oneTick;
			}
		}

		private void display_Tick(object sender, EventArgs e)
		{
			if (_currentBlinks < _maxBlink)
			{
				if (_oneTick)
				{
					Random rng = new Random();
					_pick = rng.Next(0, _numPieces * _numPieces);
					_grid[_pick] = new Tuple<Point, Color>(_grid[_pick].Item1, Color.Green);
					_correctBlinks.Add(_pick);
					Field.Refresh();

					_oneTick = !_oneTick;
					_currentBlinks++;

					display.Stop();
					spacing.Start();

				}
				else
				{
					_oneTick = !_oneTick;
				}
			}
			else
			{
				_finishedBlinking = true;
				//_correctBlinks = new List<int>();
			}
		}

		private void FieldGrid_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			for (int x = _pieceSize.Width; x <= Field.Width; x += _pieceSize.Width)
				DrawLine(new Point(x, 0), new Point(x, Field.Height), Color.Gray, g);
			for (int y = _pieceSize.Height; y <= Field.Height; y += _pieceSize.Height)
				DrawLine(new Point(0, y), new Point(Field.Width, y), Color.Gray, g);

		}

		private void Form1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (_finishedBlinking)
			{
				try
				{
					//
					if (_correctBlinks[0] == char.GetNumericValue(e.KeyChar) - 1)
					{
						_correctBlinks.RemoveAt(0);
						if (_correctBlinks.Count == 0)
						{
							_finishedBlinking = false;
							_currentBlinks = 0;
							if (++_maxBlink == 5)
							{
								_level += 1;
								_maxBlink = 1;
								display.Interval /= 2;
								spacing.Interval /= 2;
								display.Start();
							}
							this.Text = _level + "." + _maxBlink;
						}
					}
					else
					{
						MessageBox.Show("You got it wrong n00b, restarting");
						_maxBlink = 1;
						_currentBlinks = 0;
						_level = 1;
						display.Interval = 100;
						spacing.Interval = 100;
						_correctBlinks.Clear();
						this.Text = _level + "." + _maxBlink;
					}
				}
				catch (Exception) { };
			}
		}

		private void DrawLine(Point begin, Point end, Color colour, Graphics g)
		{
			//System.Drawing.Graphics graphics = this.CreateGraphics();
			Pen myPen = new Pen(Color.Black, 1);
			g.DrawLine(myPen, begin, end);
			myPen.Dispose();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			this.Text = _level + "." + _maxBlink;
			_pieceSize = new Size(Field.Width / _numPieces, Field.Height / _numPieces);
			_correctBlinks = new List<int>();
			_grid = new List<Tuple<Point, Color>>();
			for (int i = Field.Height - _pieceSize.Height; i >= 0; i -= _pieceSize.Height)
			{
				for (int j = 0; j < Field.Width; j += _pieceSize.Width)
				{
					_grid.Add(new Tuple<Point, Color>(new Point(j, i), Color.White));
				}
			}
			Field.Paint += new PaintEventHandler(FieldPiece_Paint);
			Field.Paint += new PaintEventHandler(FieldGrid_Paint);
			Field.Refresh();
			display.Start();
		}

		private void FieldPiece_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			foreach (var row in _grid)
				DrawIt(row.Item1, _pieceSize, row.Item2, g);
		}
		private void DrawIt(Point pos, Size size, Color colour, Graphics g)
		{
			//System.Drawing.Graphics graphics = this.CreateGraphics();
			SolidBrush myBrush = new SolidBrush(colour);
			Pen myPen = new Pen(Color.Black, 1);

			Rectangle rectangle = new Rectangle(pos, size);

			g.FillRectangle(myBrush, rectangle);
			//g.DrawRectangle(myPen, rectangle);

			myBrush.Dispose();
			myPen.Dispose();
		}
	}
}

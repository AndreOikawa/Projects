using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapGenerator
{
	public partial class Form1 : Form
	{
		Size _pieceSize;
		int _numTiles = 20, _minRoomSize, _maxRoomSize, _numRooms;
		List<List<Tile>> _grid;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Random rng = new Random();
			_pieceSize = new Size(Field.Width / _numTiles, Field.Height / _numTiles);
			_minRoomSize = _numTiles / 5;
			_maxRoomSize = _numTiles / 4;
			_numRooms = rng.Next(4, 10);

			GenerateMap();

			Field.Paint += new PaintEventHandler(FieldPiece_Paint);
			Field.Paint += new PaintEventHandler(FieldGrid_Paint);
			Field.Refresh();
		}
		private void FieldPiece_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			foreach (var row in _grid)
				foreach (var tile in row)
					DrawIt(new Point(tile.Position.X, tile.Position.Y), _pieceSize, tile.colorMapping[tile.typeMapping[tile.Type]], g);

		}
		private void FieldGrid_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			for (int x = _pieceSize.Width; x <= Field.Width; x += _pieceSize.Width)
				DrawLine(new Point(x, 0), new Point(x, Field.Height), Color.Gray, g);
			for (int y = _pieceSize.Height; y <= Field.Height; y += _pieceSize.Height)
				DrawLine(new Point(0, y), new Point(Field.Width, y), Color.Gray, g);

		}
		private void DrawLine(Point begin, Point end, Color colour, Graphics g)
		{
			//System.Drawing.Graphics graphics = this.CreateGraphics();
			Pen myPen = new Pen(Color.Black, 1);
			g.DrawLine(myPen, begin, end);
			myPen.Dispose();
		}

		private void Field_Click(object sender, EventArgs e)
		{
			GenerateMap();

			Field.Refresh();
		}

		private void GenerateRooms()
		{
			Random picker = new Random();
			for (int i = 0; i < _numRooms; i++)
			{
				int y = picker.Next(1, _numTiles - _maxRoomSize - 1);
				int x = picker.Next(1, _numTiles - _maxRoomSize - 1);

				int height = picker.Next(_minRoomSize, _maxRoomSize + 1) + y;
				int width = picker.Next(_minRoomSize, _maxRoomSize + 1);

				for (; y < height; y++)
				{
					for (int j = x; j < x + width; j++)
					{
						if (picker.Next(0, 2) == 0)
						{
							if (y - 1 >= 1)
								_grid[y - 1][j].Type = "ground";
						}
						if (picker.Next(0, 2) == 0)
						{
							if (y+1 <= _numTiles-1)
								_grid[y + 1][j].Type = "ground";
						}
						_grid[y][j].Type = "ground";
					}
					x += picker.Next(-1, 2);
					if (x < 1) x = 1;
					else if (x > _numTiles - _maxRoomSize - 1) x = _numTiles - _maxRoomSize - 1;
					width = picker.Next(_minRoomSize, _maxRoomSize + 1);
				}
			}
		}
		private void GenerateMap()
		{
			_grid = new List<List<Tile>>();

			Point pos = new Point(0, 0);
			for (int j = 0; j < _numTiles; j++)
			{
				List<Tile> row = new List<Tile>();
				pos.X = 0;
				for (int i = 0; i < _numTiles; i++)
				{
					row.Add(new Tile(pos));
					pos.X += _pieceSize.Width;
				}
				pos.Y += _pieceSize.Height;
				_grid.Add(row);
			}

			GenerateRooms();

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

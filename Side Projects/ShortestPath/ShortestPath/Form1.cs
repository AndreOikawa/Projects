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
	public partial class Map : Form
	{
		private List<List<MapTile>> _tiles = new List<List<MapTile>>();
		private HashSet<MapTile> _startPosHash = new HashSet<MapTile>();
		private List<WeightedPoint> _startPos = new List<WeightedPoint>();
		private Point _endPos;
		private MapTile _currentTile;
		public Map()
		{
			InitializeComponent();
		}

		private void Update_Tick(object sender, EventArgs e)
		{
			try
			{
				WeightedPoint current = _startPos[0];
				_startPos.RemoveAt(0);
				if (_tiles[current.pos.Y][current.pos.X].stateSymbols[_tiles[current.pos.Y][current.pos.X].state] == ".")
					_tiles[current.pos.Y][current.pos.X].stateColours[_tiles[current.pos.Y][current.pos.X].state] = Color.AntiqueWhite;
				//_currentTile = _tiles[current.Y][current.X];
				//MapCanvas.Paint += new PaintEventHandler(DrawCurrent_Paint);
				MapCanvas.Refresh();
				if (AbsDist(current.pos, _endPos) == 0)
					Update.Stop();
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						try
						{
							WeightedPoint index = new WeightedPoint();
							index.pos = new Point(current.pos.X + i, current.pos.Y + j);
							index.weight = AbsDist(current.pos, _endPos) + AbsDist(index.pos, _endPos);

							MapTile validator = _tiles[index.pos.Y][index.pos.X];
							if (validator.stateSymbols[validator.state] != "x")
							{
								if (_startPosHash.Add(validator))
								{
									if (validator.stateSymbols[validator.state] == ".")
										validator.stateColours[validator.state] = Color.Aqua;
									MapCanvas.Refresh();
									SortInsert(index, 0, _startPos.Count - 1);
								}
							}
						}
						catch (Exception)
						{
						}
					}
				}
			}
			catch (Exception)
			{
				Update.Stop();
				MessageBox.Show("Path was not found");
				
			}

		}
		private void DrawCurrent_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			DrawIt(_currentTile.position, _currentTile.size, Color.Black, g);
		}
		private void SortInsert(WeightedPoint value, int min, int max)
		{
			if (min > max)
			{
				_startPos.Insert(min, value);
				return;
			}
			int mid = min + (max - min) / 2;
			double val = AbsDist(value.pos, _endPos);
			double arr = AbsDist(_startPos[mid].pos, _endPos);
			if (val > arr)
			{
				SortInsert(value, mid + 1, max);
			}
			else if (val < arr)
			{
				SortInsert(value, min, mid - 1);
			}
			else
			{
				if (_startPos[mid].weight <= value.weight)
					_startPos.Insert(mid + 1, value);
				else
					_startPos.Insert(mid, value);
			}
		}

		private double AbsDist(Point p1, Point p2)
		{
			double val = (Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
			return val;
		}

		private void Map_Load(object sender, EventArgs e)
		{
			string mapPath = AppDomain.CurrentDomain.BaseDirectory + "map.txt";
			string line;

			// Read the file and display it line by line.
			System.IO.StreamReader file =
			   new System.IO.StreamReader(mapPath);
			while ((line = file.ReadLine()) != null)
			{
				List<MapTile> row = new List<MapTile>();
				foreach (var tile in line)
				{
					row.Add(new MapTile(new Point(0, 0), new Size(0, 0), tile.ToString()));
				}
				_tiles.Add(row);
			}
			file.Close();

			int lenCol = _tiles.Count;
			int lenRow = _tiles[0].Count;
			for (int y = 0; y < lenCol; y++)
			{
				for (int x = 0; x < lenRow; x++)
				{
					if (_tiles[y][x].stateColours[_tiles[y][x].state] == Color.RosyBrown)
					{
						_startPosHash.Add(_tiles[y][x]);
						_startPos.Add(new WeightedPoint(new Point(x, y), 0));
					}
					else if (_tiles[y][x].stateColours[_tiles[y][x].state] == Color.GreenYellow)
					{
						_endPos = new Point(x, y);
					}
					_tiles[y][x].size = new Size(MapCanvas.Width / lenRow, MapCanvas.Height / lenCol);
					_tiles[y][x].position = new Point(x * _tiles[y][x].size.Width, y * _tiles[y][x].size.Height);
				}
			}
			MapCanvas.Paint += new PaintEventHandler(DrawAll_Paint);
			MapCanvas.Refresh();

		}
		private void DrawAll_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			foreach (var row in _tiles)
				foreach (var tile in row)
					DrawIt(tile.position, tile.size, tile.stateColours[tile.state], g);
		}
		private void DrawIt(Point pos, Size size, Color colour, Graphics g)
		{
			//System.Drawing.Graphics graphics = this.CreateGraphics();
			SolidBrush myBrush = new SolidBrush(colour);
			Pen myPen = new Pen(Color.Black, 1);

			Rectangle rectangle = new Rectangle(pos, size);

			g.FillRectangle(myBrush, rectangle);
			g.DrawRectangle(myPen, rectangle);

			myBrush.Dispose();
			myPen.Dispose();
		}
		private void Map_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		private void Return_Click(object sender, EventArgs e)
		{
			var frm = new Main();
			frm.Location = this.Location;
			frm.StartPosition = FormStartPosition.Manual;
			frm.FormClosing += delegate { this.Show(); };
			frm.Show();
			this.Hide();
		}
	}
}

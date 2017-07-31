using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPath
{
	public partial class CreateMap : Form
	{
		public int _width;
		public int _height;
		private List<List<MapTile>> _map = new List<List<MapTile>>();
		private MapTile _currentTile;
		public CreateMap()
		{
			InitializeComponent();
		}

		private void Done_Click(object sender, EventArgs e)
		{
			string mapPath = AppDomain.CurrentDomain.BaseDirectory + "map.txt";
			bool singleStart = true, singleEnd = true;

			StringBuilder map = new StringBuilder();
			foreach (var row in _map)
			{
				StringBuilder fileRow = new StringBuilder();
				foreach (var tile in row)
				{
					if (tile.state == 3)
					{
						if (singleStart)
							singleStart = false;
						else
						{
							MessageBox.Show("More than one ending position found. Ignoring other instances");
							tile.state = 1;
						}
					}
					else if (tile.state == 0)
					{
						if (singleEnd)
						{
							singleEnd = false;
						}
						else
						{
							MessageBox.Show("More than one starting position found. Ignoring other instances");
							tile.state = 1;
						}
					}
					fileRow.Append(tile.stateSymbols[tile.state]);
				}
				map.AppendLine(fileRow.ToString());
			}
			if (!singleEnd && !singleStart)
			{
				if (File.Exists(mapPath))
				{
					File.Delete(mapPath);
				}
				File.AppendAllText(mapPath, map.ToString());

				var frm = new Map();
				frm.Location = this.Location;
				frm.StartPosition = FormStartPosition.Manual;
				frm.FormClosing += delegate { this.Show(); };
				frm.Show();
				this.Hide();
			}
		}

		private void CreateMap_Load(object sender, EventArgs e)
		{
			int pictureHeight = Map.Height / _height;
			int pictureWidth = Map.Width / _width;

			for (int i = 0; i < _height; i++)
			{
				List<MapTile> row = new List<MapTile>();
				for (int j = 0; j < _width; j++)
				{
					MapTile tile = new MapTile(new Point(j * pictureWidth, i * pictureHeight), new Size(pictureWidth, pictureHeight));
					_currentTile = tile;
					row.Add(tile);
				}
				_map.Add(row);
			}
			Map.Paint += new PaintEventHandler(DrawAll_Paint);
			Map.Refresh();
		}
		private void DrawAll_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			foreach (var row in _map)
				foreach (var tile in row)
					DrawIt(tile.position, tile.size, tile.stateColours[tile.state], g);
		}

		private void DrawCurrent_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			DrawIt(_currentTile.position, _currentTile.size, _currentTile.stateColours[_currentTile.state], g);
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

		private void Map_MouseMove(object sender, MouseEventArgs e)
		{
			Done.Text = e.Location.ToString();
		}

		private void Map_Click(object sender, EventArgs e)
		{
			Point mouse = Map.PointToClient(Cursor.Position);
			int y = mouse.Y / (Map.Height / _height), x = mouse.X / (Map.Width / _width);
			this.Text = y + " " + x;

			_map[y][x].state = (_map[y][x].state + 1) % 4;
			_currentTile = _map[y][x];
			Map.Paint += new PaintEventHandler(DrawCurrent_Paint);
			Map.Refresh();
		}

		private void Back_Click(object sender, EventArgs e)
		{
			var frm = new Main();
			frm.Location = this.Location;
			frm.StartPosition = FormStartPosition.Manual;
			frm.FormClosing += delegate { this.Show(); };
			frm.Show();
			this.Hide();
		}

		private void CreateMap_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}
	}
}

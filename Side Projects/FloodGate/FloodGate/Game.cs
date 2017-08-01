using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloodGate
{
    public partial class Game : Form
    {
        public int _numColors, _fieldSize;
        private List<List<Tile>> _field;
        private List<Tile> _update;
        private List<Color> _pallete;
        private void NewColor(Random rng)
        {
            Color a = Color.FromArgb(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
            Color black = Color.Black;

            int aVal = a.R + a.B + a.G;
            int blackVal = black.R + black.G + black.B;


            if (_pallete.Count == 0)
            {
                _pallete.Add(a);
                return;
            }
            while (true)
            {
                aVal = a.R + a.B + a.G;
                bool diff = false;
                foreach (Color b in _pallete)
                {
                    int bVal = b.R + b.B + b.G;
                    if (Math.Abs(aVal - bVal) > 300 || Math.Abs(a.R - b.R) > 100 || Math.Abs(a.B - b.B) > 100 || Math.Abs(a.G - b.G) > 100)
                    {
                        if (Math.Abs(aVal - blackVal) > 300 || Math.Abs(a.R - black.R) > 100 || Math.Abs(a.B - black.B) > 100 || Math.Abs(a.G - black.G) > 100)
                        {
                            diff = true;
                        }
                        else
                        {
                            diff = false;
                            break;
                        }

                    }
                    else { diff = false; break; }
                }
                if (diff)
                {
                    _pallete.Add(a);
                    return;
                }

                a = Color.FromArgb(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
            }
        }
        private void Game_Load(object sender, EventArgs e)
        {
            Random rng = new Random();
            _pallete = new List<Color>();
            for (int i = 0; i < _numColors; i++)
            {
                NewColor(rng);
            }

            _update = new List<Tile>();
            _field = new List<List<Tile>>();
            for (int y = 0; y < _fieldSize; y++)
            {
                List<Tile> row = new List<Tile>();
                for (int x = 0; x < _fieldSize; x++)
                {
                    Tile tile = new Tile();
                    tile.Position = new Point(x * picField.Width / _fieldSize, y * picField.Height / _fieldSize);
                    tile.Color = _pallete[rng.Next(0, _numColors)];
                    _update.Add(tile);
                    row.Add(tile);
                }
                _field.Add(row);
            }
            picPickColor.Paint += new PaintEventHandler(PickColors_Paint);
            picField.Paint += new PaintEventHandler(UpdateTiles_Paint);
            picField.Paint += new PaintEventHandler(CenterTile_Paint);
        }

        public Game()
        {
            InitializeComponent();
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
        private void UpdateTiles_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            foreach (var part in _update)
                DrawIt(part.Position, new Size(picField.Size.Width / _fieldSize, picField.Size.Height / _fieldSize), part.Color, g);
        }
        private void PickColors_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int y = 0;
            foreach (var color in _pallete)
            {
                DrawIt(new Point(0, y * picPickColor.Height / _numColors), new Size(picPickColor.Width, picPickColor.Height / _numColors), color, g);
                y++;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Point mouse = picPickColor.PointToClient(Cursor.Position);
            int y = mouse.Y / (picPickColor.Height / _numColors);
            //_update = new List<Tile>();
            PaintField(_pallete[y], _fieldSize / 2, _fieldSize / 2);
            picField.Refresh();
            bool done = true;
            Color prev = Color.Black;
            foreach (var row in _field)
            {
                foreach (var tile in row)
                {
                    if (prev == Color.Black)
                        prev = tile.Color;
                    else if (prev != tile.Color)
                    {
                        done = false;
                        break;
                    }
                }
                if (!done)
                    break;
            }
            if (done)
            {
                MessageBox.Show("You win");
            }
            //string b = "";
            //foreach (Color a in _pallete)
            //{
            //    b += $"({a.R},{a.G},{a.B}) ";
            //}
            //MessageBox.Show(b);
        }

        private void CenterTile_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var part = _field[_fieldSize / 2][_fieldSize / 2];
            DrawIt(new Point(part.Position.X - 5, part.Position.Y - 5), new Size(picField.Size.Width / _fieldSize + 10, picField.Size.Height / _fieldSize + 10), Color.Black, g);
            DrawIt(part.Position, new Size(picField.Size.Width / _fieldSize, picField.Size.Height / _fieldSize), part.Color, g);
        }

        private void PaintField(Color newColor, int y, int x)
        {
            var currColor = _field[y][x].Color;
            if (newColor == currColor) return;
            _field[y][x].Color = newColor;
            //_update.Add(_field[y][x]);
            for (int adjacent = -1; adjacent <= 1; adjacent += 2)
            {
                try
                {
                    if (_field[y][x + adjacent].Color == currColor)
                    {
                        //_field[y][x + adjacent].Color = newColor;
                        //_update.Add(_field[y][x + adjacent]);
                        PaintField(newColor, y, x + adjacent);
                    }
                }
                catch (Exception) { }
                try
                {
                    if (_field[y + adjacent][x].Color == currColor)
                    {
                        //_field[y + adjacent][x].Color = newColor;
                        //_update.Add(_field[y + adjacent][x]);
                        PaintField(newColor, y + adjacent, x);
                    }
                }
                catch (Exception) { }
            }
        }
    }
}

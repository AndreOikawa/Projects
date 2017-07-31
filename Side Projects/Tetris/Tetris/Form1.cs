using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Pieces;

namespace Tetris
{
	public partial class Tetris : Form
	{
		private int _numPiecesX = 10, _numPiecesY = 20;
		private Size _pieceSize;
		private List<List<Piece>> _field = new List<List<Piece>>();
		private List<Piece> _toPaint = new List<Piece>();
		private PremadePiece _currentPiece;
		public Tetris()
		{
			InitializeComponent();
		}


		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{

		}
		private bool VerticalCollision()
		{
			List<Piece> toCheck = _currentPiece.LowestPart();
			foreach (Piece piece in toCheck)
			{
				try
				{
					if (_field[piece.Position.Y + 1][piece.Position.X + 1].colour != Color.Transparent)
					{
						if (piece.Position.Y == 0)
						{
							gameTick.Stop();
							MessageBox.Show("Game Over");
						}
						return true;
					}
				}
				catch (Exception)
				{
					if (piece.Position.X < 0 || piece.Position.Y < 0)
					{
						
					}
					else
						return true;
				}
			}
			return false;
		}
		private void gameTick_Tick(object sender, EventArgs e)
		{
			if (!VerticalCollision())
			{
				foreach (var row in _currentPiece.configuration)
					foreach (var piece in row)
						if (piece.colour != Color.Transparent)
							try
							{
								_field[piece.Position.Y][piece.Position.X].colour = Color.Transparent;
							}
							catch (Exception) { }
				_currentPiece.Move(0, 1);
				fieldPb.Refresh();
			}
			else
			{
				foreach (var row in _currentPiece.configuration)
				{
					foreach (Piece piece in row)
					{
						_toPaint.Add(piece);
					}
				}
				//fieldPb.Paint += new PaintEventHandler(FieldStationaryPieces_Paint);
				//fieldPb.Refresh();
				//foreach (var row in _currentPiece.configuration)
				//{
				//	foreach (var piece in row)
				//	{
				//		if (piece.colour != Color.Transparent)
				//		{
				//			_field[piece.Position.Y][piece.Position.X].colour = piece.colour;
				//		}
				//	}
				//}
				_currentPiece = new Square(new Point(_numPiecesX / 2, 0));
			}
		}

		private void pauseResumeBtn_Click(object sender, EventArgs e)
		{
			_currentPiece = new Square(new Point(_numPiecesX / 2, 0));
			fieldPb.Paint += new PaintEventHandler(FieldMovingPiece_Paint);
			fieldPb.Paint += new PaintEventHandler(FieldGrid_Paint);

			fieldPb.Refresh();
			if (gameTick.Enabled)
			{
				gameTick.Stop();
				pauseResumeBtn.Text = "Resume";
			}
			else
			{
				gameTick.Start();
				pauseResumeBtn.Text = "Pause";
			}
		}

		private void Tetris_Load(object sender, EventArgs e)
		{

			_pieceSize = new Size(fieldPb.Width / _numPiecesX, fieldPb.Height / _numPiecesY);
			
			fieldPb.Paint += new PaintEventHandler(FieldStationaryPieces_Paint);
			fieldPb.Paint += new PaintEventHandler(FieldGrid_Paint);
			nextPiecePb.Paint += new PaintEventHandler(NextPieceGrid_Paint);
			for (int y = 0; y < _numPiecesY; y++)
			{
				List<Piece> row = new List<Piece>();
				for (int x = 0; x < _numPiecesX; x++)
				{
					row.Add(new Piece(new Point(x, y), Color.Transparent));
				}
				_field.Add(row);
			}
			fieldPb.Refresh();
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
		private void DrawLine(Point begin, Point end, Color colour, Graphics g)
		{
			//System.Drawing.Graphics graphics = this.CreateGraphics();
			Pen myPen = new Pen(Color.Black, 1);
			g.DrawLine(myPen, begin, end);
			myPen.Dispose();
		}
		private void FieldStationaryPieces_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			foreach (var part in _toPaint)
				DrawIt(new Point(part.Position.X * _pieceSize.Width, part.Position.Y * _pieceSize.Height), _pieceSize, part.colour, g);

		}
		private void FieldMovingPiece_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			foreach (var row in _currentPiece.configuration)
			{
				foreach (var part in row)
					try
					{
						if (part.colour != Color.Transparent)
						{
							_field[part.Position.Y][part.Position.X].colour = part.colour;
							DrawIt(new Point(part.Position.X * _pieceSize.Width, part.Position.Y * _pieceSize.Height), _pieceSize, part.colour, g);
						}
					}
					catch (Exception) { }
			}

		}
		private void FieldGrid_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			for (int x = _pieceSize.Width; x <= fieldPb.Width; x += _pieceSize.Width)
				DrawLine(new Point(x, 0), new Point(x, fieldPb.Height), Color.Gray, g);
			for (int y = _pieceSize.Height; y <= fieldPb.Height; y += _pieceSize.Height)
				DrawLine(new Point(0, y), new Point(fieldPb.Width, y), Color.Gray, g);

		}
		private void NextPieceGrid_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			for (int x = _pieceSize.Width; x <= nextPiecePb.Width; x += _pieceSize.Width)
				DrawLine(new Point(x, 0), new Point(x, nextPiecePb.Height), Color.Gray, g);
			for (int y = _pieceSize.Height; y <= nextPiecePb.Height; y += _pieceSize.Height)
				DrawLine(new Point(0, y), new Point(nextPiecePb.Width, y), Color.Gray, g);
		}

	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Pieces
{
	class Piece
	{
		public Point Position { get; set; }
		public Color colour { get; set; }

		public Piece(Point pos, Color c)
		{
			Position = pos;
			colour = c;
		}
	}
}

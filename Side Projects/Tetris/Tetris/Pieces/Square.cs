using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Pieces
{
	class Square : PremadePiece
	{
		/* * * *
		 * x x *
		 * x x *
		 * * * */
		public Square(Point pos)
		{
			pos.X -= 1;
			pos.Y -= 2;
			for (int y = 0; y < 4; y++)
			{
				List<Piece> row = new List<Piece>();
				for (int x = 0; x < 4; x++)
				{
					if ((y == 1 || y == 2) && (x == 1 || x == 2))
					{
						row.Add(new Piece(new Point(pos.X + x, pos.Y + y), Color.Gold));
					}
					else
					{
						row.Add(new Piece(new Point(pos.X + x, pos.Y + y), Color.Transparent));
					}
				}
				configuration.Add(row);

			}
		}
	}
}

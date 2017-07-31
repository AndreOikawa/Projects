using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Pieces
{
	class PremadePiece
	{
		public List<List<Piece>> configuration = new List<List<Piece>>();
		public void Move(int x, int y)
		{
			foreach (var row in configuration)
				foreach (var part in row)
					part.Position = new Point(part.Position.X + x, part.Position.Y + y);
		}
		public List<Piece> LowestPart()
		{
			List<Piece> val = new List<Piece>();
			int numRows = configuration.Count;
			int numCols = configuration[0].Count;
			for (int x = 0; x < numCols; x++)
			{
				for (int y = numRows - 1; y >=0; y--)
				{
					if (configuration[y][x].colour != Color.Transparent)
					{
						val.Add(configuration[y][x]);
						break;
					}
				}
			}
			return val;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
	class MapTile
	{
		public Point position;
		public int state;
		public Size size;
		public List<Color> stateColours = new List<Color>(new Color[] { Color.GreenYellow, Color.White, Color.Gray, Color.RosyBrown });
		public List<string> stateSymbols = new List<string>(new string[] { "!", ".", "x", "?" });
		public MapTile(Point pos, Size s)
		{
			state = 1;
			position = pos;
			size = s;
		}
		public MapTile(Point pos, Size s, string type)
		{
			position = pos;
			size = s;
			state = stateSymbols.IndexOf(type);
		}
	}
}

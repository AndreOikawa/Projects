using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator
{
	public class Tile
	{
		public Dictionary<char, Color> colorMapping = new Dictionary<char, Color>();
		public Dictionary<string, char> typeMapping = new Dictionary<string,char>();
		public string Type { get; set; }
		public Point Position { get; set; }

		public Tile(Point pos)
		{
			
			colorMapping.Add('.', Color.White);
			typeMapping.Add("ground", '.');
			colorMapping.Add(' ', Color.Black);
			typeMapping.Add("void", ' ');
			colorMapping.Add('#', Color.LightGoldenrodYellow);
			typeMapping.Add("passage", '#');
			colorMapping.Add('X', Color.DimGray); 
			typeMapping.Add("wall",'X');

			Type = "void";
			Position = pos;
		}
	}
}

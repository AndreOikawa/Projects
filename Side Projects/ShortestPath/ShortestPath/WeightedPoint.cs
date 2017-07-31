using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
	class WeightedPoint
	{
		public Point pos;
		public double weight;
		public WeightedPoint() { }
		public WeightedPoint(Point p, double w)
		{
			pos = p;
			weight = w;
		}
	}
}

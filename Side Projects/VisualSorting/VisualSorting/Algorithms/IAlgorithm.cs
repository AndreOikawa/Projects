using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualSorting.Algorithms
{
	interface IAlgorithm
	{
		int Sort(List<int> array);
		string Name();
	}
}

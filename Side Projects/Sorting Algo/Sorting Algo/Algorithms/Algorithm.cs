using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algo
{
	interface Algorithm
	{
		int Sort(List<int> array);
		string Name();
	}
}

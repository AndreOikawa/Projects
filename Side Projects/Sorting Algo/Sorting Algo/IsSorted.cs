using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algo
{
	class IsSorted
	{
		public static bool CheckSorted(List<int> array, ref int comparisons)
		{
			int len = array.Count - 1;
			for (int i = 0; i < len; i++)
			{
				comparisons++;
				if (array[i] > array[i + 1]) return false;
			}
			return true;
		}
	}
}

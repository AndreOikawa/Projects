using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algo.Algorithms
{
	class BogoSort : Algorithm
	{
		public string Name()
		{
			return "BogoSort";
		}

		public int Sort(List<int> array)
		{
			int comparisons = 0;
			Random rng = new Random();
			int len = array.Count;
			while (!IsSorted.CheckSorted(array, ref comparisons))
			{
				for (int x = 0; x < len; x++)
				{
					int i = rng.Next(len);
					int j = rng.Next(len);
					Swap(ref array, i, j);
				}
			}
			return comparisons;
		}

		private void Swap(ref List<int> array, int i, int j)
		{
			int temp = array[i];
			array[i] = array[j];
			array[j] = temp;
		}
	}
}

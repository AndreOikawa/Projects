using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algo
{
	class SelectionSort: Algorithm
	{
		public string Name() { return "SelectionSort"; }
		public int Sort(List<int> array)
		{
			int comparisons = 0;
			int len = array.Count;

			for (int i = 0; i < len - 1; i++)
			{
				int min = array[i];
				int index = i;
				for (int j = i + 1; j < len; j++)
				{
					comparisons++;
					if (array[j] < min)
					{
						min = array[j];
						index = j;
					}
				}
				array[index] = array[i];
				array[i] = min;
			}
			//Console.WriteLine($"SelectionSort sorted array: {String.Join(" ", array)}");
			return comparisons;
		}
	}
}

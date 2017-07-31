using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algo
{
	class BubbleSort : Algorithm
	{
		public string Name() { return "BubbleSort"; }
		public int Sort(List<int> array)
		{
			int comparisons = 0;
			int len = array.Count;
			bool changed = true;
			while (len > 1 && changed)
			{
				changed = false;
				len--;
				for (int i = 0; i < len; i++)
				{
					++comparisons;
					if (array[i] > array[i + 1])
					{
						changed = true;
						int temp = array[i];
						array[i] = array[i + 1];
						array[i + 1] = temp;
					}

				}
			}
			//Console.WriteLine($"BubbleSort sorted array: {String.Join(" ", array)}");
			return comparisons;
		}


	}
}

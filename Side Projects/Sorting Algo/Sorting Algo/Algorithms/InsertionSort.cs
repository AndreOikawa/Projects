using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algo
{
	class InsertionSort : Algorithm
	{
		public string Name() { return "InsertionSort"; }
		public int Sort(List<int> array)
		{
			int comparisons = 0;
			int len = array.Count;
			List<int> final = new List<int>();
			final.Add(array[0]);
			for (int i = 1; i < len; i++)
			{
				int finalLen = final.Count - 1;
				for (; finalLen >= 0; finalLen--)
				{
					comparisons++;
					if (array[i] > final[finalLen])
					{
						final.Insert(finalLen + 1, array[i]);
						break;
					}
					else if (finalLen == 0)
					{
						final.Insert(0, array[i]);
					}
				}
			}
			//Console.WriteLine($"Insertion sorted array: {String.Join(" ", array)}");
			return comparisons;
		}
	}
}

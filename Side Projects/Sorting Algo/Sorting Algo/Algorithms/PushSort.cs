using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algo.Algorithms
{
	class PushSort : Algorithm
	{
		public string Name()
		{
			return "PushSort";
		}

		public int Sort(List<int> array)
		{
			int comparisons = 0, max = array.Count;
			while (!IsSorted.CheckSorted(array, ref comparisons))
			{
				int val = array[0];
				int index = -1;
				for (int i = 1; i < max; i++)
				{
					comparisons++;
					if (val < array[i])
					{
						val = array[i];
					}
					else
					{
						index = i - 1;
						Swap(ref array, i - 1, i);
						break;
					}
				}
				if (index >= 0)
				{
					val = array[index];
					index--;
					for (; index >= 0; index--)
					{
						comparisons++;
						if (val > array[index])
						{
							val = array[index];

						}
						else
						{
							Swap(ref array, index + 1, index);
							break;
						}
					}
				}
			}
			//Console.WriteLine(String.Join(" ", array));
			return comparisons;
		}

		private void Swap(ref List<int> array, int i, int j)
		{
			//List<int> before = new List<int>(array);
			int temp = array[i];
			array[i] = array[j];
			array[j] = temp;
			//Console.WriteLine($"Before: {String.Join(" ", before)} After: {String.Join(" ", array)}");
		}
	}
}

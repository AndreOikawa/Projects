using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algo.Algorithms
{
	class QuickSort : Algorithm
	{
		public string Name()
		{
			return "QuickSort";
		}

		public int Sort(List<int> array)
		{
			int comparisons = 0;
			List<int> sorted = Partition(array, ref comparisons);
			//Console.WriteLine($"{String.Join(" ", sorted)}, Count: {sorted.Count}");
			//if (!IsSorted.CheckSorted(sorted)) comparisons = -1;
			return comparisons;
		}
		private List<int> Partition(List<int> copy, ref int comparisons)
		{
			List<int> array = new List<int>(copy);
			if (array.Count == 1) return array;
			else if (array.Count == 0) return new List<int>();
			int index = 1, more = array.Count;
			Random rng = new Random();
			int pivot = rng.Next(more);
			//int pivot = 0;
			more--;
			Swap(ref array, 0, pivot);
			while (index < more)
			{
				comparisons++;
				while (array[index] <= array[0])
				{
					comparisons++;
					index++;
					if (index == array.Count - 1)
					{
						break;
					}
				}
				if (index < more)
				{
					comparisons++;
					while (array[more] > array[0])
					{
						comparisons++;
						more--;
						if (more == 0)
						{
							break;
						}
					}
				}
				if (index < more)
				{
					Swap(ref array, index, more);
					index++;
					more--;
				}
			}
			Swap(ref array, 0, more);
			List<int> final = Partition(new List<int>(array.Take(more)), ref comparisons);
			final.Add(array[more]);
			array.RemoveRange(0, more + 1);
			final.AddRange(Partition(array, ref comparisons));
			return final;
		}
		private void Swap(ref List<int> array, int i, int j)
		{
			int temp = array[i];
			array[i] = array[j];
			array[j] = temp;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algo
{
	class HeapSort : Algorithm
	{
		public string Name()
		{
			return "HeapSort";
		}

		public int Sort(List<int> array)
		{
			int comparisons = 0;
			var heap = Heapify(array, ref comparisons);
			//Console.WriteLine($"Heap {String.Join(" ", heap)}, Size: {heap.Count}");
			var sorted = SiftDown(heap, ref comparisons);
			//Console.WriteLine($"Sorted {String.Join(" ", sorted)}, Size: {sorted.Count}");
			//if (IsSorted.CheckSorted(sorted))
			//	Console.WriteLine("Sorted");
			return comparisons;
		}

		private List<int> SiftDown(List<int> array, ref int comparisons)
		{
			int len = array.Count - 1;
			while (len > 0)
			{
				Swap(ref array, 0, len);
				len--;
				int tempIndex = 0;
				while (tempIndex < len)
				{

					if (tempIndex * 2 + 2 <= len)
					{
						comparisons += 2;
						if (array[tempIndex * 2 + 1] > array[tempIndex * 2 + 2])
						{
							if (array[tempIndex * 2 + 1] > array[tempIndex])
							{
								Swap(ref array, tempIndex * 2 + 1, tempIndex);
								tempIndex = tempIndex * 2 + 1;
							}
							else break;
						}
						else if (array[tempIndex * 2 + 2] > array[tempIndex])
						{
							Swap(ref array, tempIndex * 2 + 2, tempIndex);
							tempIndex = tempIndex * 2 + 1;
						}
						else break;

					}
					else if (tempIndex * 2 + 1 <= len)
					{
						comparisons++;
						if (array[tempIndex * 2 + 1] > array[tempIndex])
						{
							Swap(ref array, tempIndex * 2 + 1, tempIndex);
							tempIndex = tempIndex * 2 + 1;
						}
						else break;
					}
					else break;
				}

			}
			return array;
		}
		private void Swap(ref List<int> array, int lIndex, int rIndex)
		{
			int temp = array[lIndex];
			array[lIndex] = array[rIndex];
			array[rIndex] = temp;
		}
		private List<int> Heapify(List<int> array, ref int comparisons)
		{
			List<int> heap = new List<int>();
			int len = array.Count;
			for (int i = 0; i < len; i++)
			{
				heap.Add(array[i]);
				int index = heap.Count - 1;
				while (index > 0)
				{
					comparisons++;
					if (heap[index] > heap[(index - 1) / 2])
					{
						Swap(ref heap, (index - 1) / 2, index);
						index = (index - 1) / 2;
					}
					else break;

				}
			}
			return heap;
		}
	}
}

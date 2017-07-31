using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algo
{
	class MergeSort: Algorithm
	{
		public string Name() { return "MergeSort"; }

		public int Sort(List<int> array)
		{
			int comparisons = 0;
			List<int> copy = Merge(new List<int>(array), ref comparisons);
			//Console.WriteLine($"BubbleSort sorted array: {String.Join(" ", copy)}");
			return comparisons;
		}
		private List<int> Merge(List<int> copy, ref int comparison)
		{
			List<int> array = new List<int>(copy);
			int len = array.Count;
			if (len == 1) return array;
			List<int> left = Merge(new List<int>(array.Take(len / 2)), ref comparison);
			array.RemoveRange(0, len / 2);
			List<int> right = Merge(new List<int>(array), ref comparison);
			List<int> final = new List<int>();
			int l = 0, r = 0, lCount = left.Count, rCount = right.Count;
			while (l < lCount && r < rCount)
			{
				comparison++;
				if (left[l] < right[r])
				{
					final.Add(left[l]);
					l++;
				}
				else
				{
					final.Add(right[r]);
					r++;
				}
			}
			if (l == lCount)
			{
				right.RemoveRange(0, r);
				final.AddRange(right);
			}
			else
			{
				left.RemoveRange(0, l);
				final.AddRange(left);
			}
			return final;
		}
	}

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algo.Algorithms
{
	class RadixSort : Algorithm
	{
		public string Name()
		{
			return "RadixSort";
		}

		public int Sort(List<int> array)
		{
			int comparisons = 0;
			int len = array.Count;


			List<int> end = new List<int>(array);
			bool changed = true;
			int digit = 1;

			while (changed)
			{
				changed = false;
				List<int> final = new List<int>();
				List<List<int>> digits = new List<List<int>>();
				for (int i = 0; i <= 9; i++)
				{
					digits.Add(new List<int>());
				}

				for (int i = 0; i < len; i++)
				{
					comparisons++;
					digits[(end[i] / digit) % 10].Add(end[i]);
				}

				for (int i = 0; i <= 9; i++)
				{
					final.AddRange(digits[i]);
				}

				end = new List<int>(final);
				digit *= 10;
				if (digits[0].Count != len)
					changed = true;
			}
			//List<int> check = new List<int>();
			//foreach (var val in end)
			//{
			//	check.Add(Convert.ToInt32(val));
			//}
			//Console.WriteLine(IsSorted.CheckSorted(check));
			//Console.WriteLine(String.Join(" ", end));
			return comparisons;
		}
	}
}

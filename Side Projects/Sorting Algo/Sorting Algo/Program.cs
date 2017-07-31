using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algo.Algorithms;

namespace Sorting_Algo
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Algorithm> algorithms = new List<Algorithm>();
			algorithms.Add(new BubbleSort());
			algorithms.Add(new SelectionSort());
			//algorithms.Add(new MergeSort());
			algorithms.Add(new InsertionSort());
			//algorithms.Add(new HeapSort());
			//algorithms.Add(new RadixSort());
			//algorithms.Add(new QuickSort());
			algorithms.Add(new PushSort());
			//algorithms.Add(new BogoSort());

			List<int> array = new List<int>();
			int max = 100;
			for (int i = 1; i <= max; i++)
			{
				array.Add(i);
			}

			Stopwatch timer = new Stopwatch();
			Console.WriteLine($"Sorted List:");
			foreach (var algorithm in algorithms)
			{
				timer.Start();
				Console.WriteLine($"{algorithm.Name()}: {algorithm.Sort(new List<int>(array))}");
				timer.Stop();
				//Console.WriteLine(timer.ElapsedMilliseconds);
				timer.Reset();
			}

			List<int> almostSorted = new List<int>(array);
			int temp = almostSorted[0];
			almostSorted[0] = almostSorted[almostSorted.Count - 1];
			almostSorted[almostSorted.Count - 1] = temp;

			Console.WriteLine();
			Console.WriteLine($"Almost sorted List:");
			foreach (var algorithm in algorithms)
			{
				timer.Start();
				Console.WriteLine($"{algorithm.Name()}: {algorithm.Sort(new List<int>(almostSorted))}");
				timer.Stop();
				//Console.WriteLine(timer.ElapsedMilliseconds);
				timer.Reset();
			}

			array.Reverse();

			Console.WriteLine();
			Console.WriteLine($"Reversed List:");
			foreach (var algorithm in algorithms)
			{
				timer.Start();
				Console.WriteLine($"{algorithm.Name()}: {algorithm.Sort(new List<int>(array))}");
				timer.Stop();
				//Console.WriteLine(timer.ElapsedMilliseconds);
				timer.Reset();
			}

			var random = array.OrderBy(a => Guid.NewGuid()).ToList();

			Console.WriteLine();
			Console.WriteLine($"Random List:");
			foreach (var algorithm in algorithms)
			{
				timer.Start();
				Console.WriteLine($"{algorithm.Name()}: {algorithm.Sort(new List<int>(array))}");
				timer.Stop();
				//Console.WriteLine(timer.ElapsedMilliseconds);
				timer.Reset();
			}

			Console.ReadKey();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorFlood
{
	class Program
	{
		static int _len = 5;
		static int _numColors = 4;
		static bool _singleColor = false;
		static void Main(string[] args)
		{
			Console.WriteLine("Input Grid Size (wrong input will default to 5)");
			try
			{
				_len = Convert.ToInt32(Console.ReadLine());
			}
			catch (Exception) { }

			Console.WriteLine("Input Number of Colors (wrong input will default to 4)");
			try
			{
				_numColors = Convert.ToInt32(Console.ReadLine());
			}
			catch (Exception) { }


			int steps = 0;
			Random rng = new Random();
			List<List<int>> grid = new List<List<int>>();
			for (int i = 0; i < _len; i++)
			{
				List<int> row = new List<int>();
				for (int j = 0; j < _len; j++)
				{
					row.Add(rng.Next(_numColors));
				}
				grid.Add(row);
			}
			PrintGrid(grid);
			while (!_singleColor)
			{
				var input = 0;
				Console.WriteLine($"Change Middle Color to: [{0}-{_numColors - 1}]");
				try
				{
					input = Convert.ToInt16(Console.ReadLine());
				}
				catch (Exception) { continue; }
				if (input < _numColors && input >= 0)
				{
					PaintGrid(ref grid, _len / 2, _len / 2, input, grid[_len / 2][_len / 2]);
					steps++;
				}
				PrintGrid(grid);
			}
			Console.WriteLine($"You won in {steps} steps");
			Console.ReadKey();

		}
		static void PaintGrid(ref List<List<int>> grid, int y, int x, int newColor, int currColor)
		{
			if (newColor == currColor) return;
			grid[y][x] = newColor;
			for (int adjacent = -1; adjacent <= 1; adjacent += 2)
			{
				try
				{
					if (grid[y][x + adjacent] == currColor)
					{
						grid[y][x + adjacent] = newColor;
						PaintGrid(ref grid, y, x + adjacent, newColor, currColor);
					}
				}
				catch (Exception) { }
				try
				{
					if (grid[y + adjacent][x] == currColor)
					{
						grid[y + adjacent][x] = newColor;
						PaintGrid(ref grid, y + adjacent, x, newColor, currColor);
					}
				}
				catch (Exception) { }
			}
		}
		static void PrintGrid(List<List<int>> grid)
		{
			int prevColor = -1;
			_singleColor = true;
			foreach (List<int> row in grid)
			{
				foreach (int value in row)
				{
					if (prevColor == -1)
						prevColor = value;
					else if (prevColor != value)
						_singleColor = false;

					Console.Write(value + " ");
				}
				Console.WriteLine();
			}
		}
	}
}

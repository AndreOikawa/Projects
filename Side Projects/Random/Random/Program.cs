using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
	class Program
	{
		static void Main(string[] args)
		{
			int x = 1;
			int y = 4;

			var a = Convert.ToString(x ^ y,2);
			Console.WriteLine(a);
			Console.ReadLine();
		}
	}
}

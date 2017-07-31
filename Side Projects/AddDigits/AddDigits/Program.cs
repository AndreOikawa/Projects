using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddDigits
{
	class Program
	{
		static void Main(string[] args)
		{
			int num = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine(Add(num));
			Console.ReadKey();
		}

		private static int Add(int num)
		{
			string parse = Convert.ToString(num);
			int len = parse.Length;
			int sum = 0;
			for (int i = 0; i < len; i++)
			{
				sum += Convert.ToInt32(Convert.ToString(parse[i]));
				if (Convert.ToString(sum).Length == 2)
					sum = Add(sum);
			}

			return sum;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Int32> Count = new List<int>();
            

            for (int i = 0; i < 10000; i++)
            {
                Count.Add(i);
            }

            for (int n = 0;n < 5; n++)
            {
                Console.WriteLine(n);
                List<Int32> lst1 = new List<Int32>();
                List<Int32> lst2 = new List<Int32>();

                Stopwatch sw = new Stopwatch();
                int max = Count.Count;
                sw.Start();
                for (int i = 0; i < max; i++)
                {
                    lst1.Add(Count[i]);
                }
                sw.Stop();

                Console.WriteLine("For Loop :- " + sw.ElapsedTicks);
                sw.Restart();

                foreach (int a in Count)
                {
                    lst2.Add(a);
                }
                sw.Stop();
                Console.WriteLine("Foreach Loop:- " + sw.ElapsedTicks);
            }
            
            Console.ReadLine();

        }
    }
}

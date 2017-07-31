using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input Word");
                var input = Console.ReadLine();
                input = input.Replace(" ", "");
                bool palindrome = true;
                for (int i = 0; i <= input.Length / 2; i++)
                {
                    if (input[i] != input[input.Length - 1 - i])
                    {
                        palindrome = false;
                        Console.WriteLine("Not palindrome");
                        break;
                    }
                }
                if (palindrome) Console.WriteLine("Palindrome");
            }
            
            
        }
    }
}

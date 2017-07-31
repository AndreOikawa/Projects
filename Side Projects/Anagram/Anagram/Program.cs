using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Write letters separated by commas");
                var input = Console.ReadLine();
                var letters = input.Split(new char[] { ',' });
                List<string> anagrams = new List<string>();
                Permutations(letters.ToList<string>(), "", ref anagrams);
                foreach (var entry in anagrams)
                {
                    Console.WriteLine(entry);
                }
                Console.ReadKey();
            }

        }

        static void Permutations(List<string> letters, string value, ref List<string> output)
        {
            if (letters.Count > 0)
            {
                for (int i = 0; i < letters.Count; i++)
                {
                    List<string> newLetters = new List<string>(letters);
                    newLetters.RemoveAt(i);
                    Permutations(newLetters, value + letters[i], ref output);

                }
            }
            else
            {
                if (!output.Contains(value)) output.Add(value);
            }

        }
    }
}

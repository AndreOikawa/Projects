using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReverseString
{
	class Program
	{
		static Regex letters = new Regex($"[a-z]");
		static int lowercase = 'a', uppercase = 'A';

		static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("String to Cipher");
				string a = Console.ReadLine();
				Console.WriteLine("Key");
				int key = Convert.ToInt32(Console.ReadLine())%26;

				List<string> cipherList = new List<string>();

				foreach (string word in a.Split(' '))
				{
					cipherList.Add(Cipher(word, key));
				}
				string b = String.Join(" ", cipherList);
				Console.WriteLine(b);

				cipherList.Clear();

				foreach (string word in b.Split(' '))
				{
					cipherList.Add(Decipher(word, key));
				}
				b = String.Join(" ", cipherList);
				Console.WriteLine(b);
			}
			Console.ReadKey();
		}
		static string Cipher(string input, int key)
		{
			int b = input.Length;
			string output = "";
			for (int i = 0; i < b; i++)
			{
				int mod = 0;
				if (letters.Match(Convert.ToString(input[i])).Success)
				{
					mod = lowercase;
				}
				else
				{
					mod = uppercase;
				}
				char newChar = (char)(mod + ((input[i] + key - mod) % 26));
				output += Convert.ToString(newChar);
			}
			return output;
		}
		static string Decipher(string input, int key)
		{
			int b = input.Length;
			string output = "";
			key = 26 - key;
			for (int i = 0; i < b; i++)
			{
				int mod = 0;
				if (letters.Match(Convert.ToString(input[i])).Success)
				{
					mod = lowercase;
				}
				else
				{
					mod = uppercase;
				}
				char newChar = (char)(mod + ((input[i] + key - mod) % 26));
				output += Convert.ToString(newChar);
			}
			return output;
		}
	}
}

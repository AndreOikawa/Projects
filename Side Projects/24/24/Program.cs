using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _24
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> deck = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    deck.Add(j);
                }
            }
            Random picker = new Random();

            bool solved = false;
            Console.WriteLine("Write 'help' for more information");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (deck.Count > 0)
            {
                Console.WriteLine();
                List<double> cardsSelected = new List<double>();
                for (int i = 0; i < 4; i++)
                {
                    int pickCard = picker.Next(0, deck.Count);
                    cardsSelected.Add(deck[pickCard]);
                    deck.RemoveAt(pickCard);
                }
                List<double> roughWork = new List<double>(cardsSelected);
                Console.WriteLine("Deck has {0} cards", deck.Count);
                while (!solved)
                {
                    #region console out
                    Console.WriteLine("Cards:");
                    foreach (double card in roughWork)
                        Console.Write(card + " ");
                    Console.WriteLine();
                    
                    #endregion
                    string input = Regex.Replace(Console.ReadLine(), @"\s+", "");
                    Regex validateFormat = new Regex(@"^(\-?\d+\.?\d*(\+|\-|\*|\/|\^)\-?\d+\.?\d*|\d+!)$");
                    if (validateFormat.Match(input).Success)
                    {
                        var breakInput = input.ToCharArray();
                        int len = breakInput.Length;
                        int index = 0;
                        while (breakInput[index] != '+' && breakInput[index] != '-' && breakInput[index] != '/' && breakInput[index] != '*' && breakInput[index] != '!' && breakInput[index] != '^')
                        {
                            index++;
                        }
                        bool isFactorial = true;
                        List<string> op = new List<string>();
                        string buildLines = "";
                        for (int i = 0; i < index; i++)
                        {
                            buildLines += breakInput[i];
                        }
                        op.Add(buildLines);
                        op.Add(breakInput[index].ToString());
                        if (++index < len)
                        {
                            buildLines = "";
                            for (; index < len; index++)
                            {
                                buildLines += breakInput[index];
                            }
                            op.Add(buildLines);
                            isFactorial = false;
                        }
                        if (roughWork.Contains(Convert.ToDouble(op[0])))
                        {
                            roughWork.Remove(Convert.ToDouble(op[0]));
                            if (isFactorial)
                            {
                                roughWork.Add(factorial(Convert.ToInt32(op[0])));
                            }
                            else if (roughWork.Contains(Convert.ToDouble(op[2])))
                            {
                                roughWork.Remove(Convert.ToDouble(op[2]));
                                switch (op[1])
                                {
                                    case "+":
                                        roughWork.Add(Convert.ToDouble(op[0]) + Convert.ToDouble(op[2]));
                                        break;
                                    case "-":
                                        roughWork.Add(Convert.ToDouble(op[0]) - Convert.ToDouble(op[2]));
                                        break;
                                    case "*":
                                        roughWork.Add(Convert.ToDouble(op[0]) * Convert.ToDouble(op[2]));
                                        break;
                                    case "/":
                                        roughWork.Add(Convert.ToDouble(op[0]) / Convert.ToDouble(op[2]));
                                        break;
                                    case "^":
                                        roughWork.Add(Math.Pow(Convert.ToDouble(op[0]), Convert.ToDouble(op[2])));
                                        break;

                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("invalid");
                                roughWork.Add(Convert.ToDouble(op[0]));
                            }
                        }
                        else
                        {
                            Console.WriteLine("invalid");
                            continue;
                        }
                    }
                    else if (input == "reset")
                    {
                        roughWork = new List<double>(cardsSelected);
                    }
                    else if (input == "giveup")
                    {
                        foreach (var card in cardsSelected)
                            deck.Add(Convert.ToInt32(card));
                        break;
                    }
                    else if (input == "quit")
                    {
                        return;
                    }
                    else if (input == "help")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Give solution one step at a time");
                        Console.WriteLine("Examples: 1+1, 1!");
                        Console.WriteLine("Available operations: + - * / ! ^");
                        Console.WriteLine("Write 'reset' to restart hand");
                        Console.WriteLine("Write 'give up' to give up hand");
                        Console.WriteLine("Write 'quit' to quit");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("invalid");
                        continue;
                    }
                    if (roughWork.Count == 1 && Convert.ToInt32(roughWork[0]) == 24)
                    {
                        
                        break;
                    }


                }
            }
            timer.Stop();
            Console.WriteLine("Congrats you made it in {0}. Exiting...", timer.Elapsed);
            Console.ReadKey();
        }
        static double factorial(int n)
        {
            double result = 1;
            for (int i = n; i > 1; i--)
            {
                result *= i;
            }
            return result;
        }


    }
}

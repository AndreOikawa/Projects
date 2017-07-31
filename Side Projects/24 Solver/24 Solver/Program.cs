using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_Solver
{
    class Program
    {

        struct Double
        {
            public double val;
            public string composition;
            public Double(double _val, string _comp)
            {
                val = _val;
                composition = _comp;
            }
        }
        static void Main(string[] args)
        {
            var check = "";
            //int a = 1, b = 1, c = 1, d = 1;
            
            HashSet<string> allEntries = new HashSet<string>();
            while (check != "quit")
                //while (a <= 13 && b <= 13 && c <= 13 && d <= 14)
                {

                    //var nums = $"{a}, {b}, {c}, {d}";
                    //if (d == 14) { c++; d = 1; }
                    //if (c == 14) { b++; c = 1; }
                    //if (b == 14) { a++; b = 1; }

                    //List<int> vals = new List<int>();
                    //vals.Add(a);
                    //vals.Add(b);
                    //vals.Add(c);
                    //vals.Add(d);
                    //vals.Sort();

                    Console.WriteLine("Inputs separated by spaces");
                    check = Console.ReadLine();
                    var numbers = check.Split(' ');
                    List<Double> input = new List<Double>();
                    foreach (var number in numbers)
                    {
                        input.Add(new Double(Convert.ToDouble(number), number));
                    }
                    //input.Add(new Double(Convert.ToDouble(a), a.ToString()));
                    //input.Add(new Double(Convert.ToDouble(b), b.ToString()));
                    //input.Add(new Double(Convert.ToDouble(c), c.ToString()));
                    //input.Add(new Double(Convert.ToDouble(d), d.ToString()));
                    //var result = Recurse(new _24_Solver.Program.Double(), new _24_Solver.Program.Double(), "", input);
                    //if (result == "" && allEntries.Add(String.Join(", ", vals)))
                    //    Console.WriteLine(nums);
                    Console.WriteLine(Recurse(new _24_Solver.Program.Double(), new _24_Solver.Program.Double(), "", input));
                //d++;

                //Console.ReadKey();
            }
            Console.ReadKey();

        }

        static string Recurse(Double LHS, Double RHS, string op, List<Double> otherNum)
        {
            //Console.WriteLine(LHS.val + op + RHS.val);
            List<string> ops = new List<string>();
            ops.Add("+");
            ops.Add("-");
            ops.Add("/");
            ops.Add("*");
            ops.Add("^");

            Double result = new Double();
            if (op == "+")
            {
                result.val = LHS.val + RHS.val;
                result.composition = $"({LHS.composition} + {RHS.composition})";
            }
            else if (op == "-")
            {
                
                result.val = LHS.val - RHS.val;
                result.composition = $"({LHS.composition} - {RHS.composition})";
            }
            else if (op == "*")
            {
                result.val = LHS.val * RHS.val;
                result.composition = $"({LHS.composition} * {RHS.composition})";
            }
            else if (op == "/")
            {
                result.val = LHS.val / RHS.val;
                result.composition = $"({LHS.composition} / {RHS.composition})";
               
            }
            else if (op == "^")
            {
                result.val = Math.Pow(LHS.val, RHS.val);
                
                result.composition = $"({LHS.composition} ^ {RHS.composition})";
            }
            else if (op == "!")
            {
                result.val = Factorial(LHS.val);
                result.composition = $"{LHS.composition}!";
            }
            if (op != "")
                otherNum.Add(result);
            if (otherNum.Count == 1)
            {
                if (result.val == 24)
                    return result.composition;
                else if (result.val == 4)
                    return $"({result.composition})!";
            }
            else if (otherNum.Count != 1)
            {
                int count = otherNum.Count;
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {

                        if (j == i) continue;
                        foreach (var fn in ops)
                        {
                            if ((fn == "^" && otherNum[i].val < 15 && otherNum[j].val < 15) || fn != "^")
                            {
                                List<Double> temp = new List<Double>(otherNum);
                                temp.Remove(otherNum[i]);
                                temp.Remove(otherNum[j]);
                                var final = Recurse(otherNum[i], otherNum[j], fn, temp);

                                if (final != "")
                                {
                                    return final;
                                }
                            }
                            
                        }

                    }
                    if (otherNum[i].val > 2 && otherNum[i].val < 15)
                    {
                        List<Double> tempFact = new List<Double>(otherNum);
                        tempFact.RemoveAt(i);
                        var finalFact = Recurse(otherNum[i], new _24_Solver.Program.Double(), "!", tempFact);

                        if (finalFact != "")
                        {
                            return finalFact;
                        }
                    }

                }
            }
            return "";
        }

        static double Factorial(double val)
        {
            double result = 1;
            for (; val > 1; val--) result *= val;
            return result;
        }
    }
}

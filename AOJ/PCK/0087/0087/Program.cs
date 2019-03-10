using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0087
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                string[] items = line.Trim().Split(' ');
                Stack<double> st = new Stack<double>();

                foreach (var item in items)
                {
                    int res;
                    if (int.TryParse(item, out res)) st.Push(res);
                    else
                    {
                        double d2 = st.Pop();
                        double d1 = st.Pop();
                        switch (item)
                        {
                            case "+":
                                st.Push(d1 + d2);
                                break;
                            case "-":
                                st.Push(d1 - d2);
                                break;
                            case "*":
                                st.Push(d1 * d2);
                                break;
                            case "/":
                                st.Push(d1 / d2);
                                break;
                        }
                    }
                }
                Console.WriteLine(st.Pop());
            }
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}

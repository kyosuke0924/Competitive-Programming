using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0093
{
    public class Program

    {
        public static void Main(string[] args)
        {
            bool NotFirst = false;
            while (true)
            {

                int[] items = RIntAr();
                if (items.Sum() == 0) return;

                List<int> reapYear = new List<int>();
                for (int i = items[0] ; i <= items[1] ; i++)
                {
                    if (i % 400 == 0) reapYear.Add(i);
                    else if (i % 4 == 0 && i % 100 != 0) reapYear.Add(i);
                }

                if (NotFirst) Console.WriteLine("");
                else NotFirst = true;

                if (reapYear.Count() > 0)
                {
                    foreach (var item in reapYear)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("NA");
                }

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

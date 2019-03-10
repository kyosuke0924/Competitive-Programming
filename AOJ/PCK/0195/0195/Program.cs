using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0195
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] sales = new int[5];
                for (int i = 0 ; i < 5 ; i++)
                {
                    int[] items = RIntAr(); if (items.Sum() == 0) return;
                    sales[i] = items.Sum();
                }

                var res = sales.Select((x, i) => new { cnt = x, idx = i }).OrderByDescending(y => y.cnt).First();
                Console.WriteLine("{0} {1}", (char)(res.idx + 'A'), res.cnt);
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

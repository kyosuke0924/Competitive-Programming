using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0080
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                double q = RInt();
                if (q == -1) break;

                double x = q / 2;
                while (Math.Abs(Math.Pow(x, 3) - q) >= 0.00001*q)
                {
                    x = x - (Math.Pow(x, 3) - q) / (3 * Math.Pow(x, 2));
                }
                Console.WriteLine(x);
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

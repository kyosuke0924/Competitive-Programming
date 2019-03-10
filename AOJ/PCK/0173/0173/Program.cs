using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0173
{
    public class Program

    {
        public static void Main(string[] args)
        {
            for (int i = 0 ; i < 9 ; i++)
            {
                string[] items = RStAr();
                Console.WriteLine("{0} {1} {2}", items[0], int.Parse(items[1]) + int.Parse(items[2]), int.Parse(items[1]) * 200 + int.Parse(items[2]) * 300);
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

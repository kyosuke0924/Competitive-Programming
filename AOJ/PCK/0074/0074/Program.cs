using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0074
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] items = RIntAr();
                if (items.All(x => x == -1)) break;

                TimeSpan remaining = new TimeSpan(2, 0, 0) - new TimeSpan(items[0], items[1], items[2]);
                TimeSpan remaining_3 = new TimeSpan(remaining.Ticks * 3);

                Console.WriteLine(remaining.ToString((@"hh\:mm\:ss")));
                Console.WriteLine(remaining_3.ToString((@"hh\:mm\:ss")));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0073
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int x = RInt();
                int h = RInt();
                if (x + h == 0) break;

                double th = Math.Sqrt(Math.Pow(x / 2D, 2) + Math.Pow(h, 2D));
                Console.WriteLine(Math.Pow(x, 2D) + x * th * 2);
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

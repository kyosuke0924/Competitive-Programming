using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            long[] ab = RLongAr();
            long a = ab[0];
            long b = ab[1];

            if (a == b)
            {
                Console.WriteLine(a);
            }
            else
            {
                long res;
                if (a == 0)
                {
                    res = f(b);
                }
                else
                {
                    res = f(a - 1) ^ f(b);
                }

                Console.WriteLine(res);
            }

        }

        private static long f(long x)
        {

            if (x % 2 == 1)
            {
                return (((x + 1) / 2) % 2 == 0 ? 0 : 1);
            }
            else
            {
                return ((x / 2) % 2 == 0 ? 0 : 1) ^ x;
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

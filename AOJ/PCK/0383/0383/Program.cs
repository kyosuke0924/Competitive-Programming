using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0383
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vs = RArInt();
            int a = vs[0], b = vs[1], x = vs[2];

            int res = 0;
            if (2 * b <= a)
            {
                res = x / 500 * b;
                if (x % 500 > 0) res += b;
            }
            else
            {
                res = x / 1000 * a;
                int r = x % 1000;

                if (r > 500) res += a;
                else if (r > 0) res += Math.Min(a, b);
            }
            Console.WriteLine(res);
        }
        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RArSt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RArInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RArLong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RArDouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }
}

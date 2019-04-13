using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0229
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int[] vs = RArInt();
                if (vs.Sum() == 0) break;

                int b = vs[0]; int r = vs[1]; int g = vs[2]; int c = vs[3]; int s = vs[4]; int t = vs[5];

                int expense = (t - s - b * 5 - r * 3) * 3 + (b * 5 + r * 3) * 2;
                int income = (b * 5 + b) * 15 + (r * 3 + r) * 15 + g * 7 + c * 2;
                Console.WriteLine(100 - expense + income);
            }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nm = RArInt();
            int n = nm[0];
            int m = nm[1];

            int min = int.MinValue;
            int max = int.MaxValue;

            for (int i = 0; i < m; i++)
            {
                int[] vs = RArInt();
                min = Math.Max(min, vs[0]);
                max = Math.Min(max, vs[1]);
            }

            if (max - min >= 0)
            {
                Console.WriteLine(max - min + 1);
            }
            else
            {
                Console.WriteLine(0);
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

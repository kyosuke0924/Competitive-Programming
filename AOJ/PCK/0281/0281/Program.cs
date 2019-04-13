using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0281
{
    class Program
    {
        static void Main(string[] args)
        {
            int q = RInt();
            for (int i = 0; i < q; i++)
            {
                Console.WriteLine(CalcMaxCnt(RArInt()));
            }
        }

        private static int CalcMaxCnt(int[] v)
        {
            int carefulType = v.Min();
            for (int i = 0; i < v.Length; i++) v[i] -= carefulType;

            int quickType = Math.Min(v[0] / 2, v[1]);
            v[0] -= quickType * 2;
            v[1] -= quickType;

            int stableType = v[0] / 3;

            return carefulType + quickType + stableType;
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

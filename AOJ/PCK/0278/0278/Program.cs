using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0278
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = RInt();
            for (int i = 0; i < n; i++)
            {
                int[] vs = RArInt();
                int normalPrice = vs[2] * vs[0] + vs[3] * vs[1];
                if (vs[2] >= 5 && vs[3] >= 2)
                {
                    Console.WriteLine(normalPrice * 4 / 5);
                }
                else
                {
                    int bulkBuyingPrice = (Math.Max(5, vs[2]) * vs[0] + Math.Max(2, vs[3]) * vs[1]) * 4 / 5;
                    Console.WriteLine(Math.Min(normalPrice, bulkBuyingPrice));
                }
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

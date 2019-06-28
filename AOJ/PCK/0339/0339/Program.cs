using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0339
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = RInt();
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                int[] vs = RArInt().OrderBy(x => x).ToArray();
                int num = 0;
                for (int j = 0; j < vs.Length; j++)
                {
                    num += vs[j] << 10 * j;
                }
                hs.Add(num);
            }
            Console.WriteLine(n - hs.Count());
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

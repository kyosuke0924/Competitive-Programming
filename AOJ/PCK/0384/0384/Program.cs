using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0384
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vs = RArInt();
            int a = vs[0], n = vs[1], m = vs[2];

            int res = 0;
            for (int i = 1; i < m; i++)
            {
                int powN = (int)Math.Pow(i, n);
                if (powN > m) break;
                else
                {
                    int digitsSum = powN.ToString().Select(x => int.Parse(x.ToString())).Sum();
                    if ((int)Math.Pow(digitsSum + a, n) == powN) res++;
                }
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

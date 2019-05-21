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
            int[] nk = RArInt();
            int n = nk[0];
            int k = nk[1];

            double[] ps = new double[nk[0]];

            for (int i = 0; i < ps.Length; i++)
            {
                if (i + 1 >= k)
                {
                    ps[i] = 1;
                }
                else
                {
                    double r = 0;
                    while ((i + 1) * Math.Pow(2, r) < k)
                    {
                        r++;
                    }
                    double j = Math.Pow(2, r);
                    ps[i] = 1 / j;
                }
            }

            Console.WriteLine(ps.Sum() / n);

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

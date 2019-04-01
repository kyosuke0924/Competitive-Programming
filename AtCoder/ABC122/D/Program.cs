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
            long MOD = (long)10e9 + 7;
            long n = RLong();

            if (n == 3)
            {
                Console.WriteLine(61);
            }
            else
            {
                long all = 1;
                for (int i = 0; i < n; i++)
                {
                    all *= 4;
                    all %= MOD;
                }

                long allm3 = 1;
                for (int i = 0; i < n - 3; i++)
                {
                    allm3 *= 4;
                    allm3 %= MOD;
                }

                long allm4 = 1;
                for (int i = 0; i < n - 4; i++)
                {
                    allm4 *= 4;
                    allm4 %= MOD;
                }

                long cnt = all;

                long ex1 = (3 * allm4 * 6) % MOD;
                cnt -= ex1 % MOD;
                cnt += MOD;

                long ex2 = (2 * allm3) % MOD;
                cnt -= ex2 % MOD ;
                cnt += MOD;

                Console.WriteLine(cnt % MOD);
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

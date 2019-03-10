using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0168
{
    public class Program

    {
        public static void Main(string[] args)
        {

            const int MAX = 30;

            int[] dp = new int[MAX + 1];
            dp[0] = 1;
            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3 ; i <= MAX ; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            }

            while (true)
            {
                int n = RInt(); if (n == 0) break;
                Console.WriteLine(dp[n] / 10 / 365 + 1);
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

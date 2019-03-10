using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0106
{
    public class Program

    {
        public static void Main(string[] args)
        {

            int[] weight = new int[] { 2, 3, 5, 10, 12, 15 };
            int[] price = new int[] { 380, 550, 850, (int)(380 * 5 * 0.8), (int)(550 * 4 * 0.85), (int)(850 * 3 * 0.88) };

            int[] dp = Enumerable.Repeat(20000, 51).ToArray();
            dp[0] = 0;

            for (int i = 0 ; i < weight.Count() ; i++)
            {
                for (int j = 0 ; j + weight[i] < dp.Count() ; j++)
                {
                    dp[j + weight[i]] = Math.Min(dp[j + weight[i]], dp[j] + price[i]);
                }
            }

            while (true)
            {
                int n = RInt();
                if (n == 0) break;
                Console.WriteLine(dp[n / 100]);
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

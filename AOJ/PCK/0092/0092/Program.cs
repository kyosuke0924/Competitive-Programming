using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0092
{
    public class Program

    {

        const int SENT = 1;

        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int[,] dp = new int[n + SENT, n + SENT];
                for (int i = 0 + SENT ; i < n + SENT ; i++)
                {
                    string line = RSt();
                    for (int j = 0 + SENT ; j < n + SENT ; j++)
                    {

                        if (line[j - 1] == '*')
                        {
                            dp[i, j] = 0;
                        }
                        else
                        {
                            dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                        }
                    }
                }

                int ans = 0;
                for (int i = 0 + SENT ; i < n + SENT ; i++)
                {
                    for (int j = 0 + SENT ; j < n + SENT ; j++)
                    {
                        ans = Math.Max(ans, dp[i, j]);
                    }
                }
                Console.WriteLine(ans);
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

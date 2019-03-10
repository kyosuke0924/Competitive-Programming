using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0191
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] nm = RIntAr();
                if (nm.Sum() == 0) break;

                int n = nm[0];
                int m = nm[1];

                double[,] growthRate = new double[n, n];
                for (int i = 0 ; i < n ; i++)
                {
                    double[] line = RDoubleAr();
                    for (int j = 0 ; j < n ; j++)
                    {
                        growthRate[i, j] = line[j];
                    }
                }

                double[,] dp = new double[m, n];
                for (int i = 0 ; i < n ; i++) dp[0, i] = 1;

                for (int i = 1 ; i < m ; i++)
                {
                    for (int j = 0 ; j < n ; j++)
                    {
                        for (int k = 0 ; k < n ; k++)
                        {
                            dp[i, j] = Math.Max(dp[i, j], dp[i - 1, k] * growthRate[k, j]);
                        }
                    }
                }

                double max = int.MinValue;
                for (int i = 0 ; i < n ; i++)
                {
                    max = Math.Max(max, dp[m - 1, i]);
                }
                Console.WriteLine(Math.Round(max, 2, MidpointRounding.AwayFromZero).ToString("0.00"));
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

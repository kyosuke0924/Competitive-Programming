using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_10_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            double[] p = ReadDoubleAr();
            double[] q = ReadDoubleAr();
            double[,] dp = new double[n + 2, n + 1];
            double[,] wt = new double[n + 2, n + 1];

            for (int i = 1 ; i <= n + 1 ; i++)
            {
                for (int j = i - 1 ; j <= n ; j++)
                {
                    if (j == i - 1)
                    {
                        wt[i, j] = q[j];
                        dp[i, j] = q[j];
                    }
                    else
                    {
                        dp[i, j] = long.MaxValue;
                        wt[i, j] = wt[i, j - 1] + p[j - 1] + q[j];
                    }
                }
            }

            for (int k = 0 ; k <= n ; k++)
            {
                for (int i = 1 ; i + k <= n ; i++)
                {
                    int j = i + k;
                    for (int m = i ; m <= j ; m++)
                    {
                        double tmp = dp[i, m - 1] + dp[m + 1, j] + wt[i, j];
                        dp[i, j] = Math.Min(dp[i, j], tmp);
                    }
                }
            }

            Console.WriteLine(dp[1, n].ToString());

        }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }

    }

}

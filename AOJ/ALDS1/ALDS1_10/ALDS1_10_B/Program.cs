using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_10_B
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] r = new int[n + 1];
            for (int i = 0 ; i < n ; i++)
            {
                int[] tmp = ReadIntAr();
                r[i] = tmp[0];
                r[i + 1] = tmp[1];
            }

            long[,] dp = new long[n, n];
            for (int i = 0 ; i < n ; i++)
            {
                for (int j = 0 ; j < n ; j++)
                {
                    dp[i, j] = (i == j) ? 0 : long.MaxValue;
                }
            }

            for (int k = 1 ; k < n ; k++)
            {
                for (int i = 0 ; i + k < n ; i++)
                {
                    int j = i + k;

                    for (int m = i ; m < j ; m++)
                    {
                        long tmp = dp[i, m] + dp[m + 1, j] + r[i] * r[m + 1] * r[j + 1];
                        dp[i, j] = Math.Min(dp[i, j], tmp);
                    }
                }
            }

            Console.WriteLine(dp[0, n - 1].ToString());

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

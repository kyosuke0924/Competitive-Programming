using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0145
{
    public class Program

    {
        public static void Main(string[] args)
        {

            int n = RInt();
            int[][] ab = new int[n][];
            for (int i = 0 ; i < n ; i++)
            {
                ab[i] = RIntAr();
            }

            int[,] dp = new int[n, n];
            for (int i = 0 ; i < n ; i++)
            {
                for (int j = 0 ; j < n ; j++)
                {
                    dp[i, j] = (i == j) ? 0 : int.MaxValue;
                }
            }

            for (int k = 1 ; k < n ; k++)
            {
                for (int i = 0 ; i + k < n ; i++)
                {
                    int j = i + k;

                    for (int m = i ; m < j ; m++)
                    {
                        int tmp = dp[i, m] + dp[m + 1, j] + ab[i][0] * ab[m][1] * ab[m + 1][0] * ab[j][1];
                        dp[i, j] = Math.Min(dp[i, j], tmp);
                    }
                }
            }

            Console.WriteLine(dp[0, n - 1].ToString());
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

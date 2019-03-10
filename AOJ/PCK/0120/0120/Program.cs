using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0120
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {

                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int[] items = Array.ConvertAll(line.Trim().Split(' '), e => int.Parse(e));
                int w = items[0];
                int[] r = items.Skip(1).ToArray();

                int n = r.Length;
                double[,] dp = new double[(1 << n), n];
                for (int i = 0 ; i < dp.GetLength(0) ; i++)
                {
                    for (int j = 0 ; j < dp.GetLength(1) ; j++)
                    {
                        dp[i, j] = int.MaxValue;
                    }
                }

                for (int i = 0 ; i < dp.GetLength(0) ; i++)
                {
                    for (int j = 0 ; j < n ; j++)
                    {
                        if (i == 0)
                        {
                            dp[(1 << j), j] = Math.Min(dp[(1 << j), j], r[j]);
                        }
                        else
                        {
                            for (int k = 0 ; k < dp.GetLength(1) ; k++)
                            {
                                if (dp[i, k] == int.MaxValue) continue;

                                int next = i | (1 << j);
                                dp[next, j] = Math.Min(dp[next, j], dp[i, k] + getDistance(r[k], r[j]));
                            }
                        }
                    }
                }

                double ans = double.MaxValue;
                for (int i = 0 ; i < n ; i++) ans = Math.Min(ans, dp[(1 << n) - 1, i] + r[i]);
                Console.WriteLine(ans - 1e-8 <= w ? "OK" : "NA");
            }
        }

        public static double getDistance(double r1, double r2)
        {
            return 2 * Math.Sqrt(r1 * r2);
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

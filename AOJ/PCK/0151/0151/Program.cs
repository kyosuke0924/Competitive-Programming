using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0151
{
    public class Program

    {

        const int STL = 1;
        public static int[] di = new int[] { 0, -1, -1, -1 };
        public static int[] dj = new int[] { -1, -1, 0, 1 };

        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int[,] map = new int[n + STL * 2, n + STL * 2];
                int[,,] dp = new int[n + STL * 2, n + STL * 2, 4];

                for (int i = 0 + STL ; i <= n ; i++)
                {
                    string line = RSt();
                    for (int j = 0 + STL ; j <= n ; j++)
                    {
                        map[i, j] = int.Parse(line[j - 1].ToString());
                    }
                }

                for (int i = 0 + STL ; i <= n ; i++)
                {
                    for (int j = 0 + STL ; j <= n ; j++)
                    {
                        for (int k = 0 ; k < 4 ; k++)
                        {
                            if (map[i, j] == 0) dp[i, j, k] = 0;
                            else dp[i, j, k] = dp[i + di[k], j + dj[k], k] + 1;
                        }
                    }
                }
                Console.WriteLine(dp.Cast<int>().Max());
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

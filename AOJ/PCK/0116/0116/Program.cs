using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0116
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {

                int[] HandW = RIntAr();
                if (HandW.Sum() == 0) break;

                int[,] dp = new int[HandW[0], HandW[1]];

                for (int i = 0 ; i < HandW[0] ; i++)
                {
                    string items = RSt();
                    for (int j = 0 ; j < HandW[1] ; j++)
                    {
                        if (items[j] == '.') dp[i, j] = j == 0 ? 1 : dp[i, j - 1] + 1;
                    }
                }

                int areaMax = 0;
                for (int i = 0 ; i < HandW[0] ; i++)
                {
                    for (int j = 0 ; j < HandW[1] ; j++)
                    {
                        if (dp[i, j] == 0) continue;

                        int curMaxArea = 0;
                        int minWidth = int.MaxValue;
                        for (int k = 0 ; k + i < HandW[0] ; k++)
                        {
                            if (dp[i + k, j] == 0) break;
                            minWidth = Math.Min(minWidth, dp[i + k, j]);
                            curMaxArea = Math.Max(curMaxArea, (k + 1) * minWidth);   
                        }
                        areaMax = Math.Max(areaMax, curMaxArea);
                    }
                }
                Console.WriteLine(areaMax);
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

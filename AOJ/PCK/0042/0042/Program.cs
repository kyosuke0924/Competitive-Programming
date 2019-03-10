using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0042
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int k = 0;
            while (true)
            {
                k++;

                int w = RInt();
                if (w == 0) return;

                int cnt = RInt();
                int[] dp = new int[w + 1];

                for (int i = 0 ; i < cnt ; i++)
                {
                    int[] items = RIntAr(',');
                    for (int j = w ; j >= 0 ; j--)
                    {
                        dp[j] = (j >= items[1]) ? Math.Max(dp[j], dp[j - items[1]] + items[0]) : dp[j];
                    }
                }

                Console.WriteLine("Case {0}:", k);
                Console.WriteLine(dp[w]);
                for (int i = w ; i >= 0 ; i--)
                {
                    if (dp[i] != dp[w])
                    {
                        Console.WriteLine(i + 1);
                        break;
                    }
                }
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

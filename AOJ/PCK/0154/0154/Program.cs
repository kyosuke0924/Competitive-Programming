using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0154
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int m = RInt();
                if (m == 0) break;

                SortedList<int,int> cards = new SortedList<int, int>();
                for (int i = 0 ; i < m ; i++)
                {
                    int[] items = RIntAr();
                     cards.Add(items[0],items[1]);
                }

                int[,] dp = new int[cards.Count() + 1, 1001];
                dp[0, 0] = 1;

                for (int i = 0 ; i < cards.Count() ; i++)
                {
                    for (int j = 0 ; j <= 1000 ; j++)
                    {
                        for (int k = 0 ; k <= cards.ElementAt(i).Value ; k++)
                        {
                            if (j + k * cards.ElementAt(i).Key > 1000) continue;
                            dp[i + 1, j + k * cards.ElementAt(i).Key] += dp[i, j];
                        }
                    }
                }

                int n = RInt();
                for (int i = 0 ; i < n ; i++)
                {
                    Console.WriteLine(dp[cards.Count(), RInt()]);
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

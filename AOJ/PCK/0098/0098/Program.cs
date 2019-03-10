using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0098
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = RInt();
            int[,] cSum = new int[n + 1, n + 1];

            //累積和の作成
            for (int i = 0 ; i < n ; i++)
            {
                int[] items = RIntAr();
                for (int j = 0 ; j < n ; j++)
                {
                    cSum[i + 1, j + 1] = cSum[i, j + 1] + cSum[i + 1, j] - cSum[i, j] + items[j];
                }
            }

            int max = int.MinValue;
            //部分和のチェック
            for (int xs = 0 ; xs < n ; xs++)
            {
                for (int xt = xs + 1 ; xt < n + 1 ; xt++)
                {
                    for (int ys = 0 ; ys < n ; ys++)
                    {
                        for (int yt = ys + 1 ; yt < n + 1 ; yt++)
                        {
                            max = Math.Max(cSum[yt, xt] - cSum[yt, xs] - cSum[ys, xt] + cSum[ys, xs], max);
                        }
                    }
                }
            }
            Console.WriteLine(max);
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

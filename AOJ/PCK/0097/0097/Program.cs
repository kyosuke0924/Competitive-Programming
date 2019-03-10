using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0097
{
    public class Program

    {
        public static void Main(string[] args)
        {


            long[,] dp = new long[11, 1001];
            dp[0, 0] = 1;

            for (int k = 0 ; k <= 100 ; k++)
            {
                for (int i = 10 ; i > 0 ; i--)
                {
                    for (int j = k ; j <= 1000 ; j++)
                    {
                        dp[i, j] += dp[i - 1, j - k];
                    }
                }
            }

            while (true)
            {
                int[] items = RIntAr();
                if (items.Sum() == 0) break;

                Console.WriteLine(dp[items[0], items[1]]);
            }
        }

        /// <summary>
        /// 配列の組み合わせを列挙する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">配列</param>
        /// <param name="r">取得数</param>
        /// <returns>配列の組み合わせの列挙</returns>
        public static IEnumerable<IEnumerable<T>> GetCombination<T>(IEnumerable<T> items, int r)
        {
            if (r == 0)
            {
                yield return Enumerable.Empty<T>();
            }
            else
            {
                var i = 0;
                foreach (var x in items)
                {
                    i++;
                    var xs = items.Skip(i);
                    foreach (IEnumerable<T> c in GetCombination(xs, r - 1))
                    {
                       yield return Concat(x, c);
                    }
                }
            }
        }

        private static IEnumerable<T> Concat<T>(T first, IEnumerable<T> items)
        {
            yield return first;
            foreach (var i in items) yield return i;
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

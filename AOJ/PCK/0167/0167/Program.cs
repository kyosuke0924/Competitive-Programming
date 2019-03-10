using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0167
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int[] a = new int[n];
                for (int i = 0 ; i < n ; i++)
                {
                    a[i] = RInt();
                }
                Console.WriteLine(BubbleSort(a));
            }
        }

        /// <summary>
        /// バブルソート
        /// </summary>
        /// <param name="array">対象配列</param>
        /// <returns>交換回数</returns>
        public static int BubbleSort(int[] array)
        {

            int swapTimes = 0;
            bool flg = true;
            while (flg)
            {
                flg = false;
                for (int i = array.Count() - 1 ; i > 0 ; i--)
                {
                    if (array[i] < array[i - 1])
                    {
                        int tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                        swapTimes++;
                        flg = true;
                    }
                }
            }
            return swapTimes;
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

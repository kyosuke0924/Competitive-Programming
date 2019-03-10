using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0157
{
    public class Matryoshka
    {
        public int Height { get; }
        public int Radius { get; }
        public Matryoshka(int[] items) { Height = items[0]; Radius = items[1]; }
    }

    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                List<Matryoshka> mats = new List<Matryoshka>();

                int n = RInt(); if (n == 0) break;
                for (int i = 0 ; i < n ; i++) mats.Add(new Matryoshka(RIntAr()));

                int m = RInt();
                for (int i = 0 ; i < m ; i++) mats.Add(new Matryoshka(RIntAr()));

                List<int> rads = mats.OrderBy(x => x.Height).ThenByDescending(x => x.Radius).Select(x => x.Radius).ToList();
                Console.WriteLine(LIS(rads));
            }
        }

        private static int LIS(List<int> rads)
        {
            int[] dp = new int[rads.Count()];
            for (int i = 0 ; i < dp.Count() ; i++) { dp[i] = int.MaxValue; }
            for (int i = 0 ; i < rads.Count() ; i++)
            {
                dp[LowerBound(dp, rads[i])] = rads[i];
            }

            return LowerBound(dp, int.MaxValue);
        }

        public static int LowerBound<T>(T[] arr, int start, int end, T value, IComparer<T> comparer)
        {
            int low = start;
            int high = end;
            int mid;
            while (low < high)
            {
                mid = ((high - low) >> 1) + low;
                if (comparer.Compare(arr[mid], value) < 0)
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }

        public static int LowerBound<T>(T[] arr, T value) where T : IComparable
        {
            return LowerBound(arr, 0, arr.Length, value, Comparer<T>.Default);
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

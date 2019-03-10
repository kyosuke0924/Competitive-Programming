using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_6_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] line = ReadIntAr();
            Comparer comparer;

            int q = ReadInt();
            for (int i = 0 ; i < q ; i++)
            {
                int k = ReadInt();
                comparer = new Comparer(line, k);
                Console.WriteLine("{0} {1}",BinarySearch(0, n - 1, comparer), BinarySearch2(0, n - 1, comparer));
            }
        }

        class Comparer : IComparer<int>
        {
            private int[] array;
            private int k;

            public Comparer(int[] array, int k)
            {
                this.array = array;
                this.k = k;
            }

            public int Compare(int x, int y)
            {
                return array[x].CompareTo(k);
            }
        }

        /// <summary>
        /// 二分探索
        /// -始点から終点までの整数列の中から、比較関数を満たす値を二分探索する
        /// 値が見つからない場合は、条件を満たす最小の数を返す
        /// </summary>
        /// <param name="left">始点</param>
        /// <param name="right">終点</param>
        /// <param name="comparer">比較関数</param>
        /// <returns></returns>
        public static int BinarySearch(int left, int right, IComparer<int> comparer)
        {

            int lo = left;
            int hi = right;
            while (lo <= hi)
            {
                int i = GetMedian(lo, hi);
                int c = comparer.Compare(i, 0);//yはダミーとして0固定
                if (c < 0) lo = i + 1;
                else hi = i - 1;
            }
            return lo;
        }
        public static int BinarySearch2(int left, int right, IComparer<int> comparer)
        {

            int lo = left;
            int hi = right;
            while (lo <= hi)
            {
                int i = GetMedian(lo, hi);
                int c = comparer.Compare(i, 0);//yはダミーとして0固定
                if (c <= 0) lo = i + 1;
                else hi = i - 1;
            }
            return lo;
        }
        private static int GetMedian(int low, int hi) { return low + ((hi - low) >> 1); }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }
        static string WriteAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }

    }

}

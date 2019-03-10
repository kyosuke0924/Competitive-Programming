using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_5_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] line = ReadIntAr();

            long comparisonTimes = 0;
            long swaptimes = 0;
            MergeSort(line, 0, n - 1, ref comparisonTimes, ref swaptimes);

            Console.WriteLine(swaptimes);
        }


        /// </summary>
        /// マージソート
        /// </summary>
        /// <param name="array">対象の配列</param>
        /// <param name="left">開始インデックス</param>
        /// <param name="right">終了インデックス</param>
        /// <param name="comparisonTimes">out 比較回数</param>
        /// <param name="swaptimes">out 反転数</param>
        public static void MergeSort(int[] array, int left, int right, ref long comparisonTimes, ref long swaptimes)
        {

            if (left == right) return;
            int mid = (left + right) / 2;

            MergeSort(array, left, mid, ref comparisonTimes, ref swaptimes);
            MergeSort(array, mid + 1, right, ref comparisonTimes, ref swaptimes);
            Merge(array, left, mid, right, ref comparisonTimes, ref swaptimes);

            return;
        }

        private static void Merge(int[] array, int left, int mid, int right, ref long comparisonTimes, ref long swaptimes)
        {

            int n1 = mid - left + 1;
            int n2 = right - (mid + 1) + 1;
            int[] L = new int[n1 + 1];
            int[] R = new int[n2 + 1];
            for (int a = 0 ; a < n1 ; a++) { L[a] = array[left + a]; }
            for (int a = 0 ; a < n2 ; a++) { R[a] = array[(mid + 1) + a]; }
            L[n1] = int.MaxValue;
            R[n2] = int.MaxValue;

            int i = 0, j = 0;
            for (int k = left ; k <= right ; k++)
            {
                if (L[i] <= R[j])
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                    swaptimes += (n1 - i);
                }
                comparisonTimes++;
            }

            return;
        }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }

    }

}

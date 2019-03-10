using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_6_C
{

    public class Program

    {
        public class Card
        {
            public int index;
            public char suit;
            public int value;

            public Card(int i, string[] item)
            {
                this.index = i;
                this.suit = char.Parse(item[0]);
                this.value = int.Parse(item[1]);
            }
        }

        public static void Main(string[] args)
        {
            int n = ReadInt();
            Card[] cards1 = new Card[n];
            for (int i = 0 ; i < n ; i++) { cards1[i] = new Card(i, ReadStAr()); }

            Card[] cards2 = (Card[])cards1.Clone();

            QuickSort(cards1, 0, cards1.Count() - 1);
            MergeSort(cards2, 0, cards1.Count() - 1);

            string res = "Stable";
            for (int i = 0 ; i < cards1.Count() ; i++)
            {
                if (cards1[i].suit != cards2[i].suit) { res = "Not stable"; break; }
            }

            Console.WriteLine(res);
            for (int i = 0 ; i < cards1.Count() ; i++) { Console.WriteLine("{0} {1}", cards1[i].suit, cards1[i].value); }
        }

        /// <summary>
        /// クイックソート
        /// </summary>
        /// <param name="array">対象配列</param>
        /// <param name="p">開始インデックス</param>
        /// <param name="r">終了インデックス</param>
        public static void QuickSort(Card[] array, int p, int r)
        {

            if (p < r)
            {
                int q = Partition(array, p, r);
                QuickSort(array, p, q - 1);
                QuickSort(array, q + 1, r);
            }

        }

        /// <summary>
        /// パーティション
        /// -配列をr番目の値より小さいグループと大きいグループに分割する
        /// </summary>
        /// <param name="array">対象配列</param>
        /// <param name="p">開始インデックス</param>
        /// <param name="r">基準インデックス</param>
        /// <returns>分割後の基準インデックスの位置</returns>
        public static int Partition(Card[] array, int p, int r)
        {
            int x = array[r].value;
            int i = p - 1;
            for (int j = p ; j < r ; j++)
            {
                if (array[j].value <= x)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }
            Swap(ref array[i + 1], ref array[r]);
            return i + 1;
        }
        private static void Swap<T>(ref T v1, ref T v2) { var tmp = v1; v1 = v2; v2 = tmp; }

        /// </summary>
        /// マージソート
        /// </summary>
        /// <param name="array">対象の配列</param>
        /// <param name="left">開始インデックス</param>
        /// <param name="right">終了インデックス</param>
        public static long MergeSort(Card[] array, int left, int right)
        {
            long comparisonTimes = 0, swaptimes = 0;
            MergeSort(array, left, right, ref comparisonTimes, ref swaptimes);
            return comparisonTimes;
        }

        /// </summary>
        /// マージソート
        /// </summary>
        /// <param name="array">対象の配列</param>
        /// <param name="left">開始インデックス</param>
        /// <param name="right">終了インデックス</param>
        /// <param name="comparisonTimes">out 比較回数</param>
        /// <param name="swaptimes">out 反転数</param>
        public static void MergeSort(Card[] array, int left, int right, ref long comparisonTimes, ref long swaptimes)
        {

            if (left == right) return;
            int mid = (left + right) / 2;

            MergeSort(array, left, mid, ref comparisonTimes, ref swaptimes);
            MergeSort(array, mid + 1, right, ref comparisonTimes, ref swaptimes);
            Merge(array, left, mid, right, ref comparisonTimes, ref swaptimes);

            return;
        }

        private static void Merge(Card[] array, int left, int mid, int right, ref long comparisonTimes, ref long swaptimes)
        {

            int n1 = mid - left + 1;
            int n2 = right - (mid + 1) + 1;
            Card[] L = new Card[n1 + 1];
            Card[] R = new Card[n2 + 1];
            for (int a = 0 ; a < n1 ; a++) { L[a] = array[left + a]; }
            for (int a = 0 ; a < n2 ; a++) { R[a] = array[(mid + 1) + a]; }
            L[n1] = new Card(int.MaxValue, new string[] { "X", int.MaxValue.ToString() });
            R[n2] = new Card(int.MaxValue, new string[] { "X", int.MaxValue.ToString() });

            int i = 0, j = 0;
            for (int k = left ; k <= right ; k++)
            {
                if (L[i].value <= R[j].value)
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

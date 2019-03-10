using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
    public class Sort
    {

        /// <summary>
        /// 挿入ソート
        /// </summary>
        /// <param name="array">対象配列</param>
        /// <returns>交換回数</returns>
        public static int InsertionSort(int[] array)
        {
            return InsertionSort(array, 1);
        }


        /// <summary>
        /// 挿入ソート（内部関数）
        /// </summary>
        /// <param name="array">対象配列</param>
        /// <param name="interval">ソートのインターバル</param>
        /// <returns>交換回数</returns>
        ///
        private static int InsertionSort(int[] array, int interval)
        {
            int swapTimes = 0;
            for (int i = interval ; i < array.Length ; i++)
            {
                int v = array[i];
                int j = i - interval;
                while (j >= 0 && array[j] > v)
                {
                    array[j + interval] = array[j];
                    j -= interval;
                    swapTimes++;
                }
                array[j + interval] = v;
            }
            return swapTimes;
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

        /// <summary>
        /// 選択ソート
        /// </summary>
        /// <param name="array">対象配列</param>
        /// <returns>交換回数</returns>
        public static int SelectionSort(int[] array)
        {

            int swapTimes = 0;

            int min = 0;
            for (int i = 0 ; i < array.Count() ; i++)
            {
                min = i;
                for (int j = i ; j < array.Count() ; j++)
                {
                    if (array[j] < array[min]) min = j;
                }

                if (i != min)
                {
                    int tmp = array[i];
                    array[i] = array[min];
                    array[min] = tmp;
                    swapTimes++;
                }

            }
            return swapTimes;
        }

        /// <summary>
        /// シェルソート
        /// </summary>
        /// <param name="array">対象配列</param>
        /// <returns>交換回数</returns>
        public static List<object> ShellSort(int[] array)
        {
            int swapTimes = 0;
            List<int> interval = new List<int>();
            for (int i = 1 ; i <= array.Length ; i = i * 3 + 1) interval.Add(i);

            for (int i = interval.Count - 1 ; i >= 0 ; i--)
            {
                swapTimes += InsertionSort(array, interval[i]);
            }

            List<object> res = new List<object>();
            res.Add(swapTimes);
            res.Add(interval);
            return res;
        }

        /// </summary>
        /// マージソート
        /// </summary>
        /// <param name="array">対象の配列</param>
        /// <param name="left">開始インデックス</param>
        /// <param name="right">終了インデックス</param>
        public static long MergeSort(int[] array, int left, int right)
        {
            long comparisonTimes =0 , swaptimes = 0;
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

        /// <summary>
        /// カウンティングソート
        /// </summary>
        /// <param name="array">対象配列</param>
        public static void CountingSort(int[] array)
        {
            CountingSort(array, array.Max());
        }

        /// <summary>
        /// カウンティングソート
        /// </summary>
        /// <param name="array">対象配列</param>
        /// <param name="k">配列内数値の最大値</param>
        public static void CountingSort(int[] array,int k)
        {
            int[] res = new int[array.Length];
            int[] tmp = new int[k + 1];
            for (int i = 0 ; i < array.Length ; i++) { tmp[array[i]]++; }
            for (int i = 1 ; i < tmp.Length ; i++) { tmp[i] += tmp[i - 1]; }
            for (int i = array.Length - 1 ; i >= 0 ; i--)
            {
                res[tmp[array[i]] - 1] = array[i];
                tmp[array[i]]--;
            }
        }

        /// <summary>
        /// クイックソート
        /// </summary>
        /// <param name="array">対象配列</param>
        /// <param name="p">開始インデックス</param>
        /// <param name="r">終了インデックス</param>
        public static void QuickSort(int[] array, int p, int r)
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
        private static int Partition(int[] array, int p, int r)
        {
            int x = array[r];
            int i = p - 1;
            for (int j = p ; j < r ; j++)
            {
                if (array[j] <= x)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }
            Swap(ref array[i + 1], ref array[r]);
            return i + 1;
        }
        /// <summary>
        /// 要素の交換
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public static void Swap<T>(ref T v1, ref T v2) { var tmp = v1; v1 = v2; v2 = tmp; }

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
                if (c == 0) return i;
                if (c < 0) lo = i + 1;
                else hi = i - 1;
            }
            return ~lo;
        }
        private static int GetMedian(int low, int hi) { return low + ((hi - low) >> 1); }

        /// <summary>
        /// 最小コストソート
        /// - 配列を交換するコストを(w1+w2）とした時の最小コストを求める
        /// </summary>
        /// <param name="seq">対象配列</param>
        /// <returns></returns>
        public static int SillySort(int[] seq)
        {

            int cost = 0, s;
            node[] nodes = new node[seq.Count()];
            node[] tmp = new node[seq.Count()];

            for (int i = 0 ; i < seq.Count() ; i++) { tmp[i].value = seq[i]; tmp[i].place = i; }
            tmp = tmp.OrderBy(x => x.value).ToArray();
            for (int i = 0 ; i < seq.Count() ; i++) { nodes[i].value = seq[i]; nodes[tmp[i].place].place = i; }
            s = tmp[0].value;

            for (int i = 0 ; i < seq.Count() ; i++)
            {
                int j = nodes[i].place;
                if (j >= 0 && j != i)
                {
                    int n = 1, sum, amin;
                    amin = sum = nodes[i].value;
                    while (j != i)
                    {
                        int next = nodes[j].place;
                        amin = Math.Min(amin, nodes[j].value);
                        sum += nodes[j].value;
                        n++;
                        nodes[j].place = -1;
                        j = next;
                    }
                    cost += Math.Min(sum + ((n - 2) * amin), sum + amin + (n + 1) * s);
                }
            }

            return cost;
        }
        private struct node { public int value; public int place; }
    }
}

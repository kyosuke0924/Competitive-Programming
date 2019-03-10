using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
    class LIS
    {

        private static int GetLIS(List<int> items)
        {
            int[] dp = new int[items.Count()];
            for (int i = 0 ; i < dp.Count() ; i++) { dp[i] = int.MaxValue; }
            for (int i = 0 ; i < items.Count() ; i++)
            {
                dp[LowerBound(dp, items[i])] = items[i];
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

    }
}

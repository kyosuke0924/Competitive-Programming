using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0188
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt(); if (n == 0) break;
                int[] nums = new int[n];
                for (int i = 0 ; i < n ; i++)
                {
                    nums[i] = RInt();
                }

                int target = RInt();

                int cnt = 0;
                int left = 0;
                int right = n - 1;

                while (right - left >= 0)
                {
                    cnt++;
                    int mid = (left + right) / 2;
                    if (nums[mid] == target) break;
                    else if (nums[mid] < target) left = mid + 1;
                    else right = mid - 1;
                   
                }

                Console.WriteLine(cnt);

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

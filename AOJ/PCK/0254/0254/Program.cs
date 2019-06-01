using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _0254
{
    class Program
    {
        static void Main(string[] args)
        {

            //var exStdIn = new System.IO.StreamReader("stdin.txt");
            //Console.SetIn(exStdIn);

            while (true)
            {
                int[] nm = RArInt();
                if (nm.Sum() == 0) break;
                int m = nm[1];

                long[] cumSumMod = new long[nm[0] + 1];
                int[] ks = RArInt();
                cumSumMod[0] = 0;
                for (int i = 0; i < ks.Length; i++)
                {
                    cumSumMod[i + 1] = (cumSumMod[i] + ks[i]) % m;
                }

                long res = 0;
                SortedList<long, long> ss = new SortedList<long, long>();
                ss.Add(cumSumMod[0], 0);
                for (int i = 1; i < cumSumMod.Length; i++)
                {
                    long j = UpperBound(ss, cumSumMod[i]);
                    res = Math.Max(res, (cumSumMod[i] - j + m) % m);
                    if (res == m - 1) break;
                    if(!ss.ContainsKey(cumSumMod[i])) ss.Add(cumSumMod[i], cumSumMod[i]);
                }
                Console.WriteLine(res);
            }
        }

        public static long UpperBound(SortedList<long, long> arr, long value)
        {
            int low = 0;
            int high = arr.Count();
            int mid;
            while (low < high)
            {
                mid = ((high - low) >> 1) + low;
                if (arr.Keys[mid] <= value)
                    low = mid + 1;
                else
                    high = mid;
            }
            return low != arr.Count() ? arr.Keys[low] : 0;
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RArSt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RArInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RArLong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RArDouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0165
{
    public class Program

    {
        public const int MAX = 1000000;

        public static void Main(string[] args)
        {
            bool[] isNotPrime = new bool[MAX + 1];
            int[] cumSum = new int[MAX + 1];

            isNotPrime[1] = true;
            for (int i = 2 ; i <= MAX ; i++)
            {
                cumSum[i] = cumSum[i - 1];
                if (!isNotPrime[i])
                {
                    cumSum[i]++;
                    for (int j = i * 2 ; j <= MAX ; j += i)
                    {
                        isNotPrime[j] = true;
                    }
                }
            }

            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int res = 0;
                for (int i = 0 ; i < n ; i++)
                {
                    int[] items = RIntAr();

                    int bottom = items[0] - items[1] < 1 ? 1 : items[0] - items[1];
                    int top = items[0] + items[1] > MAX ? MAX : items[0] + items[1];

                    int primeCnt = cumSum[top] - cumSum[bottom - 1];
                    if (primeCnt == 0) res--;
                    else res += primeCnt - 1;
                }
                Console.WriteLine(res);
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

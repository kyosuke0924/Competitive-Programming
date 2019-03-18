using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            long[] nk = RLongAr();
            long n = nk[0];
            long k = nk[1];

            long[] a = RLongAr();

            int[] count0 = new int[Convert.ToString(k, 2).Length];
            int[] count1 = new int[Convert.ToString(k, 2).Length];

            for (int i = 0 ; i < a.Length ; i++)
            {
                for (int j = 0 ; j < count0.Length ; j++)
                {
                    if (((a[i] >> j) & 1) == 1) count1[j]++;
                    else count0[j]++;
                }
            }

            long[] benefit = new long[Convert.ToString(k, 2).Length];
            for (int i = 0 ; i < benefit.Length ; i++)
            {
                benefit[i] = (long)Math.Pow(2, i) * (count0[i] - count1[i]);
            }



            long maxBenefit = 0;
            while (true)
            {
                for (int j = 0 ; j < benefit.Length ; j++)
                {
                    if (((i >> j) & 1) == 1) sum += benefit[j];
                }





            }

            long total = 0;
            for (int i = 0 ; i < a.Length ; i++)
            {
                total += (maxK ^ a[i]);
            }
            Console.WriteLine(total);
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

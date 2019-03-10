using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0162
{
    public class Program

    {
        public const int MAX = 1000000;

        public static void Main(string[] args)
        {
            bool[] isHumming = new bool[MAX + 1];
            int[] cumSum = new int[MAX + 1];

            for (int i = 0 ; i < 9 ; i++)
            {
                for (int j = 0 ; j < 13 ; j++)
                {
                    for (int k = 0 ; k < 20 ; k++)
                    {
                        long num = (long)(Math.Pow(5, i) * Math.Pow(3, j) * Math.Pow(2, k));
                        if(num <= 1000000) isHumming[num] = true;
                    }
                }
            }

            cumSum[1] = 1;
            for (int i = 2 ; i <= MAX ; i++)
            {
                cumSum[i] = cumSum[i - 1];
                if (isHumming[i]) cumSum[i]++;
            }

            while (true)
            {
                int[] items = RIntAr();
                if (items[0] == 0) break;             
                int primeCnt = cumSum[items[1]] - cumSum[items[0] - 1];
                Console.WriteLine(primeCnt);

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

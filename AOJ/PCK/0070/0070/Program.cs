using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0070
{
    public class Program

    {
        public static int[,] memo = new int[11, 331];
        public static bool[] m = new bool[10];

        public static void Main(string[] args)
        {
            init();
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int[] items = Array.ConvertAll(line.Trim().Split(' '), e => int.Parse(e));
                if (items[1] > 330) Console.WriteLine(0);
                else Console.WriteLine(memo[items[0], items[1]]);
            }
        }

        private static void init()
        {
            for (int i = 1 ; i <= 10 ; i++) { GetPermutation(i, 1, 0); }
        }

        private static void GetPermutation(int n, int k, int sum)
        {
            if (n < k) memo[n, sum]++;
            else
            {
                for (int i = 0 ; i <= 9 ; i++)
                {
                    if (!m[i])
                    {
                        m[i] = true;
                        GetPermutation(n, k + 1, sum + i * k);
                        m[i] = false;
                    }
                }
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

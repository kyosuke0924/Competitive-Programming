using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0206
{
    public class Program

    {
        public const int MONTH = 12;
        public static void Main(string[] args)
        {
            while (true)
            {
                int l = RInt(); if (l == 0) break;
                int[][] balances = new int[MONTH][];
                for (int i = 0 ; i < MONTH ; i++) balances[i] = RIntAr();
                Console.WriteLine(CalcMonth(l, balances));
            }
        }

        private static string CalcMonth(int l, int[][] balances)
        {
            int sum = 0;
            for (int i = 0 ; i < balances.Length ; i++)
            {
                sum += balances[i][0] - balances[i][1];
                if (sum >= l) return (i + 1).ToString();
            }
            return "NA";
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

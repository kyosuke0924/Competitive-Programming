using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_10_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            Console.WriteLine(Fib(n).ToString());
        }

        private static long Fib(int n)
        {
            long[] dp = new long[n+1];
            for (int i = 0 ; i <= n ; i++)
            {
                if (i == 0 || i == 1)
                {
                    dp[i] = 1;
                }
                else
                {
                    dp[i] = dp[i - 1] + dp[i - 2];
                }
            }
            return dp[n];
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

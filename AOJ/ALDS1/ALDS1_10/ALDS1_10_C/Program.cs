using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_10_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            for (int i = 0 ; i < n ; i++)
            {
                string str1 = ReadSt();
                string str2 = ReadSt();

                Console.WriteLine(GetLCSLength(str1, str2).ToString());

            }
        }

        private static int GetLCSLength(string str1, string str2)
        {

            int n = str1.Length;
            int m = str2.Length;

            int[,] dp = new int[n + 1, m + 1];

            for (int i = 0 ; i < n ; i++)
            {
                for (int j = 0 ; j < m ; j++)
                {
                    dp[i + 1, j + 1] = (str1[i] == str2[j]) ? dp[i, j] + 1 : Math.Max(dp[i, j + 1], dp[i + 1, j]);
                }
            }
            return dp[n, m];
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

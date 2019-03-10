using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_15_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int res = 0;
            int[] coins = new int[] {25,10,5,1};

            for (int i = 0 ; i < coins.Length ; i++)
            {
                res += n / coins[i];
                n %= coins[i];
            }

            Console.WriteLine(res.ToString());
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

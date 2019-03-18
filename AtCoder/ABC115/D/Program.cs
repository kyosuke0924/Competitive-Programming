using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D
{
    public class Program

    {

        static long[] burgerCnt;
        static long[] pattyCnt;

        public static void Main(string[] args)
        {
            long[] line = ReadLongAr();
            long n = line[0];
            long x = line[1];

            burgerCnt = new long[n + 1];
            pattyCnt = new long[n + 1];

            for (int i = 0 ; i <= n ; i++)
            {
                if (i == 0)
                {
                    burgerCnt[i] = 1;
                    pattyCnt[i] = 1;
                }
                else
                {
                    burgerCnt[i] = burgerCnt[i - 1] * 2 + 3;
                    pattyCnt[i] = pattyCnt[i - 1] * 2 + 1;
                }
            }

            long res = CountPatty(n, x);
            Console.WriteLine(res.ToString());

        }

        private static long CountPatty(long n, long x)
        {
            if (n == 0) return 1;
            if (x == 1) return 0;
            if (1 < x && x <= 1 + burgerCnt[n - 1]) return CountPatty(n - 1, x - 1);
            if (1 + burgerCnt[n - 1] < x && x <= 1 + burgerCnt[n - 1] + 1) return pattyCnt[n - 1] + 1;
            if (1 + burgerCnt[n - 1] + 1 < x && x <= burgerCnt[n] - 1) return pattyCnt[n - 1] + 1 + CountPatty(n - 1, x - (1 + burgerCnt[n - 1] + 1));
            if (x == burgerCnt[n]) return pattyCnt[n];
            return 0;
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

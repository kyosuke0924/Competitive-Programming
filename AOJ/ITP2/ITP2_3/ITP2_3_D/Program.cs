using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_3_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] a = ReadIntAr();
            int m = ReadInt();
            int[] b = ReadIntAr();

            for (int i = 0 ; i < Math.Min(n,m) ; i++)
            {
                if (a[i] > b[i])
                {
                    Console.WriteLine(0);
                    return;
                }
                else if (a[i] < b[i])
                {
                    Console.WriteLine(1);
                    return;
                }
            }

            if (m > n)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
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

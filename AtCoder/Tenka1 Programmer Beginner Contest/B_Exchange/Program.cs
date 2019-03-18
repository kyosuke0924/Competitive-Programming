using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B_Exchange
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] line = ReadIntAr();
            int a = line[0];
            int b = line[1];
            int k = line[2];

            for (int i = 0 ; i < k ; i++)
            {
                if (i % 2 ==0)
                {
                    if (a % 2 != 0) a--;
                    a /= 2;
                    b += a;
                }
                else
                {
                    if (b % 2 != 0) b--;
                    b /= 2;
                    a += b;
                }
            }

            Console.WriteLine("{0} {1}",a,b);
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

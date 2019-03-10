using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_3_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] line = ReadIntAr();

            int q = ReadInt();
            for (int i = 0 ; i < q ; i++)
            {
                int[] items = ReadIntAr();
                Console.WriteLine(line.Where((x, index) => items[0] <= index && index < items[1]).Count(x => x == items[2]));
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

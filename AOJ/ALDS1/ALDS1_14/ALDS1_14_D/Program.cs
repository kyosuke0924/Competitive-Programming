using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace ALDS1_14_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            string line = ReadSt();
            int n = ReadInt();
            StringSearch.SuffixArray sa = new StringSearch.SuffixArray(line);

            for (int i = 0 ; i < n ; i++)
            {
                Console.WriteLine(sa.Contains(ReadSt()) ? 1 : 0);
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

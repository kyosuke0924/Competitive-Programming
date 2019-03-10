using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace ALDS1_14_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] line = ReadIntAr();
            char[,] target = new char[line[0],line[1]];
            for (int i = 0 ; i < line[0] ; i++)
            {
                string item = ReadSt();
                for (int j = 0 ; j < line[1] ; j++)
                {
                    target[i,j] = item[j];
                }            
            }

            int[] line2 = ReadIntAr();
            char[,] pattern = new char[line2[0],line2[1]];
            for (int i = 0 ; i < line2[0] ; i++)
            {
                string item = ReadSt();
                for (int j = 0 ; j < line2[1] ; j++)
                {
                    pattern[i, j] = item[j];
                }
            }

            StringSearch ss = new StringSearch();
            StringBuilder sb = new StringBuilder();

            ss.PatternMatch(target, pattern, sb);
            Console.Write(sb);

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

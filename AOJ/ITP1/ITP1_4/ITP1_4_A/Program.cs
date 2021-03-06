﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_4_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] line = ReadIntAr();
            int a = line[0];
            int b = line[1];
            Console.WriteLine("{0} {1} {2}",a/b,a%b,((double)a/(double)b).ToString("F8"));
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

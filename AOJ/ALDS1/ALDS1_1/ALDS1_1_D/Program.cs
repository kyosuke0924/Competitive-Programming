﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_1_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();

            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0 ; i < n ; i++)
            {
                int num = ReadInt();
                max = Math.Max(max, num - min);
                min = Math.Min(min, num);
            }

            Console.WriteLine(max.ToString());
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_6_B
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] lineA = ReadIntAr();
            int m = ReadInt();
            int[] lineB = ReadIntAr();

            int aIdx = 0; int bIdx = 0;
            while (true)
            {
                if (lineA[aIdx] == lineB[bIdx]) bIdx++;
                aIdx++;
                if (bIdx == m || aIdx == n) { Console.WriteLine(bIdx == m ? 1 : 0); return; }
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
        static string WriteAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }

    }

}

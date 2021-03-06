﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0024
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = ReadSt();
                if (line == null) break;
                decimal requiredV = decimal.Parse(line);

                var t = requiredV / (decimal)9.8;
                decimal requiredY = (decimal)(Math.Pow((double)t, 2) * 4.9);
                Console.WriteLine(requiredY % 5 == 0 ? Math.Floor(requiredY / 5) + 1: Math.Floor(requiredY / 5) + 2);

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

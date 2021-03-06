﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0268
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = RInt();
            for (int i = 0; i < n; i++)
            {
                Solve();
            }
        }

        private static void Solve()
        {
            string s = RSt();
            int value = Convert.ToInt32(s, 16);

            bool IsNegativeNum = value < 0;
            int integralPart = (value >> 7) & 0xffffff;
            decimal decimalPart = (value & 0x7f) / (decimal)Math.Pow(2, 7);

            decimal res = integralPart + decimalPart;
            Console.WriteLine("{0}{1}", IsNegativeNum ? "-" : "", res.ToString("0.0######"));
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RArSt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RArInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RArLong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RArDouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }
}

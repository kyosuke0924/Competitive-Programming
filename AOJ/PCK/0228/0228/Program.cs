﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0228
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] disp = new int[] { 63, 6, 91, 79, 102, 109, 125, 39, 127, 111 };

            while (true)
            {
                int n = RInt();
                if (n == -1) break;

                int before = 0;
                for (int i = 0; i < n; i++)
                {
                    int d = RInt();
                    Console.WriteLine(Convert.ToString(before ^ disp[d], 2).PadLeft(7, '0'));
                    before = disp[d];
                }
            }
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

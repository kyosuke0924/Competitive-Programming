﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0051
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = RInt();
            for (int i = 0 ; i < n ; i++)
            {
                string line = RSt();
                int min = int.Parse(string.Join("", line.OrderBy(x => x).ToArray()));
                int max = int.Parse(string.Join("", line.OrderByDescending(x => x).ToArray()));
                Console.WriteLine(max-min);
            }       
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}

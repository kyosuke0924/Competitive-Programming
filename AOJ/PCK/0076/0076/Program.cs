﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0076
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                double x = 1D;
                double y = 0D;

                int n = RInt();
                if (n == -1) break;

                for (int i = 1 ; i < n ; i++)
                {
                    double length = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                    double dx = -y / length;
                    double dy = x / length;
                    x += dx;
                    y += dy;
                }
                Console.WriteLine(x);
                Console.WriteLine(y);
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

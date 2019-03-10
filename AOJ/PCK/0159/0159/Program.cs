﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0159
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                Dictionary<int, double> persons = new Dictionary<int, double>();
                for (int i = 0 ; i < n ; i++)
                {
                    int[] items = RIntAr();
                    persons.Add(items[0], GetBMIDiff(items[1], items[2]));
                }
                Console.WriteLine(persons.OrderBy(x => x.Value).ThenBy(x => x.Key).First().Key);
            }
        }

        public static double GetBMIDiff(int h, int w)
        {
            return Math.Abs(22 - w / (h * 0.01) / (h * 0.01));
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

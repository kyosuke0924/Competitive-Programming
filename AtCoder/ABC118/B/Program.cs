﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] nm = RIntAr();

            int[] food = new int[nm[1]];
            for (int i = 0 ; i < nm[0] ; i++)
            {
                int[] items = RIntAr().Skip(1).ToArray();
                for (int j = 0 ; j < items.Count() ; j++)
                {
                    food[items[j] - 1]++;
                }
            }

            int cnt = 0;
            foreach (var item in food)
            {
                if (item == nm[0]) cnt++;
            }

            Console.WriteLine(cnt);
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

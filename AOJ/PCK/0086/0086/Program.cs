﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0086
{
    public class Program

    {
        public static void Main(string[] args)
        {

            Dictionary<int, int> nodeOrder = new Dictionary<int, int>();
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int[] items = Array.ConvertAll(line.Trim().Split(' '), e => int.Parse(e));
                if (items.Sum() != 0)
                {
                    foreach (var item in items)
                    {
                        if (!nodeOrder.ContainsKey(item)) nodeOrder.Add(item, 0);
                        nodeOrder[item]++;
                    }
                }
                else
                {
                    Console.WriteLine(nodeOrder.All(x => x.Key < 3 && x.Value % 2 == 1 || x.Key >= 3 && x.Value % 2 == 0)  ? "OK" : "NG");
                    nodeOrder = new Dictionary<int, int>();
                }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0205
{
    public class Program

    {
        public static void Main(string[] args)
        {
            const int NUM = 5;
            Dictionary<int, int> winHand = new Dictionary<int, int>() { { 1, 2 }, { 2, 3 }, { 3, 1 } };

            while (true)
            {
                int[] hands = new int[NUM];
                for (int i = 0 ; i < NUM ; i++)
                {
                    int cur = RInt(); if (cur == 0) return;
                    hands[i] = cur;
                }

                if (hands.Distinct().Count() != 2)
                {
                    for (int i = 0 ; i < NUM ; i++) Console.WriteLine(3);
                }
                else
                {
                    int win = winHand[Enumerable.Range(1, 3).Except(hands).First()];
                    for (int i = 0 ; i < NUM ; i++) Console.WriteLine(hands[i] == win ? 1 : 2);
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

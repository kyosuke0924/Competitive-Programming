﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0222
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX = 10000000;

            bool[] notPrime = new bool[MAX + 1];
            long boundary = (long)Math.Floor(Math.Sqrt(MAX));
            notPrime[0] = notPrime[1] = true;

            for (long i = 2; i <= boundary; ++i)
            {
                if (notPrime[i]) continue;
                for (int j = 2; i * j <= MAX; j++)
                {
                    notPrime[i * j] = true;
                }
            }

            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                for (int i = n; i >= 13; i--)
                {
                    if (!notPrime[i] && !notPrime[i - 2] & !notPrime[i - 6] & !notPrime[i - 8])
                    {
                        Console.WriteLine(i);
                        break;
                    }
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

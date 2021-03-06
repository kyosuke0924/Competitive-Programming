﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A
{
    public class Program

    {
        const int MOD = (int)1e9 + 7;



        public static void Main(string[] args)
        {
            int n = RInt();
            string s = RSt();

            int[] frec = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                frec[s[i] - 'a']++;
            }

            long res = 1;
            for (int i = 0; i < frec.Count(); i++)
            {
                res = res % MOD * (frec[i] + 1) % MOD;
            }


            Console.WriteLine((res-1) % MOD);
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

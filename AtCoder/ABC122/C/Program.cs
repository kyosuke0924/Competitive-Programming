﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] nq = RIntAr();
            string s = RSt();

            int cnt = 0;
            bool aFlg = false;

            int[] cnts = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'C' && aFlg == true)
                {
                    cnt++;
                    aFlg = false;
                }
                cnts[i] = cnt;

                if (s[i] == 'A') aFlg = true; else aFlg = false;
            }

            for (int k = 0; k < nq[1]; k++)
            {
                int[] vs = RIntAr();
                Console.WriteLine(cnts[vs[1] - 1] - cnts[vs[0] - 1]);
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

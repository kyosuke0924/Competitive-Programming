﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0127
{
    public class Program

    {
        public static void Main(string[] args)
        {

            char[,] letter = new char[,]
            {
                {'a','b','c','d','e'}
              , {'f','g','h','i','j'}
              , {'k','l','m','n','o'}
              , {'p','q','r','s','t'}
              , {'u','v','w','x','y'}
              , {'z','.','?','!',' '}
            };

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                if (line.Length % 2 != 0)
                {
                    Console.WriteLine("NA");
                    continue;
                }

                string ans = "";
                bool flg = false;
                for (int i = 0 ; i < line.Length ; i += 2)
                {
                    int c1 = int.Parse(line[i].ToString());
                    int c2 = int.Parse(line[i + 1].ToString());

                    if (c1 < 1 || c1 > 6 || c2 < 1 || c2 > 5)
                    {
                        flg = true;
                        break;
                    }
                    ans += letter[c1 - 1, c2 - 1];
                }
                Console.WriteLine(flg ? "NA" : ans);
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

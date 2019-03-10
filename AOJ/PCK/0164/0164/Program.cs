using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0164
{
    public class Program

    {
        public static void Main(string[] args)
        {

            while (true)
            {
                int n = RInt(); if (n == 0) break;
                int[] a = RIntAr();

                int ohajiki = 32;
                int turn = 0;
                while (ohajiki > 0)
                {
                    if (turn % 2 == 0)
                    {
                        //taro
                        ohajiki -= (ohajiki - 1) % 5;
                    }
                    else
                    {
                        //jiro
                        int subNum = a[((turn - 1) / 2) % n];
                        ohajiki -= subNum > ohajiki ? ohajiki : subNum;
                    }
                    Console.WriteLine(ohajiki);
                    turn++;
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

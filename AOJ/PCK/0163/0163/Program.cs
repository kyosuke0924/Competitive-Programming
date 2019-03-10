using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0163
{
    public class Program

    {
        public static int[,] tolls = new int[,]
        {
              {  0, 300, 500, 600, 700, 1350, 1650 }
            , {  6,   0, 350, 450, 600, 1150, 1500 }
            , { 13,   7,   0, 250, 400, 1000, 1350 }
            , { 18,  12,   5,   0, 250,  850, 1300 }
            , { 23,  17,  10,   5,   0,  600, 1150 }
            , { 43,  37,  30,  25,  20,    0,  500 }
            , { 58,  52,  45,  40,  35,   15,    0 }
        };

        const int D_START = 1050;
        const int D_END = 1170;
        const int D_DIST = 40;

        public static void Main(string[] args)
        {
            while (true)
            {
                int d = RInt() - 1; if (d == -1) break;
                int mD = GetMinute(RIntAr());
                int a = RInt() - 1;
                int mA = GetMinute(RIntAr());

                int from = Math.Min(d, a);
                int to = Math.Max(d, a);
                int toll = tolls[from, to];

                bool discountD = tolls[to, from] <= D_DIST ? true : false;
                bool discountT = (D_START <= mD && mD <= D_END) || (D_START <= mA && mA <= D_END) ? true : false;
                Console.WriteLine(discountD && discountT ? GetHalf(toll) : toll);
            }

        }

        private static int GetHalf(int toll)
        {
            int half = toll / 2;
            if (half % 50 == 0) return half;
            else return((half / 50) + 1) * 50;
        }

        private static int GetMinute(int[] v) { return v[0] * 60 + v[1]; }

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

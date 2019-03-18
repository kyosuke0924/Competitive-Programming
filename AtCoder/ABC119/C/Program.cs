using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C
{
    public class Program

    {
        public static int targetA;
        public static int targetB;
        public static int targetC;
        public static int n;
        public static List<int> bamboos;
        public static bool[] used;
        public static int minCost;
        public static int candidate;

        public static void Main(string[] args)
        {
            int[] items = RIntAr();
            n = items[0];
            targetA = items[1];
            targetB = items[2];
            targetC = items[3];

            bamboos = new List<int>(8);
            for (int i = 0 ; i < n ; i++) bamboos.Add(RInt());

            Console.WriteLine(GetSteps(0, 0, 0, 0));
        }

        private static int GetSteps(int k, int a, int b, int c)
        {
            if (k == bamboos.Count())
            {
                if (a > 0 && b > 0 && c > 0)
                    return Math.Abs(targetA - a) + Math.Abs(targetB - b) + Math.Abs(targetC - c) - 10 * 3;
                else
                    return int.MaxValue - 10000;
            }

            int ret1 = GetSteps(k + 1, a, b, c);
            int ret2 = GetSteps(k + 1, a + bamboos[k], b, c) + 10;
            int ret3 = GetSteps(k + 1, a, b + bamboos[k], c) + 10;
            int ret4 = GetSteps(k + 1, a, b, c + bamboos[k]) + 10;

            return (new int[] { ret1, ret2, ret3, ret4 }).Min();

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

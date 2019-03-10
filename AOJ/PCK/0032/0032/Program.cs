using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0032
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int rectangleCnt = 0;
            int rhombusCnt = 0;
            while (true)
            {

                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                int[] items = Array.ConvertAll(line.Trim().Split(','), e => int.Parse(e));

                if (Math.Pow(items[0], 2) + Math.Pow(items[1], 2) == Math.Pow(items[2], 2)) rectangleCnt++;
                if (items[0] == items[1]) rhombusCnt++;

            }
            Console.WriteLine(rectangleCnt);
            Console.WriteLine(rhombusCnt);
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

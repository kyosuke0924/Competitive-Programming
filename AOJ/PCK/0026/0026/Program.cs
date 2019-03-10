using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0026
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[,] map = new int[14, 14];

            while (true)
            {
                string item = RSt();
                if (item == null) break;

                int[] items = Array.ConvertAll(item.Trim().Split(','), e => int.Parse(e));
                int x = items[0] + 2;
                int y = items[1] + 2;

                map[x, y]++;
                if (items[2] >= 1)
                {
                    map[x - 1, y]++;
                    map[x + 1, y]++;
                    map[x, y - 1]++;
                    map[x, y + 1]++;
                }
                if (items[2] >= 2)
                {
                    map[x - 1, y - 1]++;
                    map[x + 1, y - 1]++;
                    map[x - 1, y + 1]++;
                    map[x + 1, y + 1]++;
                }
                if (items[2] >= 3)
                {
                    map[x - 2, y]++;
                    map[x + 2, y]++;
                    map[x, y - 2]++;
                    map[x, y + 2]++;
                }
            }
            int blank = 0;
            int max = 0;
            for (int i = 2 ; i < 12 ; i++)
            {
                for (int j = 2 ; j < 12 ; j++)
                {
                    if (map[i, j] == 0) blank++;
                    max = Math.Max(max, map[i, j]);
                }
            }
            Console.WriteLine(blank);
            Console.WriteLine(max);
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WAr(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WAr(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}

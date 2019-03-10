using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0131
{
    public class Program

    {
        public const int SIZE = 10;
        public const int STL = 1;

        static public int[,] map;
        static public List<Tuple<int, int>> point;

        static public int[] di = new int[] { 0, 0, 0, -1, 1 };
        static public int[] dj = new int[] { 0, -1, 1, 0, 0 };

        public static void Main(string[] args)
        {
            int n = RInt();

            for (int lCnt = 0 ; lCnt < n ; lCnt++)
            {
                //initialize
                map = new int[SIZE + STL * 2, SIZE + STL * 2];
                for (int i = STL ; i < SIZE + STL ; i++)
                {
                    int[] items = RIntAr();
                    for (int j = STL ; j < SIZE + STL ; j++)
                    {
                        map[i, j] = items[j - STL];
                    }
                }

                //search
                int[,] defaultMap = new int[SIZE + STL * 2, SIZE + STL * 2];
                Array.Copy(map, defaultMap, map.Length);

                point = new List<Tuple<int, int>>(SIZE * SIZE);
                for (int k = 0 ; k < (1 << SIZE) ; k++)
                {
                    Array.Copy(defaultMap, map, map.Length);
                    point.Clear();
                    if (CanTurningOff(k))
                    {
                        break;
                    }
                }

                //print
                int[,] ans = new int[SIZE, SIZE];
                foreach (var item in point) ans[item.Item1 - STL, item.Item2 - STL] = 1;
                for (int i = 0 ; i < SIZE ; i++)
                {
                    for (int j = 0 ; j < SIZE ; j++)
                    {
                        Console.Write(ans[i, j]);
                        if (j != SIZE - 1) Console.Write(" ");
                        else Console.Write(Environment.NewLine);
                    }
                }

            }

        }

        private static bool CanTurningOff(int bit)
        {
            for (int i = STL ; i < SIZE + STL ; i++)
            {
                if (((bit >> i - 1) & 1) == 1) Reverse(STL, i);
            }

            for (int i = STL + 1 ; i < SIZE + STL ; i++)
            {
                for (int j = STL ; j < SIZE + STL ; j++)
                {
                    if (map[i - 1, j] == 1) Reverse(i, j);
                }
            }

            for (int i = STL ; i < SIZE + STL ; i++)
            {
                if (map[SIZE + STL - 1, i] == 1) return false;
            }
            return true;
        }

        private static void Reverse(int i, int j)
        {
            point.Add(new Tuple<int, int>(i, j));
            for (int k = 0 ; k < di.Length ; k++)
            {
                map[i + di[k], j + dj[k]] = map[i + di[k], j + dj[k]] ^ 1;
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

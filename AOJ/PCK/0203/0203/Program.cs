using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0203
{
    public class Program

    {
        private static int[,] map;
        private static int[,] cnt;

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] xy = RIntAr();
                if (xy.Sum() == 0) break;
                Init(xy);

                for (int i = 1 ; i < cnt.GetLength(0) ; i++)
                {
                    for (int j = 0 ; j < cnt.GetLength(1) ; j++)
                    {
                        switch (map[i, j])
                        {
                            case 0:
                                for (int k = -1 ; k <= 1 ; k++)
                                {
                                    if (IsInArea(i - 1, j + k) && map[i - 1, j + k] == 0) cnt[i, j] += cnt[i - 1, j + k];
                                }
                                if (IsInArea(i - 2, j) && map[i - 2, j] == 2) cnt[i, j] += cnt[i - 2, j];
                                break;
                            case 1:
                                break;
                            case 2:
                                if (IsInArea(i - 1, j) && map[i - 1, j] == 0) cnt[i, j] += cnt[i - 1, j];
                                if (IsInArea(i - 2, j) && map[i - 2, j] == 2) cnt[i, j] += cnt[i - 2, j];
                                break;
                        }
                    }
                }

                int sum = 0;
                for (int i = 0 ; i < cnt.GetLength(1) ; i++)
                {
                    sum += cnt[cnt.GetLength(0) - 1, i];
                    if  (IsInArea(cnt.GetLength(0) - 2, i) && map[cnt.GetLength(0) - 2, i] == 2) sum += cnt[cnt.GetLength(0) - 2, i];
                }
                Console.WriteLine(sum);
            }
        }

        private static bool IsInArea(int i, int j)
        {
            if (0 <= i && i < cnt.GetLength(0) && 0 <= j && j < cnt.GetLength(1)) return true;
            else return false;
        }

        private static void Init(int[] xy)
        {
            map = new int[xy[1], xy[0]];
            cnt = new int[xy[1], xy[0]];
            for (int i = 0 ; i < map.GetLength(0) ; i++)
            {
                int[] items = RIntAr();
                for (int j = 0 ; j < map.GetLength(1) ; j++)
                {
                    if (i == 0) cnt[i, j] = items[j] == 0 ? 1 : 0;
                    map[i, j] = items[j];
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

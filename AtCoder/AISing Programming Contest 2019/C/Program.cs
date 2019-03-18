using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C
{
    public class Program

    {
        public static int[,] map;
        public static bool[,] visited;
        public static int[] di = new int[] { -1, 1, 0, 0 };
        public static int[] dj = new int[] { 0, 0, -1, 1 };

        public static void Main(string[] args)
        {
            int[] items = RIntAr();
            int h = items[0];
            int w = items[1];

            map = new int[h + 2, w + 2];
           

            for (int i = 1 ; i < h + 1 ; i++)
            {
                string line = RSt();
                for (int j = 1 ; j < w + 1 ; j++)
                {
                    map[i, j] = line[j - 1] == '#' ? 1 : 2;
                }
            }

            long cnt = 0;
            for (int i = 1 ; i < h + 1 ; i++)
            {
                for (int j = 1 ; j < w + 1 ; j++)
                {
                    if (map[i, j] == 1)
                    {
                        visited = new bool[h + 2, w + 2];
                        cnt += SearchPair(i, j, true);
                    }
                }
            }

            Console.WriteLine(cnt);
        }

        private static long SearchPair(int inputi, int inputj, bool isBlack)
        {
            long cnt = 0;
            visited[inputi, inputj] = true;
            if (isBlack)
            {
                for (int i = 0 ; i < di.Length ; i++)
                {
                    if (map[inputi + di[i], inputj + dj[i]] == 2 && visited[inputi + di[i], inputj + dj[i]] == false)
                    {
                        cnt++;
                        cnt += SearchPair(inputi + di[i], inputj + dj[i], false);
                    }
                }
            }
            else
            {
                for (int i = 0 ; i < di.Length ; i++)
                {
                    if (map[inputi + di[i], inputj + dj[i]] == 1 && visited[inputi + di[i], inputj + dj[i]] == false)
                    {
                        cnt += SearchPair(inputi + di[i], inputj + dj[i], true);
                    }
                }
            }
            return cnt;
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

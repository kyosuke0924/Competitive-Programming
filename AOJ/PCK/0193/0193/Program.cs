using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0193
{
    public class Program

    {

        public static int[] di = new int[] { -1, -1, 0, 0, 1, 1 };
        public static int[,] dj = new int[,] { { -1, 0, -1, 1, -1, 0 }, { 0, 1, -1, 1, 0, 1 } };
        public static int[,] map;

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] nm = RIntAr();
                if (nm.Sum() == 0) break;

                map = new int[nm[1], nm[0]];
                for (int i = 0 ; i < map.GetLength(0) ; i++)
                {
                    for (int j = 0 ; j < map.GetLength(1) ; j++)
                    {
                        map[i, j] = int.MaxValue;
                    }
                }

                int s = RInt();
                for (int k = 0 ; k < s ; k++)
                {
                    int[] items = RIntAr();
                    BFS(items[1] - 1, items[0] - 1);
                }

                int[,] defaultMap = new int[nm[1], nm[0]];
                Array.Copy(map, defaultMap, map.Length);

                int t = RInt();
                int max = 0;
                for (int k = 0 ; k < t ; k++)
                {
                    Array.Copy(defaultMap, map, map.Length);
                    int[] items = RIntAr();
                    max = Math.Max(max, (BFS(items[1] - 1, items[0] - 1) + 1));          
                }

                Console.WriteLine(max);
            }
        }


        private static int BFS(int sI, int sJ)
        {

            int cnt = 0;

            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(new Tuple<int, int>(sI, sJ));
            map[sI, sJ] = 0;

            while (q.Count > 0)
            {
                Tuple<int, int> point = q.Dequeue();
                for (int i = 0 ; i < di.Length ; i++)
                {
                    int nI = point.Item1 + di[i];
                    int nJ = point.Item2 + dj[point.Item1 % 2, i];

                    if (InArea(nI, nJ) && map[point.Item1, point.Item2] + 1 < map[nI, nJ])
                    {
                        map[nI, nJ] = map[point.Item1, point.Item2] + 1;
                        q.Enqueue(new Tuple<int, int>(nI, nJ));
                        cnt++;
                    }
                }
            }
            return cnt;
        }

        private static bool InArea(int nI, int nJ)
        {
            return 0 <= nI && nI < map.GetLength(0) && 0 <= nJ && nJ < map.GetLength(1);
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

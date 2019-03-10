using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0156
{
    public class Program

    {
        public static int[] di = new int[] { 0, -1, 0, 1 };
        public static int[] dj = new int[] { -1, 0, 1, 0 };

        public static void Main(string[] args)
        {
            while (true)
            {

                int[] nm = RIntAr();
                if (nm.Sum() == 0) break;

                int n = nm[0];
                int m = nm[1];

                Tuple<int, int> castleTower = new Tuple<int, int>(0, 0);
                int[,] map = new int[m + 2, n + 2];
                for (int i = 1 ; i < m + 1 ; i++)
                {
                    string line = RSt();
                    for (int j = 1 ; j < n + 1 ; j++)
                    {
                        map[i, j] = line[j - 1] == '#' ? 1 : 0;
                        if (line[j - 1] == '&') castleTower = new Tuple<int, int>(i, j);
                    }
                }

                int[,] distance = new int[m + 2, n + 2];
                for (int i = 0 ; i < distance.GetLength(0) ; i++)
                {
                    for (int j = 0 ; j < distance.GetLength(1) ; j++)
                    {
                        distance[i, j] = int.MaxValue;
                    }
                }

                Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
                distance[0, 0] = 0;
                q.Enqueue(new Tuple<int, int>(0, 0));

                while (q.Count > 0)
                {
                    Tuple<int, int> pos = q.Dequeue();

                    for (int i = 0 ; i < di.Length ; i++)
                    {
                        if (!IsInRange(pos.Item1 + di[i], pos.Item2 + dj[i], map)) continue;
                        int nextCost = distance[pos.Item1, pos.Item2];
                        nextCost += (map[pos.Item1, pos.Item2] == 1 && map[pos.Item1 + di[i], pos.Item2 + dj[i]] == 0) ? 1 : 0;

                        if (distance[pos.Item1 + di[i], pos.Item2 + dj[i]] > nextCost)
                        {
                            distance[pos.Item1 + di[i], pos.Item2 + dj[i]] = nextCost;
                            q.Enqueue(new Tuple<int, int>(pos.Item1 + di[i], pos.Item2 + dj[i]));
                        }
                    }
                }
                Console.WriteLine(distance[castleTower.Item1, castleTower.Item2]);
            }
        }

        public static bool IsInRange(int i , int j, int[,] map)
        {
            if (i < 0 || i > map.GetLength(0) - 1 || j < 0 || j > map.GetLength(1) - 1) return false;
            else return true;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0122
{
    public class Program

    {
        static public int[] pdx = new int[] { -1, 0, 1, 2, 2, 2, 1, 0, -1, -2, -2, -2 };
        static public int[] pdy = new int[] { -2, -2, -2, -1, 0, 1, 2, 2, 2, 1, 0, -1 };
        static public int[] sdx = new int[] { -1, -1, -1, 0, 0, 0, 1, 1, 1 };
        static public int[] sdy = new int[] { -1, 0, 1, -1, 0, 1, -1, 0, 1, };
        static public bool[,,] visited;

        public struct Info
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int D { get; set; }
            public Info(int x, int y, int d) { X = x; Y = y; D = d; }
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] sXY = RIntAr();
                if (sXY.Sum() == 0) break;

                int n = RInt();
                int[] items = RIntAr();
                Tuple<int, int>[] sprinklerXY = new Tuple<int, int>[n];
                for (int i = 0 ; i < n ; i++) sprinklerXY[i] = new Tuple<int, int>(items[i * 2], items[i * 2 + 1]);

                visited = new bool[n + 1, 10, 10];

                Queue<Info> que = new Queue<Info>();
                que.Enqueue(new Info(sXY[0], sXY[1], 0));

                bool flg = false;
                while (que.Count() > 0)
                {

                    Info cur = que.Dequeue();

                    if (cur.D == n)
                    {
                        flg = true;
                        break;
                    }

                    for (int p = 0 ; p < pdy.Length ; p++)
                    {

                        int nextY = cur.Y + pdy[p];
                        int nextX = cur.X + pdx[p];

                        if (!CanMove(nextY, nextX)) continue;
                        if (visited[cur.D + 1, nextY, nextX]) continue;

                        for (int s = 0 ; s < sdy.Length ; s++)
                        {
                            if (nextY == sprinklerXY[cur.D].Item2 + sdy[s] && nextX == sprinklerXY[cur.D].Item1 + sdx[s])
                            {
                                que.Enqueue(new Info(nextX, nextY, cur.D + 1));
                                visited[cur.D + 1, nextY, nextX] = true;
                            }
                        }
                    }

                }

                Console.WriteLine(flg ? "OK" : "NA");

            }
        }

        static public bool CanMove(int i, int j)
        {
            if (i < 0 || 9 < i || j < 0 || 9 < j) return false;
            return true;
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

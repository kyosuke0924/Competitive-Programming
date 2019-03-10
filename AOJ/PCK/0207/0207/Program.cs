using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0207
{
    public class Program
    {

        class Point
        {
            public int X { get; private set; }
            public int Y { get; private set; }
            public Point(int x, int y) { X = x; Y = y; }
            public Point(int[] v) { X = v[0] - 1; Y = v[1] - 1; }
            public static bool operator ==(Point point1, Point point2) { return point1.X == point2.X && point1.Y == point2.Y; }
            public static bool operator !=(Point point1, Point point2) { return !(point1 == point2); }
            public static bool Equals(Point point1, Point point2) { return point1.X.Equals(point2.X) && point1.Y.Equals(point2.Y); }
            public override bool Equals(object o)
            {
                if ((null == o) || !(o is Point)) return false;
                return Equals(this, (Point)o);
            }
            public override int GetHashCode() { return X.GetHashCode() ^ Y.GetHashCode(); }
        }

        private static int[,] d = new int[,] { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };
        private static int[,] map;
        private static bool[,] visited;
        private static Point start, goal;

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] wh = RIntAr(); if (wh.Sum() == 0) break;
                Init(wh);
                Console.WriteLine(SearchRoute() ? "OK" : "NG");
            }
        }

        private static void Init(int[] wh)
        {
            const int BLOCK_W = 4;
            const int BLOCK_H = 2;

            map = new int[wh[1], wh[0]];
            visited = new bool[wh[1], wh[0]];
            start = new Point(RIntAr());
            goal = new Point(RIntAr());

            int n = RInt();
            for (int k = 0 ; k < n ; k++)
            {
                int[] items = RIntAr();
                int w, h;
                if (items[1] == 0) { w = BLOCK_W; h = BLOCK_H; }
                else { w = BLOCK_H; h = BLOCK_W; }

                for (int i = 0 ; i < h ; i++)
                {
                    for (int j = 0 ; j < w ; j++)
                    {
                        map[i + items[3] - 1, j + items[2] - 1] = items[0];
                    }
                }
            }
        }

        private static bool SearchRoute()
        {
            int color = map[start.Y, start.X];
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(start);
            visited[start.Y, start.X] = true;

            while (q.Count > 0)
            {
                Point p = q.Dequeue();
                visited[p.Y, p.X] = true;

                if (p == goal) return true;

                for (int i = 0 ; i < d.GetLength(0) ; i++)
                {
                    int nextX = p.X + d[i, 0];
                    int nextY = p.Y + d[i, 1];
                    if (IsInArea(nextX, nextY))
                    {
                        if (map[nextY, nextX] == color && !visited[nextY, nextX])
                        {
                            q.Enqueue(new Point(nextX, nextY));
                        }
                    }
                }
            }
            return false;
        }

        private static bool IsInArea(int x, int y)
        {
            return (0 <= x && x < map.GetLength(1) && 0 <= y && y < map.GetLength(0));
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

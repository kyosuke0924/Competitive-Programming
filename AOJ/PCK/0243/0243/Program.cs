using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0243
{
    class Program
    {
        static readonly char[] colors = new char[] { 'R', 'G', 'B' };
        static readonly int[] di = new int[] { 0, -1, 0, 1 };
        static readonly int[] dj = new int[] { -1, 0, 1, 0 };
        static int w, h;
        static bool[,] changeCells;

        class State
        {
            public int Cnt { get; set; }
            public bool IsSame { get; set; }
            public char[,] Map { get; set; }
            public State(int cnt, char[,] map, bool[,] visited, char nextColor)
            {
                Cnt = cnt;
                Map = new char[map.GetLength(0), map.GetLength(1)];
                IsSame = true;
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Map[i, j] = visited[i, j] ? nextColor : map[i, j];
                        if (0 < (i + j) && Map[0, 0] != Map[i, j]) IsSame = false;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int[] xy = RArInt();
                if (xy.Sum() == 0) break;

                w = xy[0]; h = xy[1];

                char[,] startMap = new char[h, w];
                changeCells = new bool[h, w];
                for (int i = 0; i < startMap.GetLength(0); i++)
                {
                    string[] vs = RArSt();
                    for (int j = 0; j < startMap.GetLength(1); j++)
                    {
                        startMap[i, j] = vs[j][0];
                    }
                }

                Console.WriteLine(GetChangeCount(startMap));
            }
        }

        private static int GetChangeCount(char[,] startMap)
        {
            Queue<State> q = new Queue<State>();
            State cur = new State(0, startMap, changeCells, '\0');
            if (cur.IsSame) return cur.Cnt;
            q.Enqueue(cur);

            while (q.Count() > 0)
            {
                cur = q.Dequeue();
                changeCells = new bool[h, w];
                GetchangeCells(0, 0, cur.Map);
                foreach (var color in colors)
                {
                    if (color != cur.Map[0, 0])
                    {
                        State next = new State(cur.Cnt + 1, cur.Map, changeCells, color);
                        if (next.IsSame) return next.Cnt;
                        q.Enqueue(next);
                    }
                }
            }
            return 0; //ダミー
        }

        private static void GetchangeCells(int i, int j, char[,] map)
        {
            changeCells[i, j] = true;
            for (int k = 0; k < di.Length; k++)
            {
                int nextI = i + di[k];
                int nextJ = j + dj[k];
                if (!IsInArea(nextI, nextJ)) continue;
                if (!changeCells[nextI, nextJ] && map[nextI, nextJ] == map[0, 0]) GetchangeCells(nextI, nextJ, map);
            }
        }

        private static bool IsInArea(int i, int j)
        {
            return 0 <= i && i < h && 0 <= j && j < w;
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RArSt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RArInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RArLong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RArDouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }
}

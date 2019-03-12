using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0210
{
    public class Program

    {
        private const char BLANK = '.';
        private const char WALL = '#';
        private const char EXIT = 'X';
        private const int TIME_LIMIT = 180;

        private enum Direction { W, S, E, N, Cnt }

        private class Point
        {
            public int I { get; set; }
            public int J { get; set; }
            public Point(int i, int j) { I = i; J = j; }
        }

        private class Person
        {
            public Point Pos { get; set; }
            public Direction Dir { get; set; }
            public Point NxtPos { get; set; }
            public Direction NxtDir { get; set; }
            public Person(int i, int j, Direction d) { Pos = new Point(i, j); Dir = d; }
        }

        private static readonly Point[] dPos = new Point[] { new Point(0, -1), new Point(1, 0), new Point(0, 1), new Point(-1, 0) };
        private static char[,] map;
        private static List<Person> psns;

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] wh = RIntAr();
                if (wh.Sum() == 0) break;
                Init(wh);
                Console.WriteLine(CalcExitTime());
            }
        }

        private static void Init(int[] wh)
        {
            map = new char[wh[1], wh[0]];
            psns = new List<Person>();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                string line = RSt();
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    char c = line[j];
                    map[i, j] = c;
                    if (c != BLANK && c != WALL && c != EXIT)
                    {
                        psns.Add(new Person(i, j, (Direction)Enum.Parse(typeof(Direction), c.ToString())));
                    }
                }
            }
        }

        private static string CalcExitTime()
        {
            int time = 0;
            while (time <= TIME_LIMIT)
            {
                time++;
                CalcNxt();
                Move();
                if (psns.Count == 0) return time.ToString();
            }
            return "NA";
        }

        private static void CalcNxt()
        {
            const int INIT = -1;
            int[,] conflictIDMap = new int[map.GetLength(0), map.GetLength(1)];
            for (int i = 0; i < conflictIDMap.GetLength(0); i++)
            {
                for (int j = 0; j < conflictIDMap.GetLength(1); j++)
                {
                    conflictIDMap[i, j] = INIT;
                }
            }

            for (int i = 0; i < psns.Count(); i++)
            {
                psns[i].NxtPos = psns[i].Pos;
                for (int j = 0; j < (int)Direction.Cnt; j++)
                {
                    Direction nxtDir = (Direction)(((int)psns[i].Dir + ((int)Direction.Cnt - 1) + j) % (int)Direction.Cnt);
                    int nxtI = psns[i].Pos.I + dPos[(int)nxtDir].I;
                    int nxtJ = psns[i].Pos.J + dPos[(int)nxtDir].J;

                    if (map[nxtI, nxtJ] == BLANK || map[nxtI, nxtJ] == EXIT)
                    {
                        psns[i].NxtDir = nxtDir;

                        int conflictID = conflictIDMap[nxtI, nxtJ];
                        if (conflictID == INIT || (int)nxtDir < (int)psns[conflictID].NxtDir)
                        {
                            psns[i].NxtPos = new Point(nxtI, nxtJ);
                            conflictIDMap[nxtI, nxtJ] = i;
                            if (conflictID != INIT) psns[conflictID].NxtPos = psns[conflictID].Pos;
                        }
                        break;
                    }
                }
            }
        }

        private static void Move()
        {
            for (int i = psns.Count() - 1; i >= 0; i--)
            {
                map[psns[i].Pos.I, psns[i].Pos.J] = BLANK;

                psns[i].Dir = psns[i].NxtDir;
                psns[i].Pos = psns[i].NxtPos;

                if (map[psns[i].Pos.I, psns[i].Pos.J] == EXIT)
                {
                    psns.RemoveAt(i);
                }
                else
                {
                    map[psns[i].Pos.I, psns[i].Pos.J] = Enum.GetName(typeof(Direction), psns[i].Dir)[0];
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

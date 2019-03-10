using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0141
{
    public class Program

    {
        enum Dir { U, R, D, L, Cnt }
        static int[] di = new int[] { -1, 0, 1, 0 };
        static int[] dj = new int[] { 0, 1, 0, -1 };
        static string[,] map;
        const int STL = 2;

        public static void Main(string[] args)
        {
            int d = RInt();
            for (int k = 0 ; k < d ; k++)
            {
                int n = RInt();
                map = new string[n + STL * 2, n + STL * 2];

                for (int i = 0 ; i < map.GetLength(0) ; i++)
                {
                    if (i == 0 || i == map.GetLength(0) - 1)
                    {
                        for (int j = 0 ; j < map.GetLength(1) ; j++) map[i, j] = "#";
                    }
                    else
                    {
                        map[i, 0] = "#";
                        map[i, map.GetLength(1) - 1] = "#";
                    }
                }

                int pi = map.GetLength(0) - 1 - STL;
                int pj = STL;
                int direct = 0;

                while (true)
                {
                    map[pi, pj] = "#";

                    int nexti = pi + di[direct % (int)Dir.Cnt];
                    int nextj = pj + dj[direct % (int)Dir.Cnt];

                    if (GetSharpCnt(nexti, nextj) > 1)
                    {
                        direct++;
                        nexti = pi + di[direct % (int)Dir.Cnt];
                        nextj = pj + dj[direct % (int)Dir.Cnt];

                        if (GetSharpCnt(nexti, nextj) > 1) break;
                    }
                    pi = nexti;
                    pj = nextj;
                }

                if(k > 0) Console.Write(Environment.NewLine);
                for (int i = STL ; i < map.GetLength(0) - STL ; i++)
                {
                    for (int j = STL ; j < map.GetLength(1) - STL ; j++)
                    {
                        Console.Write(map[i, j] == null ? " " : map[i, j]);
                    }
                    Console.Write(Environment.NewLine);
                }

            }

        }

        public static int GetSharpCnt(int pi, int pj)
        {
            int sharpCnt = 0;
            for (int i = 0 ; i < di.Length ; i++) if (map[pi + di[i], pj + dj[i]] == "#") sharpCnt++;
            return sharpCnt;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0209
{
    public class Program

    {

        class Point
        {
            public int x, y;
            public Point(int x, int y) { this.x = x; this.y = y; }
        }


        public static int[,] map;
        public static int[][,] pieces;

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] nm = RIntAr(); if (nm.Sum() == 0) break;
                Init(nm);
                Console.WriteLine(SearchMatchPoint());
            }
        }

        private static string SearchMatchPoint()
        {
            for (int i = 0 ; i < map.GetLength(0) ; i++)
            {
                for (int j = 0 ; j < map.GetLength(1) ; j++)
                {
                    Point p = IsMatch(i, j);
                    if (p != null) return (p.x + 1).ToString() + " " + (p.y + 1).ToString();
                }
            }
            return "NA";
        }

        private static Point IsMatch(int si, int sj)
        {
            for (int k = 0 ; k < pieces.Length ; k++)
            {
                Point p = IsMatchP(si, sj, pieces[k]);
                if (p != null) return p;
            }
            return null;
        }

        private static Point IsMatchP(int si, int sj, int[,] piece)
        {

            if (si > map.GetLength(0) - piece.GetLength(0) || sj > map.GetLength(1) - piece.GetLength(1)) return null;

            Point p = null;
            for (int i = 0 ; i < piece.GetLength(0) ; i++)
            {
                for (int j = 0 ; j < piece.GetLength(1) ; j++)
                {
                    if (piece[i, j] != -1)
                    {
                        if (p == null) p = new Point(j + sj, i + si);
                        if (piece[i, j] != map[i + si, j + sj]) return null;
                    }                    
                }
            }
            return p;
        }

        private static void Init(int[] nm)
        {
            map = new int[nm[0], nm[0]];
            for (int i = 0 ; i < map.GetLength(0) ; i++)
            {
                int[] items = RIntAr();
                for (int j = 0 ; j < map.GetLength(1) ; j++)
                {
                    map[i, j] = items[j];
                }
            }

            pieces = new int[4][,];

            pieces[0] = new int[nm[1], nm[1]];
            for (int i = 0 ; i < pieces[0].GetLength(0) ; i++)
            {
                int[] items = RIntAr();
                for (int j = 0 ; j < pieces[0].GetLength(1) ; j++)
                {
                    pieces[0][i, j] = items[j];
                }
            }

            for (int k = 1 ; k < pieces.Length ; k++)
            {

                int h = pieces[k - 1].GetLength(1);
                int w = pieces[k - 1].GetLength(0);

                pieces[k] = new int[h, w];
                for (int i = 0 ; i < h ; i++)
                {
                    for (int j = 0 ; j < w ; j++)
                    {
                        pieces[k][i, j] = pieces[k - 1][w - 1 - j, i];
                    }
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

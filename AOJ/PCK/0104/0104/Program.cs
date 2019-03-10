using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0104
{
    public class Program

    {
        static int[] dx = new int[] { 1, 0, -1, 0 };
        static int[] dy = new int[] { 0, 1, 0, -1 };

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] cnts = RIntAr();
                if (cnts.Sum() == 0) break;

                char[,] map = new char[cnts[0], cnts[1]];
                bool[,] visited = new bool[cnts[0], cnts[1]];

                for (int i = 0 ; i < cnts[0] ; i++)
                {
                    string items = RSt();
                    for (int j = 0 ; j < cnts[1] ; j++) map[i, j] = items[j];
                }

                int x = 0;
                int y = 0;
                while (true)
                {
                    if (visited[y, x])
                    {
                        Console.WriteLine("LOOP"); break;
                    }

                    if (map[y, x] == '.')
                    {
                        Console.WriteLine("{0} {1}", x, y); break;
                    }

                    visited[y, x] = true;
                    switch (map[y, x])
                    {
                        case '>': x += dx[0]; y += dy[0]; break;
                        case 'v': x += dx[1]; y += dy[1]; break;
                        case '<': x += dx[2]; y += dy[2]; break;
                        case '^': x += dx[3]; y += dy[3]; break;
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

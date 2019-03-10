using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0071
{
    public class Program

    {

        const int WIDTH = 8;
        const int SENTINEL = 3;
        static int[,] map;

        public static void Main(string[] args)
        {
            int n = RInt();
            for (int k = 0 ; k < n ; k++)
            {

                RSt();//空行の読み飛ばし

                map = new int[WIDTH + SENTINEL * 2, WIDTH + SENTINEL * 2];
                for (int i = SENTINEL ; i < WIDTH + SENTINEL ; i++)
                {
                    string line = RSt();
                    for (int j = SENTINEL ; j < WIDTH + SENTINEL ; j++)
                    {
                        map[i, j] = int.Parse(line[j - SENTINEL].ToString());
                    }
                }

                int x = RInt();
                int y = RInt();
                Explosion(x - 1 + SENTINEL, y - 1 + SENTINEL);

                Console.WriteLine("Data {0}:", k + 1);
                for (int i = SENTINEL ; i < WIDTH + SENTINEL ; i++)
                {
                    for (int j = SENTINEL ; j < WIDTH + SENTINEL ; j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.Write(Environment.NewLine);
                }
            }
        }

        private static void Explosion(int x, int y)
        {
            int[] dx = new int[] { -3, -2, -1, 1, 2, 3, 0, 0, 0, 0, 0, 0 };
            int[] dy = new int[] { 0, 0, 0, 0, 0, 0, -3, -2, -1, 1, 2, 3 };

            map[y, x] = 0;
            for (int i = 0 ; i < dx.Length ; i++)
            {
                if (map[y + dy[i], x + dx[i]] == 1) Explosion(x + dx[i], y + dy[i]);
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

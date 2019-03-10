using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0118
{
    public class Program

    {

        public static char[,] map;
        public static bool[,] visited;
        public static int[] di = new int[] { 0, -1, 0, 1 };
        public static int[] dj = new int[] { 1, 0, -1, 0 };

        public static void Main(string[] args)
        {

            while (true)
            {
                int[] HW = RIntAr();
                if (HW.Sum() == 0) break;

                map = new char[HW[0] + 2, HW[1] + 2];
                visited = new bool[HW[0] + 2, HW[1] + 2];

                for (int i = 1 ; i < map.GetLength(0) - 1 ; i++)
                {
                    string line = RSt();
                    for (int j = 1 ; j < map.GetLength(1) - 1 ; j++)
                    {
                        map[i, j] = line[j - 1];
                    }
                }

                int cnt = 0;
                for (int i = 1 ; i < map.GetLength(0) - 1 ; i++)
                {
                    for (int j = 1 ; j < map.GetLength(1) - 1 ; j++)
                    {
                        if (!visited[i, j])
                        {
                            SetGroup(i, j, map[i, j]);
                            cnt++;
                        }
                    }
                }
                Console.WriteLine(cnt);
            }
        }

        private static void SetGroup(int vi, int vj, char type)
        {
            visited[vi, vj] = true;
            for (int i = 0 ; i < di.Count() ; i++)
            {
                if (!visited[vi + di[i], vj + dj[i]] && map[vi + di[i], vj + dj[i]] == type)
                {
                    SetGroup(vi + di[i], vj + dj[i], type);
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

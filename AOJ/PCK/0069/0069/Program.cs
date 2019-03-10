using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0069
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {

                int vLineCnt = RInt();
                if (vLineCnt == 0) return;

                int start = RInt();
                int goal = RInt();

                int n = RInt();

                int[,] map = new int[n, vLineCnt + 1];
                for (int i = 0 ; i < n ; i++)
                {
                    string line = RSt();
                    for (int j = 1 ; j < vLineCnt ; j++)
                    {
                        map[i, j] = int.Parse(line[j - 1].ToString());
                    }
                }

                if (CanReachGoal(map, start, goal)) Console.WriteLine(0);
                else Console.WriteLine(CanReachGoalAddOneLine(map, start, goal));

            }

        }

        private static string CanReachGoalAddOneLine(int[,] map, int start, int goal)
        {
            for (int i = 0 ; i < map.GetLength(0) ; i++)
            {
                for (int j = 1 ; j < map.GetLength(1) - 1 ; j++)
                {
                    if (map[i, j] == 0 && map[i, j - 1] == 0 && map[i, j + 1] == 0)
                    {
                        map[i, j] = 1;
                        if(CanReachGoal(map, start, goal)) return (i + 1).ToString() + " " + j.ToString();
                        map[i, j] = 0;
                    }
                }
            }

            return "1";
        }

        private static bool CanReachGoal(int[,] map, int start, int goal)
        {
            int cur = start;
            for (int i = 0 ; i < map.GetLength(0) ; i++)
            {
                if (map[i, cur - 1] == 1) cur--;
                else if (map[i, cur] == 1) cur++;
            }
            return cur == goal ? true : false;
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

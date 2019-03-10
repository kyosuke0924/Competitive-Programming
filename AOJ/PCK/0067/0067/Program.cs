using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0067
{
    public class Program

    {
        static private int[,] map;
        static private bool[,] visited;

        public static void Main(string[] args)
        {

            while (true)
            {
                map = new int[14, 14];
                visited = new bool[14, 14];

                string line;
                for (int i = 1 ; i < 13 ; i++)
                {
                    line = Console.ReadLine();
                    for (int j = 1 ; j < 13 ; j++)
                    {
                        map[i, j] = int.Parse(line[j - 1].ToString());
                    }
                }

                int res = 0;
                for (int i = 1 ; i < 13 ; i++)
                {
                    for (int j = 1 ; j < 13 ; j++)
                    {
                        if (map[i, j] == 1 && visited[i, j] == false)
                        {
                            res++;
                            VisitContinuousArea(i, j);
                        }
                    }
                }
                Console.WriteLine(res);

                line = Console.ReadLine();
                if (line == null) break;
            }
        }

        private static void VisitContinuousArea(int i, int j)
        {
            visited[i, j] = true;
            if (map[i - 1, j] == 1 && visited[i - 1, j] == false) VisitContinuousArea(i - 1, j);
            if (map[i + 1, j] == 1 && visited[i + 1, j] == false) VisitContinuousArea(i + 1, j);
            if (map[i, j - 1] == 1 && visited[i, j - 1] == false) VisitContinuousArea(i, j - 1);
            if (map[i, j + 1] == 1 && visited[i, j + 1] == false) VisitContinuousArea(i, j + 1);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hw = RArInt();
            bool[,] map = new bool[hw[0] + 2, hw[1] + 2];
            int[,] hLen = new int[hw[0] + 2, hw[1] + 2];
            int[,] wLen = new int[hw[0] + 2, hw[1] + 2];

            for (int i = 1; i < map.GetLength(0) - 1; i++)
            {
                string s = RSt();
                for (int j = 1; j < map.GetLength(1) - 1; j++)
                {
                    map[i, j] = s[j - 1] == '.' ? true : false;
                }
            }

            Queue<int> q = new Queue<int>();
            int cnt = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j])
                    {
                        q.Enqueue(j);
                        cnt++;
                    }
                    else
                    {
                        while (q.Count > 0)
                        {
                            int cur = q.Dequeue();
                            wLen[i, cur] = cnt;
                        }
                        cnt = 0;
                    }
                }
            }

            q = new Queue<int>();
            cnt = 0;
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (map[j, i])
                    {
                        q.Enqueue(j);
                        cnt++;
                    }
                    else
                    {
                        while (q.Count > 0)
                        {
                            int cur = q.Dequeue();
                            hLen[cur, i] = cnt;
                        }
                        cnt = 0;
                    }
                }
            }

            int res = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    res = Math.Max(res, wLen[i, j] + hLen[i, j]);
                }
            }
            Console.WriteLine(res == 0 ? 0 : res - 1);

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

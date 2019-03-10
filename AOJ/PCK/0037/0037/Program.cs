using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0037
{
    public class Program

    {
        public static void Main(string[] args)
        {

            List<int>[,] map = new List<int>[5, 5];

            //配列の初期化
            for (int i = 0 ; i < 5 ; i++)
            {
                for (int j = 0 ; j < 5 ; j++)
                {
                    map[i, j] = new List<int>();
                }
            }

            for (int i = 0 ; i < 9 ; i++)
            {
                string line = RSt();
                for (int j = 0 ; j < line.Length ; j++)
                {
                    if (line[j] == '1')
                    {
                        if (i % 2 == 0)
                        {
                            map[i / 2, j].Add(0);
                            map[i / 2, j + 1].Add(180);
                        }
                        else
                        {
                            map[i / 2, j].Add(270);
                            map[i / 2 + 1, j].Add(90);
                        }
                    }
                }
            }

            int[] dx = new int[] { 1, 0, -1, 0 };
            int[] dy = new int[] { 0, -1, 0, 1 };
            LinkedList<int> res = new LinkedList<int>();
            res.AddLast(0);
            int x = 1; int y = 0;

            while (x != 0 || y != 0)
            {
                int ingressOrientation = (res.Last.Value + 180) % 360;
                int next = GetOrientation(ingressOrientation, x, y, map[y, x]);
                res.AddLast(next);
                x += dx[next / 90];
                y += dy[next / 90];
            }

            string[] directions = new string[] { "R", "U", "L", "D" };
            Console.WriteLine(WAr(res.Select(item => directions[item / 90]),""));
        }

        private static int GetOrientation(int ingressOrientation, int x, int y, List<int> list)
        {
            int next = ingressOrientation;
            while (true)
            {
                next = (next + 270) % 360;
                if (list.Contains(next)) return next;
            }
        }

        static string RSt() { return Console.ReadLine(); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}

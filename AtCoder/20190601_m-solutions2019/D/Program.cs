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
            int n = RInt();

            Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                tree.Add(i, new List<int>());
            }
            for (int i = 0; i < n - 1; i++)
            {
                int[] vs = RArInt();
                tree[vs[0] - 1].Add(vs[1] - 1);
                tree[vs[1] - 1].Add(vs[0] - 1);
            }

            int[] score = RArInt();
            Array.Sort(score);
            Array.Reverse(score);

            int[] nodeScore = new int[n];

            int idx = 0;
            Queue<int> q = new Queue<int>();
            q.Enqueue(0);

            while (q.Count > 0)
            {
                int cur = q.Dequeue();
                if (nodeScore[cur] > 0) continue;

                nodeScore[cur] = score[idx];
                idx++;

                foreach (var child in tree[cur])
                {
                    if (nodeScore[child] > 0) continue;
                    q.Enqueue(child);
                }
            }

            Console.WriteLine(score.Sum() - score.First());
            Console.WriteLine(WAr(nodeScore));
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

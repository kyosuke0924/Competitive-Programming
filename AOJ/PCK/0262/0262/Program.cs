using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0262
{
    class Program
    {
        static Dictionary<int, HashSet<int>> adj;
        static int max, n;
        static int[] direction;
        static bool[] sVisited, gVisited;

        static void Main(string[] args)
        {
            while (true)
            {
                max = RInt();
                if (max == 0) break;
                Init();
                GotoGoal();
                if (!adj.ContainsKey(n + 1))
                {
                    Console.WriteLine("NG");
                }
                else
                {
                    GotoStart();
                    bool flg = true;
                    for (int i = 1; i < sVisited.Length; i++)
                    {
                        if (sVisited[i] && !gVisited[i])
                        {
                            flg = false;
                            break;
                        }
                    }
                    Console.WriteLine(flg ? "OK" : "NG");
                }
            }
        }

        private static void Init()
        {
            n = RInt();
            direction = new int[n + 1];
            for (int i = 1; i <= n; i++) direction[i] = RInt();
            adj = new Dictionary<int, HashSet<int>>();
            sVisited = new bool[n + 2];
            gVisited = new bool[n + 2];
        }

        private static void GotoGoal()
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(0);

            while (q.Count > 0)
            {
                int cur = q.Dequeue();
                if (sVisited[cur]) continue;
                sVisited[cur] = true;

                for (int i = 1; i <= max; i++)
                {
                    if (cur + i >= n + 1)
                    {
                        if (!adj.ContainsKey(n + 1)) adj.Add(n + 1, new HashSet<int>());
                        adj[n + 1].Add(cur);
                    }
                    else
                    {
                        int next = cur + i + direction[cur + i];
                        if (next >= n + 1)
                        {
                            if (!adj.ContainsKey(n + 1)) adj.Add(n + 1, new HashSet<int>());
                            adj[n + 1].Add(cur);
                        }
                        else if (next < 0)
                        {
                            if (!adj.ContainsKey(0)) adj.Add(0, new HashSet<int>());
                            adj[0].Add(cur);
                        }
                        else
                        {
                            if (!adj.ContainsKey(next)) adj.Add(next, new HashSet<int>());
                            adj[next].Add(cur);
                            q.Enqueue(next);
                        }
                    }
                }
            }
        }

        private static void GotoStart()
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(n + 1);

            while (q.Count > 0)
            {
                int cur = q.Dequeue();
                if (gVisited[cur] || cur == 0) continue;
                gVisited[cur] = true;

                foreach (var next in adj[cur])
                {
                    q.Enqueue(next);
                }
            }
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

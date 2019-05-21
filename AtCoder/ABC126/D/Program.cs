using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D
{
    class Program
    {
        static Dictionary<int,int>[] map;
        static bool[] visited;
        static bool[] ans;

        static void Main(string[] args)
        {
            int n = RInt();
            map = new Dictionary<int, int>[n];
            visited = new bool[n];
            ans = new bool[n];

            for (int i = 0; i < n - 1; i++)
            {
                int[] vs = RArInt();

                if (map[vs[0] - 1] == null) map[vs[0] - 1] = new Dictionary<int, int>();
                map[vs[0] - 1].Add(vs[1] - 1, vs[2]);

                if (map[vs[1] - 1] == null) map[vs[1] - 1] = new Dictionary<int, int>();
                map[vs[1] - 1].Add(vs[0] - 1, vs[2]);
            }

            Dfs(0, 0);
            for (int i = 0; i < ans.Length; i++)
            {
                Console.WriteLine(ans[i] ? 1 : 0);
            }
        }

        private static void Dfs(int v, int parent)
        {
            if (!visited[v])
            {
                visited[v] = true;

                if (v != 0 && map[parent][v] % 2 == 1)
                {
                    ans[v] = !ans[parent];
                }

                foreach (var item in map[v])
                {
                    if (item.Key == parent) continue;
                    Dfs(item.Key, v);
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

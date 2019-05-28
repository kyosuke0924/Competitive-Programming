using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0251
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int[] nm = RArInt();
                if (nm.Sum() == 0) break;
                UnionFind uf = new UnionFind(nm[0]);
                Console.WriteLine(CanDraw(uf, nm) ? "yes" : "no");
            }

        }

        private static bool CanDraw(UnionFind uf, int[] nm)
        {
            bool res = true;
            int[] degree = new int[nm[0]];
            for (int i = 0; i < nm[1]; i++)
            {
                int[] vs = RArInt();

                if (res)
                {
                    int u = vs[0] - 1;
                    int v = vs[1] - 1;

                    if (uf.IsSameGroup(u, v)) res = false;
                    degree[u]++;
                    degree[v]++;
                    if (degree[u] >= 3 || degree[v] >= 3) res = false;
                    uf.Unite(u, v);
                }
            }
            return res;
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

    class UnionFind
    {
        private readonly int[] parents;
        private readonly int[] rank;

        public UnionFind(int n)
        {
            parents = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++) parents[i] = i;
        }

        public int Find(int x)
        {
            if (parents[x] == x) return x;
            else return parents[x] = Find(parents[x]);
        }

        public void Unite(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y) return;

            if (rank[x] < rank[y])
            {
                parents[x] = y;
            }
            else
            {
                parents[y] = x;
                if (rank[x] == rank[y]) rank[x]++;
            }
        }

        public bool IsSameGroup(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}

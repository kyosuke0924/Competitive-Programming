using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0225
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int[] inEdge = new int[26];
                int[] outEdge = new int[26];
                UnionFind uf = new UnionFind(26);

                for (int i = 0; i < n; i++)
                {
                    string st = RSt();
                    int s = st[0] - 'a';
                    int e = st[st.Length - 1] - 'a';

                    outEdge[s]++;
                    inEdge[e]++;
                    uf.Unite(s, e);
                }

                bool isConcat = uf.parents.Where((x, i) => inEdge[i] != 0 || outEdge[i] != 0).Select(x => uf.Find(x)).Distinct().Count() == 1;
                bool isEuler = inEdge.Where((x, i) => x == outEdge[i]).Count() == inEdge.Count();
                Console.WriteLine(isConcat && isEuler ? "OK" : "NG");
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

    class UnionFind
    {
        public readonly int[] parents;
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

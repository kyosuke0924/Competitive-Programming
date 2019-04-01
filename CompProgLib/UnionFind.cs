using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
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

        public bool IsSameGroup(int x,int y)
        {
            return Find(x) == Find(y);
        }
    }
}

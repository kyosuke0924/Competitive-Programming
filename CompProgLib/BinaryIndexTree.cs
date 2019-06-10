using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
    class BinaryIndexTree　//添え字1始まり
    {
        private int N { get; set; }
        private int[] Bit { get; set; }

        public BinaryIndexTree(int n)
        {
            N = n; Bit = new int[n + 1];
        }

        public void Add(int idx, int value)
        {
            for (int i = idx; i <= N; i += i & -i) Bit[i] += value;
        }

        public int Sum(int idx) //bit[1]～bit[idx]までの和
        {
            int ret = 0;
            for (int i = idx; i > 0; i -= i & -i) ret += Bit[i];
            return ret;
        }
    }
}

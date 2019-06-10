using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0271
{
    class Program
    {
        const int LMT = 100000;
        const int MOD = 1000000007;
        static int[] num;
        static long[] facts;

        static void Main(string[] args)
        {
            CreateFacts();
            while (true)
            {
                int n = RInt();
                if (n == 0) break;
                Init(n);
                Console.WriteLine(CalcNthNum());
            }
        }

        private static void CreateFacts()
        {
            facts = new long[LMT + 1];
            facts[0] = 1;
            for (int i = 1; i < facts.Length; i++) facts[i] = facts[i - 1] * i % MOD;
        }

        private static void Init(int n)
        {
            num = new int[n + 1];
            for (int i = 0; i < num.Length; i++) num[i] = i;

            int r = RInt();
            for (int i = 0; i < r; i++)
            {
                int[] vs = RArInt();
                Swap(ref num[vs[0]], ref num[vs[1]]);
            }
        }

        private static void Swap<T>(ref T v1, ref T v2) { var tmp = v1; v1 = v2; v2 = tmp; }

        private static long CalcNthNum()
        {
            BinaryIndexTree BITree = new BinaryIndexTree(num.Length);
            long res = 0;
            for (int i = 1; i < num.Length; i++)
            {
                int lessNumCnt = BITree.Sum(num[i] - 1);
                res += (num[i] - 1 - lessNumCnt) * facts[num.Length - 1 - i] % MOD;
                res %= MOD;
                BITree.Add(num[i], 1);
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

    class BinaryIndexTree　//添え字1始まり
    {
        private readonly int N;
        private readonly int[] bit;

        public BinaryIndexTree(int n)
        {
            N = n;
            bit = new int[n + 1];
        }

        public void Add(int idx, int value)
        {
            for (int i = idx; i <= N; i += i & -i)
            {
                bit[i] += value;
            }
        }

        public int Sum(int idx)
        {
            int ret = 0;
            for (int i = idx; i > 0; i -= i & -i)
            {
                ret += bit[i];
            }
            return ret;
        }

    }
}

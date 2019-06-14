using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0272
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int[] a = RArInt();
                int[] b = RArInt();

                Array.Sort(a); Array.Reverse(a);
                Array.Sort(b); Array.Reverse(b);

                Console.WriteLine(CalcMinK(a, b));
            }

        }

        static string CalcMinK(int[] a, int[] b)
        {
            BinaryIndexTree winCnt = new BinaryIndexTree(b.Length);
            int idxA = 0;
            for (int k = 0; k < b.Length; k++)
            {
                int requiredWinCnt = (k + 1) / 2 + 1;
                while (a[idxA] > b[k] && idxA < a.Length - 1) idxA++;
                winCnt.Add(idxA + 1, 1);
                if (k + 1 - winCnt.Sum(k + 1) >= requiredWinCnt) return (k + 1).ToString();
            }
            return "NA";
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

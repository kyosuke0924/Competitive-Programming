using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0267
{
    class Program
    {
        const int LIM = 10000;
        static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int[] blocks = RArInt();
                int res = IsTriNum(blocks.Sum()) ? GetOpeCount(blocks.ToList()) : -1;
                Console.WriteLine(res);
            }
        }

        private static bool IsTriNum(int v)
        {
            double EPS = 10e-9;
            double n = (Math.Sqrt(8 * v + 1) - 1) / 2;
            return Math.Abs(n - Math.Round(n)) < EPS;
        }

        private static int GetOpeCount(List<int> blocks)
        {
            int cnt = 0;
            while (true)
            {
                if (cnt > LIM) return -1;
                if (blocks.Select((x, i) => new { x, i }).All(x => x.x == x.i + 1)) return cnt;

                List<int> nBlocks = new List<int>();
                for (int i = 0; i < blocks.Count(); i++)
                {
                    if (blocks[i] > 1) nBlocks.Add(blocks[i] - 1);
                }
                nBlocks.Add(blocks.Count());
                blocks = nBlocks;
                cnt++;
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

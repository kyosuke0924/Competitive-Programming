using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0288
{
    class Tool
    {
        public int Attack { get; set; }
        public int Exp { get; set; }
        public int Requirement { get; set; }
        public Tool(int[] vs)
        {
            Attack = vs[0];
            Exp = vs[1];
            Requirement = vs[2];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int[] dn = RArInt();
                if (dn.Sum() == 0) break;

                Tool[] tools = new Tool[dn[1]];
                for (int i = 0; i < dn[1]; i++) tools[i] = new Tool(RArInt());

                int[,] dp = new int[dn[0] + 1, 101];
                for (int i = 0; i < dp.GetLength(0); i++)
                {
                    for (int j = 0; j < dp.GetLength(1); j++)
                    {
                        dp[i, j] = int.MaxValue;

                    }
                }
                dp[0, 0] = 0;

                int maxI = dp.GetLength(0);
                int maxJ = dp.GetLength(1);

                for (int i = 0; i < maxI; i++)
                {
                    for (int j = 0; j < maxJ; j++)
                    {
                        if (dp[i, j] == int.MaxValue) continue;
                        foreach (var tool in tools)
                        {
                            if (j >= tool.Requirement)
                            {
                                int nextI = i + tool.Attack;
                                int nextJ = j + tool.Exp;
                                dp[Math.Min(nextI, maxI - 1), Math.Min(nextJ, maxJ - 1)] = Math.Min(dp[Math.Min(nextI, maxI - 1), Math.Min(nextJ, maxJ - 1)], dp[i, j] + 1);
                            }
                        }
                    }
                }

                int res = int.MaxValue;
                for (int i = 0; i < maxJ; i++)
                {
                    res = Math.Min(res, dp[maxI - 1, i]);
                }
                Console.WriteLine(res == int.MaxValue ? "NA" : res.ToString());

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

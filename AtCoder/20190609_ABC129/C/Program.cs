using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MOD = 1000000007;
            int[] nm = RArInt();
            bool[] IsBreak = new bool[nm[0] + 1];
            for (int i = 0; i < nm[1]; i++)
            {
                IsBreak[RInt()] = true;
            }

            int[] dp = new int[nm[0] + 1];
            dp[0] = 1;
            dp[1] = IsBreak[1] ? 0 : 1;

            for (int i = 2; i <= nm[0]; i++)
            {
                if (IsBreak[i])
                {
                    dp[i] = 0;
                }
                else
                {
                    dp[i] = (dp[i - 1] % MOD + dp[i - 2] % MOD) % MOD;
                }
            }
            Console.WriteLine(dp[nm[0]]);
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

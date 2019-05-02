using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0232
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                int[] xyz = RArInt();
                if (xyz.Sum() == 0) break;

                int[] spots = RArInt();
                Dictionary<int, Tuple<int, int>> events = new Dictionary<int, Tuple<int, int>>();
                for (int i = 0; i < xyz[2]; i++)
                {
                    int[] vs = RArInt();
                    events.Add(vs[0], new Tuple<int, int>(vs[1], vs[2]));
                }

                double[,] dp = new double[xyz[1] + 1, 100 * xyz[1] + 1];
                double p = 1 / (double)spots.Length;

                dp[0, 0] = 1;
                for (int i = 0; i < dp.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < dp.GetLength(1); j++)
                    {
                        if (dp[i, j] > 0)
                        {
                            for (int k = 0; k < spots.Length; k++)
                            {
                                int nextcell = Math.Min(dp.GetLength(0) - 1, i + spots[k]);
                                if (events.ContainsKey(nextcell))
                                {
                                    switch (events[nextcell].Item1)
                                    {
                                        case 1:
                                            nextcell = Math.Min(dp.GetLength(0) - 1, nextcell + events[nextcell].Item2);
                                            dp[nextcell, j] += dp[i, j] * p;
                                            break;
                                        case 2:
                                            dp[nextcell, j + events[nextcell].Item2] += dp[i, j] * p;
                                            break;
                                        case 3:
                                            dp[nextcell, Math.Max(0, j - events[nextcell].Item2)] += dp[i, j] * p;
                                            break;
                                    }
                                }
                                else
                                {
                                    dp[nextcell, j] += dp[i, j] * p;
                                }
                            }
                        }
                    }
                }

                double res = 0;
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    res += dp[dp.GetLength(0) - 1, j] * j;
                }
                Console.WriteLine(Math.Floor(res));
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

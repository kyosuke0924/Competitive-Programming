using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0258
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int[] vs = RArInt();
                List<int>[] cand = new List<int>[vs.Length];
                for (int i = 0; i < cand.Length; i++) cand[i] = new List<int>();

                for (int i = 0; i < vs.Length; i++)
                {
                    for (int j = 0; j < vs.Length; j++)
                    {
                        if (i != j) cand[i].Add(vs[j]);
                    }
                }

                for (int i = 0; i < cand.Length; i++)
                {
                    int diff = cand[i].Take(cand[i].Count() - 1).Select((x, idx) => cand[i][idx + 1] - cand[i][idx]).Distinct().Count();
                    if (diff == 1)
                    {
                        Console.WriteLine(vs[i]);
                        break;
                    }
                }
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

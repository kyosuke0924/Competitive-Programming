using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0282
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nrl = RArInt();
            int[] Scores = new int[nrl[0]];
            int[] airingSeconds = new int[nrl[0]];

            Tuple<int, int> top = new Tuple<int, int>(0, 0);
            int lastlogSeconds = 0;

            for (int i = 0; i < nrl[1]; i++)
            {
                int[] vs = RArInt();
                airingSeconds[top.Item1] += vs[1] - lastlogSeconds;
                lastlogSeconds = vs[1];

                Scores[vs[0] - 1] += vs[2];
                if (Scores[vs[0] - 1] > top.Item2 || Scores[vs[0] - 1] == top.Item2 && vs[0] - 1 < top.Item1)
                {
                    top = new Tuple<int, int>(vs[0] - 1, Scores[vs[0] - 1]);
                }
                else if (vs[0] - 1 == top.Item1 && vs[2] < 0)
                {
                    top = Scores.Select((x, idx) => new Tuple<int, int>(idx, x)).OrderByDescending(y => y.Item2).ThenBy(y => y.Item1).FirstOrDefault();
                }
            }
            airingSeconds[top.Item1] += nrl[2] - lastlogSeconds;
            Console.WriteLine(airingSeconds.Select((x, i) => new Tuple<int, int>(i, x)).OrderByDescending(y => y.Item2).ThenBy(y => y.Item1).FirstOrDefault().Item1 + 1);
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

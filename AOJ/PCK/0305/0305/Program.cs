using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0305
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = RInt();
            int cnt = 0;
            while (cnt < n)
            {
                Console.WriteLine(WAr(GetPos(RArInt())));
                cnt++;
            }
        }

        private static IEnumerable<int> GetPos(int[] v)
        {
            const int R_SPAN = 100;
            const int T_SPAN = 30;

            int r = v[0], t = v[1];

            bool isOnArc = r % R_SPAN == 0;
            bool isOnLineSeg = t % T_SPAN == 0;

            int i = t / T_SPAN;
            int j = r / R_SPAN - 1;

            if (isOnArc && isOnLineSeg)
            {
                yield return GetNum(i, j);
            }
            else if (isOnArc)
            {
                yield return GetNum(i, j);
                yield return GetNum(i + 1, j);
            }
            else if (isOnLineSeg)
            {
                yield return GetNum(i, j);
                yield return GetNum(i, j + 1);
            }
            else
            {
                yield return GetNum(i, j);
                yield return GetNum(i, j + 1);
                yield return GetNum(i + 1, j);
                yield return GetNum(i + 1, j + 1);
            }
        }

        private static int GetNum(int i, int j)
        {
            return (5 * i + j) + 1;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0360
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ab = RArInt();
            int n = RInt();

            bool overlap = false;
            for (int i = 0; i < n; i++)
            {
                int[] sf = RArInt();
                if (IsOverlap(ab, sf))
                {
                    overlap = true;
                    break;
                }
            }
            Console.WriteLine(overlap ? 1 : 0);
        }

        private static bool IsOverlap(int[] ab, int[] sf)
        {
            if (ab[1] <= sf[0] || sf[1] <= ab[0]) return false;
            else return true;
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

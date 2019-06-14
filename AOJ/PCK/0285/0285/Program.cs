using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0285
{
    class Program
    {

        static int endJ;
        static int endY;
        static void Main(string[] args)
        {
            int[] jy = RArInt();
            endJ = jy[0]; endY = jy[1];
            Print(string.Empty, 0, 0);
        }

        private static void Print(string s, int j, int y)
        {
            if (j == endJ && y == endY)
            {
                Console.WriteLine(s);
            }
            else if (j <= endJ && y <= endY)
            {
                if (Math.Max(j, y) == 5 && Math.Min(j, y) <= 3) return;
                if (j < endJ) Print(s + "A", j + 1, y);
                if (y < endY) Print(s + "B", j, y + 1);
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

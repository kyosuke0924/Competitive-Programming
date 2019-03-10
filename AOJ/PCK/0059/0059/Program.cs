using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0059
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                double[] items = Array.ConvertAll(line.Trim().Split(' '), e => double.Parse(e));

                double xa1 = items[0]; double ya1 = items[1]; double xa2 = items[2]; double ya2 = items[3];
                double xb1 = items[4]; double yb1 = items[5]; double xb2 = items[6]; double yb2 = items[7];

                bool xCross = xa1 <= xb2 && xb1 <= xa2;
                bool yCross = ya1 <= yb2 && yb1 <= ya2;

                string res = (xCross && yCross) ? "YES" : "NO";

                Console.WriteLine(res);
            }
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}

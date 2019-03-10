using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0108
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int[] arr = RIntAr();
                int[] before = Enumerable.Repeat(int.MaxValue, n).ToArray();

                int cnt = -1;
                while (!arr.SequenceEqual(before))
                {
                    arr.CopyTo(before, 0);
                    arr = before.Select(x => before.Count(y => y == x)).ToArray();
                    cnt++;
                }
                Console.WriteLine(cnt);
                Console.WriteLine(WAr(arr));
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

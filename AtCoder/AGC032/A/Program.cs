using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = RInt();
            int[] vs = RIntAr();

            if (n != vs.Count() || vs.Contains(1) == false)
            {
                Console.WriteLine(-1);
                return;
            }

            if (vs.Count() == 1)
            {
                Console.WriteLine(vs[0] == 1 ? 1 : -1);
                return;
            }

            for (int i = 1; i < vs.Length; i++)
            {
                vs.Take(i).Where(x => x < i).Count();
            }

            Console.WriteLine(n);
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

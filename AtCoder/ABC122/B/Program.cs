using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B
{
    public class Program

    {
        public static void Main(string[] args)
        {
            string s = RSt();

            int cnt = 0;
            int res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'A' || s[i] == 'C' || s[i] == 'G' || s[i] == 'T') cnt++;
                else cnt = 0;
                res = Math.Max(res, cnt);
            }
            Console.WriteLine(res);
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

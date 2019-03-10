using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0050
{
    public class Program

    {
        public static void Main(string[] args)
        {
            const string APPLE = "apple";
            const string PEACH = "peach";
            const string TMP = "あいうえお";

            string line = RSt();
            line = line.Replace(APPLE, TMP);
            line = line.Replace(PEACH, APPLE);
            line = line.Replace(TMP, PEACH);
            Console.WriteLine(line);
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

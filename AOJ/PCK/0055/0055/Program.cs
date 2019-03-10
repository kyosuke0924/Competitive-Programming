using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0055
{
    public class Program

    {
        public static void Main(string[] args)
        {
            decimal factor = 211 / (decimal)Math.Pow(3, 3);    //211 = 81+54+36+24+16(3^4,3^3*2^1,3^2*2^2,3^1*2^3,2^4)
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;
                Console.WriteLine(decimal.Parse(line) * factor);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0316
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] h = RArInt();
            int[] k = RArInt();
            int[] abcd = RArInt();

            string res = "";
            int hScore = h[0] * abcd[0] + h[1] * abcd[1] + h[0] / 10 * abcd[2] + h[1] / 20 * abcd[3];
            int kScore = k[0] * abcd[0] + k[1] * abcd[1] + k[0] / 10 * abcd[2] + k[1] / 20 * abcd[3];

            if (hScore > kScore) res = "hiroshi";
            else if (kScore > hScore) res = "kenjiro";
            else res = "even";

            Console.WriteLine(res);
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

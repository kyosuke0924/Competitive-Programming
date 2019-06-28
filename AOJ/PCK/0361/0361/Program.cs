using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0361
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] xy = RArInt();
            int x = xy[0], y = xy[1];
            Console.WriteLine(x + y - Gcd(x, y) + 1);
        }

        ///最大公約数
        /// </summary>
        public static long Gcd(long a, long b)
        {
            if (a < b) return Gcd(b, a);  // 引数を入替えて自分を呼び出す
            if (b == 0) return a; //一方が0の場合は、もう片方の数自身がGCD

            long d = 0;
            do
            {
                d = a % b;
                a = b;
                b = d;
            } while (d != 0);
            return a;
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

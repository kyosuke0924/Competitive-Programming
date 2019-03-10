using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0197
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] items = RIntAr();
                if (items.Sum() == 0) break;

                int cnt = 0;
                long res = Gcd(items[0], items[1], ref cnt);

                Console.WriteLine("{0} {1}", res, cnt);
            }
        }


        /// <summary>
        ///最大公約数
        /// </summary>
        public static long Gcd(long a, long b, ref int cnt)
        {
            if (a < b) return Gcd(b, a, ref cnt);  // 引数を入替えて自分を呼び出す
            if (b == 0) return a; //一方が0の場合は、もう片方の数自身がGCD

            long d = 0;
            do
            {
                cnt++;
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
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}

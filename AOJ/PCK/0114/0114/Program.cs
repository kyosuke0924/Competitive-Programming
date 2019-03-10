using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0114
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                long[] items = RLongAr();
                if (items.Sum() == 0) break;

                long a1 = items[0]; long m1 = items[1];
                long a2 = items[2]; long m2 = items[3];
                long a3 = items[4]; long m3 = items[5];

                long x1 = 1, x2 = 1, x3 = 1;
                int cnt1 = 0, cnt2 = 0, cnt3 = 0;

                do { x1 = (a1 * x1) % m1; cnt1++; } while (x1 != 1);
                do { x2 = (a2 * x2) % m2; cnt2++; } while (x2 != 1);
                do { x3 = (a3 * x3) % m3; cnt3++; } while (x3 != 1);

                Console.WriteLine(Lcm(Lcm(cnt1,cnt2),cnt3));
            }

        }

        /// <summary>
        ///最小公倍数
        /// </summary>
        public static long Lcm(long a, long b)
        {
            return a / Gcd(a, b) * b;
        }

        /// <summary>
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
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0211
{
    public class Program

    {
        public static void Main(string[] args)
        {

            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                long[] d = new long[n];
                long[] v = new long[n];

                long lcm = 0;
                long gcd = 0;
                for (int i = 0; i < n; i++)
                {
                    long[] items = RLongAr();
                    long g = Gcd(items[0], items[1]);
                    d[i] = items[0] / g;
                    v[i] = items[1] / g;

                    if (i == 0)
                    { 
                        lcm = d[i]; gcd = v[i];
                    }
                    else
                    {
                        lcm = Lcm(lcm, d[i]); gcd = Gcd(gcd, v[i]);
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(lcm / d[i] * v[i] / gcd);
                }

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

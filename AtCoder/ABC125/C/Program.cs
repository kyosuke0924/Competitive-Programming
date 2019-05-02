using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = RInt();
            int[] a = RArInt();

            long[] beforeI = new long[n];
            long[] afterI = new long[n];

            long gcd = 0;
            for (int i = 0; i < n; i++)
            {
                gcd = Gcd(gcd, a[i]);
                beforeI[i] = gcd;
            }

            gcd = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                gcd = Gcd(gcd, a[i]);
                afterI[i] = gcd;
            }

            gcd = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (i == 0)
                {
                    gcd = Math.Max(gcd, Gcd(0, afterI[i + 1]));
                }
                else if (i == a.Length - 1)
                {
                    gcd = Math.Max(gcd, Gcd(beforeI[i - 1], 0));
                }
                else
                {
                    gcd = Math.Max(gcd, Gcd(beforeI[i - 1], afterI[i + 1]));
                }
            }
            Console.WriteLine(gcd);
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
        static string[] RArSt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RArInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RArLong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RArDouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E
{
    class Program
    {
        const int MOD = 1000003;

        static void Main(string[] args)
        {
            int q = RInt();
            for (int i = 0; i < q; i++)
            {
                Run();
            }
        }

        private static void Run()
        {
            int[] vs = RArInt();
            int x = vs[0];
            int d = vs[1];
            int n = vs[2]; 
            Console.WriteLine(Factorial(n,MOD) * Factorial(-vs[2], MOD) * nCr());

        }

        /// <summary>
        ///組み合わせの数
        /// </summary>
        public static double nCr(double n, double r, long mod = 0)
        {
            checked
            {
                double ans = 1;
                if (r > n / 2) return nCr(n, n - r, mod);//計算量を減らす(5C4 = 5C1)
                long div = 1;
                for (int i = 0; i < r; i++)
                {
                    ans *= n - i;
                    div *= i + 1;
                    if (mod != 0)
                    {
                        ans %= mod;
                        div %= mod;
                    }
                }

                if (mod != 0)
                {
                    ans *= Powmod(div, mod - 2, mod);
                    return ans % mod;
                }
                else return ans / div;

            }
        }

        /// <summary>
        ///mod下での累乗計算
        /// </summary>
        public static long Powmod(long a, long p, long mod)
        {
            checked
            {
                long ans = 1;
                long mul = a;
                for (; p > 0; p >>= 1, mul = (mul * mul) % mod)
                {
                    if ((p & 1) == 1) ans = (ans * mul) % mod;
                }
                return ans;
            }
        }

        public static long Factorial(long n, long mod = 0)
        {
            checked
            {
                if (n == 0) return 1L;
                if (mod == 0)
                { return n * Factorial(n - 1); }
                else
                { return n * Factorial(n - 1, mod) % mod; }
            }
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

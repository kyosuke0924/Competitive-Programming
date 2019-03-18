using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
    public class MathX
    {
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
            if (a < b)  return Gcd(b, a);  // 引数を入替えて自分を呼び出す
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

        /// <summary>
        ///素因数分解（ポラード・ロー素因数分解法）
        /// </summary>
        public static IEnumerable<long> PrimeFactor(long n)
            {
                while (n > 1)
                {
                    long factor = GetFactor(n);
                    yield return factor;
                    n = n / factor;
                }
            }

         private static long GetFactor(long n, int seed = 1)
            {
                if (n % 2 == 0)  return 2;
                if (IsPrime(n))  return n;
                long x = 2, y = 2, d = 1;
                long count = 0;
                while (d == 1)
                {
                    count++;
                    x = f(x, n, seed);
                    y = f(f(y, n, seed), n, seed);
                    d = Gcd(Math.Abs(x - y), n);
                }
                if (d == n)
                    // 見つからなかった、乱数発生のシードを変えて再挑戦。
                    return GetFactor(n, seed + 1);
                // 素数でない可能性もあるので、再度呼び出す
                return GetFactor(d);
            }

            private static int[] seeds = new int[] { 3, 5, 7, 11, 13, 17 };
            private static long f(long x, long n, int seed)
            {return (seeds[seed % 6] * x + seed) % n;}

        /// <summary>
        ///素数判定
        /// </summary>
        public static bool IsPrime(long number)
        {
            long boundary = (long)Math.Floor(Math.Sqrt(number));

            if (number == 1)  return false;
            if (number == 2)  return true;

            for (long i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        /// <summary>
        /// 整数の約数を列挙する(未ソート)
        /// </summary>
        /// <param name="n">整数</param>
        /// <returns>約数の列挙子</returns>
        public static IEnumerable<long> GetDivisor(long n)
        {
            long boundary = (long)Math.Floor(Math.Sqrt(n));
            for (int i = 1; i <= boundary; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    if (i != n / i) yield return n / i;
                }
            }
        }

        /// <summary>
        ///階乗
        /// </summary>
        public static long Factorial(long n, long mod = 0)
        {
            checked
            {
                if (n == 0)  return 1L;
                if (mod == 0)
                { return n * Factorial(n - 1); }
                else
                { return n * Factorial(n - 1, mod) % mod; }           
            }
        }

        /// <summary>
        ///mod下での累乗計算
        /// </summary>
        public static  long Powmod(long a, long p,long mod)
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

        /// <summary>
        /// 逆元（拡張ユークリッド互除法）
        /// </summary>
        /// <param name="a">値（法と互いに素であることが前提条件）</param>
        /// <param name="m">法</param>
        /// <returns></returns>
        private static long Modinv(long a, long m)
        {
            long b = m;
            long u = 1;
            long v = 0;
            while (b != 0)
            {
                long t = a / b;
                a -= t * b;
                Swap(ref a, ref b);
                u -= t * v;
                Swap(ref u, ref v);
            }
            u %= m;
            if (u < 0) u += m;
            return u;
        }
        public static void Swap<T>(ref T v1, ref T v2) { var tmp = v1; v1 = v2; v2 = tmp; }

        /// <summary>
        /// 連立一次方程式の解を求める(ax + by + c = 0)
        /// </summary>
        /// <param name="a">式1のxの係数</param>
        /// <param name="b">式1のyの係数</param>
        /// <param name="c">式1の切片</param>
        /// <param name="d">式2のxの係数</param>
        /// <param name="e">式2のyの係数</param>
        /// <param name="f">式2の切片</param>
        /// <returns>x,yの値の配列</returns>
        public static double[] SolveSimultaneousLinearEquation(double a, double b, double c, double d, double e, double f)
        {
            double x = -(c * e - b * f) / (a * e - b * d);
            double y = -(c * d - a * f) / (b * d - a * e);
            double[] res = new double[2];
            res[0] = x; res[1] = y;
            return res;
        }

        //半径dの円の交差判定
        private static bool isOverlapped(decimal x1, decimal y1, decimal x2, decimal y2, decimal d)
        {
            decimal dSquare = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
            return Math.Round(dSquare, 6, MidpointRounding.AwayFromZero) > d * d ? false : true;
        }

        //半径が1の円同士の交点を求める
        private static List<Tuple<decimal, decimal>> GetCrossPoint(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            double d = Math.Sqrt((double)((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
            double theta = Math.Atan2((double)(y2 - y1), (double)(x2 - x1));
            double a = Math.Acos(d / 2);

            decimal p1x = x1 + (decimal)Math.Cos(theta + a);
            decimal p2x = x1 + (decimal)Math.Cos(theta - a);

            decimal p1y = y1 + (decimal)Math.Sin(theta + a);
            decimal p2y = y1 + (decimal)Math.Sin(theta - a);

            return new List<Tuple<decimal, decimal>>() { new Tuple<decimal, decimal>(p1x, p1y), new Tuple<decimal, decimal>(p2x, p2y) };
        }
    }

}

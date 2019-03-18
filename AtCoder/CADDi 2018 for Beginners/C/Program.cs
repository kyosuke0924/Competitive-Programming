using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            long[] items = RLongAr();
            var primes = PrimeFactor(items[1]);

            Dictionary<long, long> dic = new Dictionary<long, long>();
            foreach (long item in primes)
            {
                if (!dic.ContainsKey(item)) dic.Add(item, 0);
                dic[item]++;
            }

            long res = 1;
            foreach (var item in dic)
            {
                res *= (item.Value / items[0]) > 0 ?  (long)Math.Pow(item.Key, (item.Value / items[0])): 1;
            }
            Console.WriteLine(res);
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
            if (n % 2 == 0) return 2;
            if (IsPrime(n)) return n;
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

        /// <summary>
        ///素数判定
        /// </summary>
        public static bool IsPrime(long number)
        {
            long boundary = (long)Math.Floor(Math.Sqrt(number));

            if (number == 1) return false;
            if (number == 2) return true;

            for (long i = 2 ; i <= boundary ; ++i)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        private static int[] seeds = new int[] { 3, 5, 7, 11, 13, 17 };
        private static long f(long x, long n, int seed)
        { return (seeds[seed % 6] * x + seed) % n; }

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

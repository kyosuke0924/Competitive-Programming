using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0185
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] primes = new int[1000001];
            primes[2] = 1;
            for (int i = 3 ; i < 1000000 ; i += 2)
            {
                if (IsPrime(i)) primes[i] = 1;
            }

            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int cnt = 0;
                for (int i = 0 ; i < n / 2 + 1 ; i++)
                {
                    if (primes[i] == 1 &&  primes[n -i] == 1) cnt++;
                }
                Console.WriteLine(cnt);
            }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0150
{
    public class Program

    {
        public static void Main(string[] args)
        {
            SortedSet<int> primes = new SortedSet<int>();
            for (int i = 2 ; i <= 10000 ; i++) if (IsPrime(i)) primes.Add(i);

            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                if (n % 2 == 0) n--;
                for (int i = n ; i >= 5 ; i -= 2)
                {
                    if (primes.Contains(i) && primes.Contains(i - 2))
                    {
                        Console.WriteLine("{0} {1}", i - 2, i);
                        break;
                    }
                }
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

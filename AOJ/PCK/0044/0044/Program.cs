using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0044
{
    public class Program

    {
        public static void Main(string[] args)
        {

            List<int> primes = new List<int>(25000);
            for (int i = 2 ; i <= 50000 ; i++) if (IsPrime(i)) primes.Add(i);

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int n = int.Parse(line);
                Console.WriteLine("{0} {1}", primes.Where(x => x < n).Max(), primes.Where(x => x > n).Min());
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
            if (number % 2 == 0) return false;

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

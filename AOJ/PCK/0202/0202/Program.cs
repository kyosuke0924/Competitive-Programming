using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0202
{
    public class Program

    {
        public static void Main(string[] args)
        {
            bool[] primes = new bool[1000001];
            for (int i = 0 ; i < primes.Length ; i++) if (IsPrime(i)) primes[i] = true;

            while (true)
            {
                int[] nx = RIntAr();
                if (nx.Sum() == 0) break;

                int[] dish = new int[nx[0]];
                for (int i = 0 ; i < dish.Length ; i++) dish[i] = RInt();

                bool[] combination = new bool[nx[1] + 1];
                combination[0] = true;

                for (int i = 0 ; i < combination.Length ; i++)
                {
                    if (combination[i])
                    {
                        for (int j = 0 ; j < dish.Length ; j++)
                        {
                            if (i + dish[j] < combination.Length) combination[i + dish[j]] = true;
                        }
                    }
                }

                Console.WriteLine(GetRes(primes, combination));
            }
        }

        private static string GetRes(bool[] primes, bool[] combination)
        {
            for (int i = combination.Length - 1 ; i >= 1 ; i--)
            {
                if (primes[i] && combination[i])
                {
                    return i.ToString();
                }
            }
            return "NA";
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

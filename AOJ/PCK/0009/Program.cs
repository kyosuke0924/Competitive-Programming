using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0009
{
    public class Program

    {
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

        public static void Main(string[] args)
        {
            int[] primeCount = new int[1000000];
            primeCount[1] = 0;
            primeCount[2] = 1;

            for (int i = 3 ; i < primeCount.Length  ; i++)
            {
                if (IsPrime(i)) primeCount[i] = primeCount[i - 1] + 1;
                else primeCount[i] = primeCount[i - 1];
            }

            while (true)
            {
                string line = ReadSt();
                if (line == null) break;
                Console.WriteLine(primeCount[int.Parse(line)]);
            }
        }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }
        static string WriteAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }

    }

}

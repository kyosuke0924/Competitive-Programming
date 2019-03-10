using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0181
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] nm = RIntAr();
                if (nm.Sum() == 0) break;

                int[] books = new int[nm[1]];
                for (int i = 0 ; i < nm[1] ; i++) books[i] = RInt();

                int left = -1;
                int right = 1500000;

                while (right - left > 1)
                {
                    int mid = (left + right) / 2;
                    if (CanStore(mid, nm[0], books)) right = mid; else left = mid;
                }

                Console.WriteLine(right);
            }

        }

        private static bool CanStore(int width, int MaxSteps, int[] books)
        {
            int steps = 1;
            int sum = 0;

            for (int i = 0 ; i < books.Length ; i++)
            {
                if (books[i] > width) return false;
                if (sum + books[i] > width)
                {
                    steps++;
                    sum = books[i];
                }
                else
                {
                    sum += books[i];
                }
            }

            return steps <= MaxSteps;
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

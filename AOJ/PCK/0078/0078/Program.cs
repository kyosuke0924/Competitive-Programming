using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0078
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int[,] map = new int[n, n];

                int x = n / 2;
                int y = n / 2 + 1;

                for (int i = 1 ; i <= Math.Pow(n, 2) ; i++)
                {
                    map[y, x] = i;
                    x = (x + 1) % n;
                    y = (y + 1) % n;
                    if (map[y, x] != 0)
                    {
                        x = (x + (n - 1)) % n;
                        y = (y + 1) % n;
                    }
                }

                for (int i = 0 ; i < n ; i++)
                {
                    for (int j = 0 ; j < n ; j++)
                    {
                        Console.Write(map[i, j].ToString().PadLeft(4));
                    }
                    Console.Write(Environment.NewLine);
                }
            }
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

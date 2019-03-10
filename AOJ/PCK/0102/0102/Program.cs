using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0102
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int[] colSum = new int[n + 1];
                for (int i = 0 ; i < n ; i++)
                {
                    int[] items = RIntAr();
                    for (int j = 0 ; j <= n ; j++)
                    {
                        if (j < n)
                        {
                            Console.Write(items[j].ToString().PadLeft(5));
                            colSum[j] += items[j];
                        }
                        else
                        {
                            Console.Write(items.Sum().ToString().PadLeft(5));
                            Console.Write(Environment.NewLine);
                            colSum[j] += items.Sum();
                        }
                    }               
                }
                for (int i = 0 ; i <= n ; i++) Console.Write(colSum[i].ToString().PadLeft(5));
                Console.Write(Environment.NewLine);
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

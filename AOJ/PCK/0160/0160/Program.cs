using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0160
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int sum = 0;
                for (int i = 0 ; i < n ; i++)
                {
                    int[] items = RIntAr();
                    int l = items[0] + items[1] + items[2];
                    int w = items[3];

                    if (l > 160 || w > 25) continue;
                    else if (l > 140 || w > 20) sum += 1600;
                    else if (l > 120 || w > 15) sum += 1400;
                    else if (l > 100 || w > 10) sum += 1200;
                    else if (l > 80 || w > 5) sum += 1000;
                    else if (l > 60 || w > 2) sum += 800;
                    else sum += 600;
                }
                Console.WriteLine(sum);
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

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
            int[] nm = RIntAr();
            int n = nm[0];
            int m = nm[1];

            if (n >= m)
            {
                Console.WriteLine(0);
            }
            else
            {
                int[] items = RIntAr();

                int cnt = 0;
                int sum = 0;

                Array.Sort(items);
                int[] distance = new int[items.Length - 1];
                for (int i = 1 ; i < items.Length ; i++)
                {
                    distance[i - 1] = items[i] - items[i - 1];
                }

                foreach (var item in distance.OrderBy(x => x))
                {
                    sum += item;
                    cnt++;
                    if (cnt == (m - n)) break;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0034
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int[] items = Array.ConvertAll(line.Trim().Split(','), e => int.Parse(e));

                int[] lengths = items.Take(10).ToArray();
                int v1 = items[10];
                int v2 = items[11];

                double intersectionL = lengths.Sum() * v1 / (double)(v1 + v2);

                double lengthSum = 0;
                for (int i = 0 ; i < lengths.Length ; i++)
                {
                    lengthSum += lengths[i];
                    if (lengthSum >= intersectionL)
                    {
                        Console.WriteLine(i + 1);
                        break;
                    }
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

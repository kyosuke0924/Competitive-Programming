using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0045
{
    public class Program

    {
        public static void Main(string[] args)
        {

            List<Tuple<int, int>> salesInformation = new List<Tuple<int, int>>();
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                int[] items = Array.ConvertAll(line.Trim().Split(','), e => int.Parse(e));
                salesInformation.Add(new Tuple<int, int>(items[0], items[1]));
            }

            Console.WriteLine(salesInformation.Select(x => x.Item1 * x.Item2).Sum());
            Console.WriteLine(Math.Round(salesInformation.Select(x => x.Item2).Average(),0,MidpointRounding.AwayFromZero));
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

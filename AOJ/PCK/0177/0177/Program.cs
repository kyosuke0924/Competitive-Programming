using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0177
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                double[] items = RDoubleAr();
                if (items.All(x => x == -1)) break;
                Console.WriteLine(Math.Round(GetDistance(items),0,MidpointRounding.AwayFromZero));
            }
        }

        private static double GetDistance(double[] items)
        {
            const double R = 6378.1;

            double lat1 = items[0];
            double lng1 = items[1];
            double lat2 = items[2];
            double lng2 = items[3];

            double theta = Math.Cos(lat1 / 180 * Math.PI) *
                           Math.Cos((lng2 - lng1) / 180 * Math.PI) *
                           Math.Cos(lat2 / 180 * Math.PI) +
                           Math.Sin(lat1 / 180 * Math.PI) *
                           Math.Sin(lat2 / 180 * Math.PI);

            return R * Math.Acos(theta);
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

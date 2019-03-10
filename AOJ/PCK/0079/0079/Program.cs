using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0079
{
    public class Program

    {
        public static void Main(string[] args)
        {
            List<Tuple<double, double>> points = new List<Tuple<double, double>>();
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                double[] items = Array.ConvertAll(line.Trim().Split(','), e => double.Parse(e));
                points.Add(new Tuple<double, double>(items[0], items[1]));
            }

            double sum = 0;
            for (int i = 0 ; i < points.Count() - 2 ; i++)
            {
                double edge1 = Math.Sqrt(Math.Pow(points[i + 1].Item1 - points[0].Item1, 2) + (Math.Pow(points[i + 1].Item2 - points[0].Item2, 2)));
                double edge2 = Math.Sqrt(Math.Pow(points[i + 2].Item1 - points[0].Item1, 2) + (Math.Pow(points[i + 2].Item2 - points[0].Item2, 2)));
                double edge3 = Math.Sqrt(Math.Pow(points[i + 2].Item1 - points[i + 1].Item1, 2) + (Math.Pow(points[i + 2].Item2 - points[i + 1].Item2, 2)));

                double z = (edge1 + edge2 + edge3) / 2;
                sum += Math.Sqrt(z * (z - edge1) * (z - edge2) * (z - edge3));
            }
            Console.WriteLine(sum);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABC113_B
{
    public class Program

    {

        public struct Point
        {
            public int index;
            public double DifferenceWithTargetTemperature;

            public Point(int i, double v) 
            {
                this.index = i;
                this.DifferenceWithTargetTemperature = v;
            }
        }

        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] line = ReadIntAr();
            int t = line[0];
            int a = line[1];
            int[] points = ReadIntAr();

            List<Point> items = new List<Point>();

            for (int i = 0 ; i < points.Count() ; i++)
            {
                items.Add(new Point(i, Math.Abs(a - (t - 0.006 * points[i]))));
            }

            Console.WriteLine(items.OrderBy(x => x.DifferenceWithTargetTemperature).First().index + 1);
        }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }

    }

}

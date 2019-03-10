using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0166
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int m = RInt(); if (m == 0) break;

                double mArea = 0;
                int mAngleSum = 0;
                for (int i = 0 ; i < m - 1 ; i++)
                {
                    int angle = RInt();
                    mArea += GetTriangleArea(angle);
                    mAngleSum += angle;
                }
                mArea += GetTriangleArea(360 - mAngleSum);

                int n = RInt();

                double nArea = 0;
                int nAngleSum = 0;
                for (int i = 0 ; i < n - 1 ; i++)
                {
                    int angle = RInt();
                    nArea += GetTriangleArea(angle);
                    nAngleSum += angle;
                }
                nArea += GetTriangleArea(360 - nAngleSum);

                if (Math.Abs(mArea - nArea) <= 1e-10) Console.WriteLine(0);
                else if (mArea > nArea) Console.WriteLine(1);
                else Console.WriteLine(2);

            }
        }

        private static double GetTriangleArea(int angle)
        {
            double rAngle = (angle * Math.PI / 180);
            return  Math.Sin(rAngle / 2) * Math.Cos(rAngle / 2);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0010
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            for (int i = 0 ; i < n ; i++)
            {
                double[] line = ReadDoubleAr();
                double x1 = line[0];
                double y1 = line[1];
                double x2 = line[2];
                double y2 = line[3];
                double x3 = line[4];
                double y3 = line[5];

                double a = 2 * x2 - 2 * x1;
                double b = 2 * y2 - 2 * y1;
                double c = (x1 * x1 + y1 * y1) - (x2 * x2 + y2 * y2);
                double d = 2 * x3 - 2 * x1;
                double e = 2 * y3 - 2 * y1;
                double f = (x1 * x1 + y1 * y1) - (x3 * x3 + y3 * y3);

                double[] resXY = SolveSimultaneousLinearEquation(a, b, c, d, e, f);
                double r = Math.Sqrt(Math.Pow(resXY[0] - x1, 2) + Math.Pow(resXY[1] - y1, 2));

                Console.WriteLine("{0} {1} {2}"
                    , Math.Round(resXY[0], 3, MidpointRounding.AwayFromZero).ToString("F3")
                    , Math.Round(resXY[1], 3, MidpointRounding.AwayFromZero).ToString("F3")
                    , Math.Round(r, 3, MidpointRounding.AwayFromZero).ToString("F3"));
            }
        }

        /// <summary>
        /// 連立一次方程式の解を求める(ax + by + c = 0)
        /// </summary>
        /// <param name="a">式1のxの係数</param>
        /// <param name="b">式1のyの係数</param>
        /// <param name="c">式1の切片</param>
        /// <param name="d">式2のxの係数</param>
        /// <param name="e">式2のyの係数</param>
        /// <param name="f">式2の切片</param>
        /// <returns>x,yの値の配列</returns>
        public static double[] SolveSimultaneousLinearEquation(double a, double b, double c, double d, double e, double f)
        {
            double x = -(c * e - b * f) / (a * e - b * d);
            double y = -(c * d - a * f) / (b * d - a * e);
            double[] res = new double[2];
            res[0] = x; res[1] = y;
            return res;
        }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }
        static string WriteAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }

    }

}

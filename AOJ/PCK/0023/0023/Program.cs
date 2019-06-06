using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0023
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            for (int i = 0 ; i < n ; i++)
            {
                double[] items = ReadDoubleAr();
                double r1 = items[2];
                double r2 = items[5];
                double d = Math.Sqrt(Math.Pow(items[3] - items[0], 2) + Math.Pow(items[4] - items[1], 2));

                int res = 0;
                if (r1 > r2 && d < r1 - r2) res = 2; //円1の内部に円2
                else if (r1 < r2 && d < r2 - r1) res = -2; //円2の内部に円1
                else if (d <= r1 + r2) res = 1; //円1と円2が共有点を持つ
                Console.WriteLine(res);
            }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0016
{
    public class Program

    {
        public static void Main(string[] args)
        {
            double x = 0;
            double y = 0;
            int degrees= 90;

            while (true)
            {
                int[] line = ReadIntAr(',');
                if (line[0] + line[1] == 0) break;

                x += Math.Cos(degrees * Math.PI / 180) * line[0];
                y += Math.Sin(degrees * Math.PI / 180) * line[0];
                degrees -= line[1];
            }

            Console.WriteLine((int)x);
            Console.WriteLine((int)y);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0004
{
    public class Program

    {
        public static void Main(string[] args)
        {

            while (true)
            {
                string line = Console.ReadLine();
                if (line == null) break;

                int[] items = Array.ConvertAll(line.Split(' '), k => int.Parse(k));
                int a = items[0];
                int b = items[1];
                int c = items[2];
                int d = items[3];
                int e = items[4];
                int f = items[5];

                decimal x = Math.Round((decimal)(c * e - b * f) / (a * e - b * d), 3, MidpointRounding.AwayFromZero);
                decimal y = Math.Round((decimal)(c * d - a * f) / (b * d - a * e), 3, MidpointRounding.AwayFromZero);
                Console.WriteLine("{0} {1}", x.ToString("F3"), y.ToString("F3"));
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

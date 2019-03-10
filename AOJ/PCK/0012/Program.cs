using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace _0012
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = ReadSt();
                if (line == null) break;

                double[] items = Array.ConvertAll(line.Split(' '), e => double.Parse(e));
                Vector a = new Vector(items[0], items[1]);
                Vector b = new Vector(items[2], items[3]);
                Vector c = new Vector(items[4], items[5]);
                Vector p = new Vector(items[6], items[7]);

                double c1 = Vector.CrossProduct(b - a, p - b);
                double c2 = Vector.CrossProduct(c - b, p - c);
                double c3 = Vector.CrossProduct(a - c, p - a);

                string res;
                if ((c1 > 0 && c2 > 0 && c3 > 0) || (c1 < 0 && c2 < 0 && c3 < 0))
                {
                    res = "YES";
                }
                else
                {
                    res = "NO";
                }
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

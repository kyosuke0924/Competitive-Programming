using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] line = ReadIntAr();
            int n = line[0];
            int k = line[1];

            List<int> items = new List<int>();

            for (int i = 0 ; i < n ; i++)
            {
                items.Add(ReadInt());
            }

            items.Sort();

            int res = int.MaxValue;
            for (int i = 0 ; i < n - (k - 1) ; i++)
            {
                res = Math.Min(res, items[i + (k - 1)] - items[i]);
            }

            Console.WriteLine(res.ToString());
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

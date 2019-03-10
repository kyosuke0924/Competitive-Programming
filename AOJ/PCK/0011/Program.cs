using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0011
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] items = new int[n];
            for (int i = 0 ; i < n ; i++) items[i] = i + 1;

            int m = ReadInt();
            for (int i = 0 ; i < m ; i++)
            {
                int[] line = ReadIntAr(',');
                Swap(items, line[0] - 1, line[1] - 1);
            }

            foreach (var item in items) Console.WriteLine(item);
        }

        private static void Swap(int[] items, int v1, int v2)
        {
            var tmp = items[v1]; items[v1] = items[v2]; items[v2] = tmp;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_4_B
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] line = ReadIntAr();

            int q = ReadInt();
            for (int i = 0 ; i < q ; i++)
            {
                int[] items = ReadIntAr();

                var before = line.Take(items[0]).ToArray();
                var rotateBefore = line.Skip(items[0]).Take(items[1] - items[0]).ToArray();
                var rotateAfter = line.Skip(items[1]).Take(items[2] - items[1]).ToArray();
                var after = line.Skip(items[2]).Take(line.Length - items[2]).ToArray();
                line = before.Concat(rotateAfter).Concat(rotateBefore).Concat(after).ToArray();
            }
            Console.WriteLine(WriteAr(line));
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

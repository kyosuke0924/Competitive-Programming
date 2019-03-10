using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_4_A
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
                var reversed = line.Skip(items[0]).Take(items[1] - items[0]).Reverse().ToArray();
                var after = line.Skip(items[1]).Take(line.Length - items[1]).ToArray();
                line = before.Concat(reversed).Concat(after).ToArray();
            }
            Console.WriteLine(WriteArray(line));
        }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }
        static string WriteArray(int[] array,string sep =" ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteArray(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteArray(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }

    }

}

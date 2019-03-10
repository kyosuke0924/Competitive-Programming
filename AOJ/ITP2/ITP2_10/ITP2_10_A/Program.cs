using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_10_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            const int  STL_LENGTH = 32;
            uint x = uint.Parse(Console.ReadLine());
            string[] res = new string[4];
            res[0] = Convert.ToString(x, 2).PadLeft(STL_LENGTH, '0');
            res[1] = Convert.ToString(~x, 2).PadLeft(STL_LENGTH, '0');
            res[2] = Convert.ToString(x << 1, 2).PadLeft(STL_LENGTH, '0');
            res[3] = Convert.ToString(x >> 1, 2).PadLeft(STL_LENGTH, '0');
            foreach (var item in res)
            {
                Console.WriteLine(item);
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

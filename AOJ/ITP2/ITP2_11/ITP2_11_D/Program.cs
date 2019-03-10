using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_11_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] line = ReadIntAr();
            for (int i = 0 ; i < (1 << line[0]) ; i++)
            {
                if (BitCount(i) == line[1])
                {
                    List<int> s = new List<int>(line[1]);
                    for (int j = 0 ; j < line[0] ; j++)
                    {
                        if ((i >> j & 1) == 1) s.Add(j);
                    }
                    Console.WriteLine("{0}:{1}", i, (s.Count == 0 ? "" : " ") + string.Join(" ", s.Select(x => x.ToString()).ToArray()));
                }
            }
        }

        private static int BitCount(int bits)
        {
            bits = (bits & 0x55555555) + (bits >> 1 & 0x55555555);    //  2bitごとに計算
            bits = (bits & 0x33333333) + (bits >> 2 & 0x33333333);    //  4bitごとに計算
            bits = (bits & 0x0f0f0f0f) + (bits >> 4 & 0x0f0f0f0f);    //  8bitごとに計算
            bits = (bits & 0x00ff00ff) + (bits >> 8 & 0x00ff00ff);    //  16ビットごとに計算   
            return (bits & 0x0000ffff) + (bits >> 16);       
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2104
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            for (int i = 0 ; i < n ; i++)
            {

                int[] line = ReadIntAr();
                int[] housesPosition = ReadIntAr();

                int[] houseRanges = new int[line[0] - 1];
                for (int j = 0 ; j < line[0] - 1 ; j++)
                {
                    houseRanges[j] = housesPosition[j + 1] - housesPosition[j];
                }

                Array.Sort(houseRanges);
                int res = 0;
                for (int j = 0 ; j < line[0]-line[1] ; j++)
                {
                    res += houseRanges[j];
                }
                Console.WriteLine(res.ToString());
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

    }

}

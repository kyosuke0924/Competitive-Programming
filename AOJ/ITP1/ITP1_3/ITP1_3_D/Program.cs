using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_3_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] line = ReadIntAr();
            int rlt = 0;
            for (int i = line[0]; i <= line[1];i++)
            {
                if (line[2] % i == 0) rlt++;
            }
            Console.WriteLine("{0}",rlt);
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

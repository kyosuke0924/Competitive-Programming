using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_3_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] line;
            int i, j;
            
            do
            {
                line = ReadIntAr();
                i = line[0];
                j = line[1];
                if (i == 0 && j == 0) return;
                else if( i<j) Console.WriteLine("{0} {1}", i, j);
                else Console.WriteLine("{0} {1}", j, i);
            } while (line != null);
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

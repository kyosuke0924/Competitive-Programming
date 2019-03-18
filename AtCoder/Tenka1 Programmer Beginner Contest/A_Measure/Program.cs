using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A_Measure
{
    public class Program

    {
        public static void Main(string[] args)
        {
            string line = ReadSt();

            if (line.Length == 2)
            {
                Console.WriteLine(line);
            }
            else
            {
                Console.WriteLine(line[2].ToString() + line[1].ToString() + line[0].ToString());
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

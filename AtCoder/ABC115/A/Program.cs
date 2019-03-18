using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int day = ReadInt();
            switch (day)
            {
                case 25:
                    Console.WriteLine("Christmas");
                    break;
                case 24:
                    Console.WriteLine("Christmas Eve");
                    break;
                case 23:
                    Console.WriteLine("Christmas Eve Eve");
                    break;
                case 22:
                    Console.WriteLine("Christmas Eve Eve Eve");
                    break;
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

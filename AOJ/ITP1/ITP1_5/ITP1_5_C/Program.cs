using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_5_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] line ;
            while (true)
            {
                line = ReadIntAr();
                if (line[0] == 0 && line[1] == 0) return;

                for (int i = 0; i < line[0]; i++)
                {
                    string tmp = string.Empty;
                    for (int j = 0; j < line[1]; j++)
                    {
                        if ((i + j) % 2 == 0) tmp += "#";
                        else tmp += ".";
                    }
                    Console.WriteLine("{0}", tmp);
                }
                Console.WriteLine("{0}", "");
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

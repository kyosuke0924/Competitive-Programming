using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_9_B
{
    public class Program

    {
        public static void Main(string[] args)
        {

            while (true)
            {
                string line = ReadSt();
                if (line.Equals("-")) return;

                int n = ReadInt();

                for (int i = 0 ; i < n ; i++)
                {
                    int x = ReadInt();
                    line = line.Substring(x, line.Length - x) + line.Substring(0, x);
                }
                Console.WriteLine(line);
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

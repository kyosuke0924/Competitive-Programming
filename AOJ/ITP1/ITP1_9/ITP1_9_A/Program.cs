using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_9_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            string target = ReadSt();
            int res = 0;

            while (true)
            {
                string[] line = ReadStAr();

                if (line[0].Equals("END_OF_TEXT")) break;
                res += line.Count(x => String.Compare(x, target, true) == 0);
            }

            Console.WriteLine(res.ToString());
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

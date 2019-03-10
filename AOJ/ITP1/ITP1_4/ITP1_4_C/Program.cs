using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_4_C
{
    public class Program

    {
        public static void Main(string[] args)
        {

            while(true)
            {

                string[] line = ReadStAr();
                int a = int.Parse(line[0]);
                string op = line[1];
                int b = int.Parse(line[2]);

                switch (op)
                {
                    case "?": return;
                    case "+": Console.WriteLine("{0}", a + b); break;
                    case "-": Console.WriteLine("{0}", a - b); break;
                    case "*": Console.WriteLine("{0}", a * b); break;
                    case "/": Console.WriteLine("{0}", a / b); break;
                }

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

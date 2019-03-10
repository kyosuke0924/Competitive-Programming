using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_8_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            string line = ReadSt();
            string target = ReadSt();

            for (int i = 0 ; i < line.Length ; i++)
            {
                string rS = line.Substring(i, line.Length - i) + line.Substring(0, i);
                if(rS.Contains(target))
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }

            Console.WriteLine("No");
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

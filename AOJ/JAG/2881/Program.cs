using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2881
{
    public class Program

    {
        const string NEW_ERA_NAME = "?";

        public static void Main(string[] args)
        {
            while (true)
            {
                string[] line = ReadStAr();
                if (line[0] == "#") break;
                string eraName = (int.Parse(line[1]+ line[2].PadLeft(2, '0')) < 3105) ? line[0] : NEW_ERA_NAME;
                string newYear = (eraName == line[0]) ? line[1] : (int.Parse(line[1]) - 30).ToString();
                Console.WriteLine("{0} {1} {2} {3}",eraName, newYear, line[2],line[3]);
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

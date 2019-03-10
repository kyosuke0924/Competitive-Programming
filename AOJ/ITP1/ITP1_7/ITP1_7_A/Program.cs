using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_7_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] line = ReadIntAr();
                if (line.All(x => x == -1)) return;

                string rlt = string.Empty;
                if (line[0] * line[1] < 0)
                {
                    rlt = "F";
                }
                else
                {

                    int sum = line[0] + line[1];

                    if (sum >= 80) rlt = "A";
                    else if (sum >= 65) rlt = "B";
                    else if (sum >= 50) rlt = "C";
                    else if (sum >= 30)
                    {
                        if (line[2] >= 50) rlt = "C";
                        else rlt = "D";
                    }
                    else rlt = "F";
                }

                Console.WriteLine(rlt);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_7_B
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] line = ReadIntAr();
                if (line.All(x => x == 0)) return;
                
                int rlt = 0;
                for (int i = 1 ; i <= line[0] ; i++)
                {
                    for (int j = i + 1; j <= line[0] ; j++)
                    {
                        for (int k = j + 1 ; k <= line[0] ; k++)
                        {
                            if (i + j + k == line[1]) rlt++;
                        }
                    }
                }
                Console.WriteLine(rlt.ToString());
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

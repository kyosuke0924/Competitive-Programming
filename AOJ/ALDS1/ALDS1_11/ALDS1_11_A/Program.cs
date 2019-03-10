using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_11_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[,] res = new int[n,n];

            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                for (int j = 0 ; j < line[1] ; j++)
                {
                    res[line[0]-1, line[j+2]-1] = 1;
                }
            }

            for (int i = 0 ; i < n ; i++)
            {
                for (int j = 0 ; j < n ; j++)
                {
                    if (j >0) Console.Write(" ");
                    Console.Write(res[i, j]);
                }
                Console.Write(Environment.NewLine);
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

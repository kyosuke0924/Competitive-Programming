using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_7_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] line = ReadIntAr();
            int[,] rlt = new int[line[0]+1, line[1]+1];

            for (int i = 0 ; i < line[0] ; i++)
            {
                int[] tmp = ReadIntAr();

                for (int j = 0 ; j < line[1] ; j++)
                {
                    rlt[i, j] = tmp[j];
                    rlt[i, line[1]] += tmp[j];
                    rlt[line[0], j] += tmp[j];
                    rlt[line[0], line[1]] += tmp[j];
                }
            }

            for (int i = 0 ; i <= line[0] ; i++)
            {

                for (int j = 0 ; j <= line[1] ; j++)
                {
                    Console.Write(rlt[i,j]);
                    if (j == line[1]) Console.Write(Environment.NewLine);
                    else Console.Write(" ");
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

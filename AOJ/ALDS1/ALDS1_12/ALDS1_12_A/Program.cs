using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace ALDS1_12_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            Graph gr = new Graph();
            int n = ReadInt();

            for (int i = 0 ; i < n ; i++)
            {
                gr.SetGraph(i);
                int[] line = ReadIntAr();
                for (int j = 0 ; j < n ; j++)
                {
                    if (line[j] != -1) gr.SetGraph(i,j, line[j]);
                }
            }

            int res = gr.Prim();
            Console.WriteLine(res);
        }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }

    }

}

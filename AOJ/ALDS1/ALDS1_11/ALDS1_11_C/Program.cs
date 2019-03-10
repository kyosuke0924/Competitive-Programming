using CompProgLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_11_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            Graph gr = new Graph();

            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                gr.SetGraph(line[0], line.Skip(2).ToArray());
            }

            gr.BFS(1);

            foreach (var item in gr.Adj)
            {
                Console.WriteLine("{0} {1}", item.Key, item.Value.Depth);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace ALDS1_12_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            Graph gr = new Graph();
            int n = ReadInt();

            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                gr.SetGraph(line[0]);
                for (int j = 0 ; j < line[1] ; j++)
                {
                    gr.SetGraph(line[0], line[j * 2 + 2], line[j * 2 + 3]);
                }
            }

            gr.Dijkstra(0);

            foreach (var item in gr.Adj)
            {
                Console.WriteLine("{0} {1}", item.Key, item.Value.Distance);
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

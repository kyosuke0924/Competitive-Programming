using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace ALDS1_11_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            Graph gr = new Graph();
            int[] line = ReadIntAr();
            for (int i = 0 ; i < line[0] ; i++)
            {
                gr.SetGraph(i, null);
            }

            for (int i = 0 ; i < line[1] ; i++)
            {
                int[] friends = ReadIntAr();
                gr.AddVertex(friends[0], friends[1]);
                gr.AddVertex(friends[1], friends[0]);
            }

            gr.SetGroup();

            int n = ReadInt();
            for (int i = 0 ; i < n ; i++)
            {
                int[] Connections = ReadIntAr();
                if (gr.Adj[Connections[0]].Group != gr.Adj[Connections[1]].Group)
                {
                    Console.WriteLine("no");
                }
                else
                {
                    Console.WriteLine("yes");
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

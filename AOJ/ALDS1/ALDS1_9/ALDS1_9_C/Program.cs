using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace ALDS1_9_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            string[] line;
            while (true)
            {
               line = ReadStAr();

                switch (line[0])
                {
                    case "end":
                        return;
                    case "insert":
                        pq.Enqueue(int.Parse(line[1]));
                        break;
                    case "extract":
                        Console.WriteLine(pq.Dequeue().ToString());
                        break;
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

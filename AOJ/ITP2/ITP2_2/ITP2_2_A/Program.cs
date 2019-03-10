using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_2_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] n = ReadIntAr();
            List<Stack<int>> li = new List<Stack<int>>();
            for (int i = 0 ; i < n[0] ; i++) li.Add(new Stack<int>()) ;

            for (int i = 0 ; i < n[1] ; i++)
            {
                int[] line = ReadIntAr();
                switch (line[0])
                {
                    case 0: li[line[1]].Push(line[2]); break;
                    case 1: if (li[line[1]].Count > 0) Console.WriteLine(li[line[1]].Peek().ToString()); break;
                    case 2: if (li[line[1]].Count > 0)li[line[1]].Pop(); break;
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

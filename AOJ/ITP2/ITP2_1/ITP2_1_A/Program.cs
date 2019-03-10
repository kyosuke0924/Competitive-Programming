using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_1_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            List<int> li = new List<int>();
            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                switch (line[0])
                {
                    case 0: li.Add(line[1]);break;
                    case 1: Console.WriteLine(li[line[1]].ToString()); break;
                    case 2: li.RemoveAt(li.Count - 1); break;
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

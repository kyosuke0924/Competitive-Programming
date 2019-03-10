using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_5_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            List<int> rlt = new List<int>();

            for(int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 || i.ToString().IndexOf('3') >= 0) rlt.Add(i);
            }

            Console.WriteLine(" " + string.Join(" ",rlt.Select(x => x.ToString()).ToArray()));
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

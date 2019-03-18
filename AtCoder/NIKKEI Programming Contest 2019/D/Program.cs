using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D
{
    public class Program

    {

        public class Edge
        {
            public int S { get; set; }
            public int E { get; set; }
            public Edge(int[] items)
            {
                S = items[0];
                E = items[1];
            }
        }


        public static void Main(string[] args)
        {
            int[] NM = RIntAr();

            int n = NM[0];
            int m = NM[1];
            List<Edge> edges = new List<Edge>(n - 1 + m);
            for (int i = 0 ; i < edges.Capacity ; i++)
            {
                edges.Add(new Edge(RIntAr()));
            }

            while (true)
            {




            }



            Console.WriteLine(n);
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}

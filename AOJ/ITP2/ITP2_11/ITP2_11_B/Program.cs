using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_11_B
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            List<int> s;

            int partialSet = 0;    
            foreach (var x in ReadIntAr().Skip(1)) partialSet |= (1 << x);

            for (int i = 0 ; i < (1 << n) ; i++)
            {
                s = new List<int>(n);
                for (int j = 0 ; j < n ; j++)
                {
                    if ((i >> j & 1) == 1) s.Add(j);
                }

                if ((i & partialSet) == partialSet)
                {
                    Console.WriteLine("{0}:{1}", i, (s.Count == 0 ? "" : " ") + string.Join(" ", s.Select(x => x.ToString()).ToArray()));
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
        static string WriteAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }

    }

}

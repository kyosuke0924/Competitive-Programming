using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_7_B
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                switch (line[0])
                {
                    case 0:
                        hs.Add(line[1]);
                        Console.WriteLine(hs.Count());
                        break;
                    case 1:
                        Console.WriteLine(hs.Contains(line[1]) ? 1 : 0);
                        break;
                    case 2:
                        hs.Remove(line[1]);
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
        static string WriteAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }

    }

}

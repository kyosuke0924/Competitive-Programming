using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_8_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            Dictionary<string,int> di = new Dictionary<string, int>();
            for (int i = 0 ; i < n ; i++)
            {
                string[] line = ReadStAr();
                switch (int.Parse(line[0]))
                {
                    case 0:
                        if (di.ContainsKey(line[1]))
                        {
                            di[line[1]] = int.Parse(line[2]);
                        }
                        else
                        {
                            di.Add(line[1], int.Parse(line[2]));
                        }
                        break;
                    case 1:
                        Console.WriteLine(di[line[1]]);
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

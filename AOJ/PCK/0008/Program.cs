using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0008
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = ReadSt();
                if (line == null) break;

                int n = int.Parse(line);
                int cnt = 0;
                for (int i = 0 ; i < 10 ; i++)
                {
                    for (int j = 0 ; j < 10 ; j++)
                    {
                        for (int k = 0 ; k < 10 ; k++)
                        {
                            for (int l = 0 ; l < 10 ; l++)
                            {
                                if (i + j + k + l == n) cnt++;
                            }
                        }
                    }
                }
                Console.WriteLine(cnt);
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

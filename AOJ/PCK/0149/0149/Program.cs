using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0149
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[,] res = new int[4, 2];
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                double[] eyeLR = Array.ConvertAll(line.Trim().Split(' '), e => double.Parse(e));

                for (int i = 0 ; i < eyeLR.Length ; i++)
                {
                    if (eyeLR[i] >= 1.1) res[0, i]++;
                    else if (eyeLR[i] >= 0.6) res[1, i]++;
                    else if (eyeLR[i] >= 0.2) res[2, i]++;
                    else res[3, i]++;
                }
            }

            for (int i = 0 ; i < res.GetLength(0) ; i++)
            {
                Console.WriteLine("{0} {1}", res[i, 0], res[i, 1]);
            }
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

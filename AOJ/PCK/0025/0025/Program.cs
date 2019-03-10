using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0025
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = RSt();
                if (line == String.Empty || line == null) break;
                int[] a = Array.ConvertAll(line.Trim().Split(' '), e => int.Parse(e));

                string line2 = RSt();
                if (line2 == String.Empty || line2 == null) break;
                int[] b = Array.ConvertAll(line2.Trim().Split(' '), e => int.Parse(e));

                int hit = 0;
                int blow = 0;
                for (int i = 0 ; i < a.Count() ; i++)
                {
                    if (a.Contains(b[i]))
                    {
                        if (a[i] == b[i]) hit++;
                        else blow++;
                    }
                }
                Console.WriteLine("{0} {1}", hit, blow);
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
        static string WAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WAr(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WAr(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }

    }

}

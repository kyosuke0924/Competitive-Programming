using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0136
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] res = new int[6];

            int n = RInt();
            for (int i = 0 ; i < n ; i++)
            {
                double measuredValue = RDouble();
                if (measuredValue < 165) res[0]++;
                else if (measuredValue < 170) res[1]++;
                else if (measuredValue < 175) res[2]++;
                else if (measuredValue < 180) res[3]++;
                else if (measuredValue < 185) res[4]++;
                else res[5]++;
            }
             
            for (int i = 0 ; i < res.Length ; i++) Console.WriteLine("{0}:{1}", i + 1, new string('*',res[i]));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] items = RIntAr();
            int n = items[0];
            int m = items[1];

            int[] rows = RIntAr();
            int[] cols = RIntAr();

            int MOD = (int)1E+9 + 7;

            long res = 1;
            for (int i = n * m ; i >= 1 ; i--)
            {

                if (rows.Contains(i) && cols.Contains(i))
                {
                    
                }
                else if (rows.Contains(i) && !cols.Contains(i))
                {
                    res = res * cols.Count(x => x >= i) % MOD;
                }
                else if (!rows.Contains(i) && cols.Contains(i))
                {
                    res = res * rows.Count(x => x >= i) % MOD ;
                }
                else
                {
                    res = res * (rows.Count(x => x >= i) * cols.Count(x => x >= i) - (n * m - i)) % MOD;
                }
            }


            Console.WriteLine(res);
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

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
            int q = items[1];

            int[] cards = RIntAr();
            int[] querys  = new int[q];

            int[] sums = new int[n];
            for (int i = 0 ; i < n ; i++)
            {
                if(i == 0)
                {
                    sums[i] = cards[i];
                }
                else
                {
                    sums[i] = sums[i-1] + cards[i];
                }
            }



            for (int i = 0 ; i < q ; i++)
            { 
                Console.WriteLine(RInt();
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

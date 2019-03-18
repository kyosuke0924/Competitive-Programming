using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C
{
    public class Program

    {
        class Shop
        {
            public long UnitPrice { get; set; }
            public long Stock { get; set; }
            public Shop(int[] v) { UnitPrice = v[0]; Stock = v[1]; }
        }


        public static void Main(string[] args)
        {
            int[] nm = RIntAr();
            int n = nm[0];
            int m = nm[1];

            Shop[] shops = new Shop[n];
            for (int i = 0 ; i < n ; i++)
            {
                shops[i] = new Shop(RIntAr());
            }

            long cost = 0;
            long cnt = 0;
            foreach (var shop in shops.OrderBy(x => x.UnitPrice))
            {

                if (cnt + shop.Stock <= m)
                {
                    cost += shop.UnitPrice * shop.Stock;
                    cnt += shop.Stock;
                }
                else
                {
                    cost += shop.UnitPrice * (m - cnt);
                    break;
                }             
            }
            Console.WriteLine(cost);
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

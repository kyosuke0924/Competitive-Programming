using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0186
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] items = RIntAr();
                if (items[0] == 0) break;
            
                Console.WriteLine(BuyChicken(items));
            }
        }

        private static string BuyChicken(int[] items)
        {
            int minPurchaseCount = items[0];
            int budget = items[1];
            int priceAChick = items[2];
            int priceNChick = items[3];
            int stockAChick = items[4];

            for (int i = stockAChick ; i > 0 ; i--)
            {
                int costAChick = priceAChick * i;
                if (costAChick > budget) continue;

                int cntNchick = (budget - costAChick) / priceNChick;
                if (i + cntNchick >= minPurchaseCount)
                {
                    return i.ToString() + " " + cntNchick.ToString();
                }
            }
            return "NA";
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

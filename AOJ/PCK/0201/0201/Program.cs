using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0201
{
    public class Program
    {
        public static Dictionary<string, int> prices;
        public static Dictionary<string, List<string>> alchemy;


        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt(); if (n == 0) break;

                Init(n);
                string name = RSt();
                Console.WriteLine(Math.Min(prices[name], GetPrice(name)));
            }
        }

        private static void Init(int n)
        {
            prices = new Dictionary<string, int>(n);
            for (int i = 0 ; i < n ; i++)
            {
                string[] items = RStAr();
                prices.Add(items[0],int.Parse(items[1]));
            }

            int m = RInt();
            alchemy = new Dictionary<string, List<string>>(m);
            for (int i = 0 ; i < m ; i++)
            {
                string[] items = RStAr();
                alchemy.Add(items[0], items.Skip(2).Select(x => x).ToList());
            }

        }

        private static int GetPrice(string name)
        {
            if (!alchemy.ContainsKey(name)) return prices[name];
            else
            {
                int sum = 0;
                foreach (var item in alchemy[name])
                {
                    sum += GetPrice(item);
                }
                return Math.Min(prices[name], sum);
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

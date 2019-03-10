using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0161
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                Dictionary<int, int> teams = new Dictionary<int, int>();
                for (int i = 0 ; i < n ; i++)
                {
                    int[] items = RIntAr();
                    int time = (items[1] + items[3] + items[5] + items[7]) * 60 + items[2] + items[4] + items[6] + items[8];
                    teams.Add(items[0], time);
                }
                int[] ranks = teams.OrderBy(x => x.Value).Select(x => x.Key).ToArray();
                Console.WriteLine(ranks[0]);
                Console.WriteLine(ranks[1]);
                Console.WriteLine(ranks[n - 2]);
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

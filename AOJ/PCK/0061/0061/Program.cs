using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0061
{
    public class Program

    {
        public static void Main(string[] args)
        {
            Dictionary<int, int> teams = new Dictionary<int, int>();
            while (true)
            {
                int[] items = RIntAr(',');
                if (items.Sum() == 0) break;
                teams.Add(items[0], items[1]);
            }

            Dictionary<int, int> ranks = new Dictionary<int, int>();
            int before = int.MaxValue;
            int rank = 0;
            foreach (var item in teams.OrderByDescending(x => x.Value))
            {
                if (before != item.Value) rank++;
                ranks.Add(item.Key, rank);
                before = item.Value;
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;
                Console.WriteLine(ranks[int.Parse(line)]);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0030
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] items = RIntAr();
                if (items.Sum() == 0) return;

                int cnt = 0;
                foreach (var item in Combination.GetCombination(Enumerable.Range(0, 10), items[0]))
                {
                    if (item.Sum() == items[1]) cnt++;
                }
                Console.WriteLine(cnt);
            }
        }

        public class Combination
        {
            public static IEnumerable<IEnumerable<T>> GetCombination<T>(IEnumerable<T> items, int r)
            {
                if (r == 0)
                {
                    yield return Enumerable.Empty<T>();
                }
                else
                {
                    var i = 0;
                    foreach (var x in items)
                    {
                        i++;
                        var xs = items.Skip(i);
                        foreach (var c in GetCombination(xs, r - 1)) yield return Concat(x, c);
                    }
                }
            }

            public static IEnumerable<T> Concat<T>(T first, IEnumerable<T> items)
            {
                yield return first;
                foreach (var i in items) yield return i;
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

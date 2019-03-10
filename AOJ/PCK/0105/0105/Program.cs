using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0105
{
    public class Program

    {
        public static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<int>> dic = new SortedDictionary<string, SortedSet<int>>();

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                string[] items = line.Trim().Split(' ');
                if (!dic.ContainsKey(items[0])) dic.Add(items[0], new SortedSet<int>());
                dic[items[0]].Add(int.Parse(items[1]));
            }

            foreach (var item in dic)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(WAr(item.Value));
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

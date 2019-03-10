using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0142
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                HashSet<int> mods = new HashSet<int>();
                for (int i = 1 ; i <= (n - 1) / 2 ; i++) mods.Add((i * i) % n);

                int[] res = new int[(n - 1) / 2 + 1];
                foreach (var item1 in mods)
                {
                    foreach (var item2 in mods)
                    {
                        int diff = item1 - item2;
                        if (diff < 0) diff += n;
                        res[Math.Min(diff, n - diff)]++;
                    }
                }

                for (int i = 1 ; i < res.Count() ; i++)
                {
                    Console.WriteLine(res[i]);
                }             
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

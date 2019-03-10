using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0029
{
    public class Program

    {
        public static void Main(string[] args)
        {
            string[] words = RStAr();
            Dictionary<string, int> res = new Dictionary<string, int>();
            for (int i = 0 ; i < words.Length ; i++)
            {
                if (!res.ContainsKey(words[i])) res.Add(words[i], 0);
                res[words[i]]++;
            }

            Console.WriteLine("{0} {1}"
                ,res.Where(x => x.Value == res.Max(y => y.Value)).First().Key
                ,res.Where(x => x.Key.Length == res.Max(y => y.Key.Length)).First().Key);
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

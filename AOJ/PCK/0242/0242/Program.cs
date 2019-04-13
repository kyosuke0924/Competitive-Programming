using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0242
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                Dictionary<string, int> dic = new Dictionary<string, int>();
                for (int i = 0; i < n; i++)
                {
                    string[] vs = RArSt();
                    for (int j = 0; j < vs.Length; j++)
                    {
                        if (!dic.ContainsKey(vs[j])) dic.Add(vs[j], 0);
                        dic[vs[j]]++;
                    }
                }
                string target = RSt();
                var res = dic.Where(x => x.Key.Substring(0, 1) == target);
                Console.WriteLine(res.Count() == 0 ? "NA"
                                                    : WAr(res.OrderByDescending(x => x.Value)
                                                             .ThenBy(x => x.Key)
                                                             .Take(Math.Min(res.Count(), 5))
                                                             .Select(x=>x.Key)));
            }
        }
        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RArSt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RArInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RArLong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RArDouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }
}

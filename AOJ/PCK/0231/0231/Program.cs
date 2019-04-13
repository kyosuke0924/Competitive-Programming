using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0231
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                List<Tuple<int, int>> events = new List<Tuple<int, int>>();
                for (int i = 0; i < n; i++)
                {
                    int[] vs = RArInt();
                    events.Add(new Tuple<int, int>(vs[1], vs[0]));
                    events.Add(new Tuple<int, int>(vs[2], -vs[0]));
                }
                Console.WriteLine(IsBreak(events) ? "NG" : "OK");
            }
        }

        private static bool IsBreak(List<Tuple<int, int>> events)
        {
            int loadWeight = 0;
            foreach (var item in events.OrderBy(x => x.Item1).ThenBy(x => x.Item2))
            {
                loadWeight += item.Item2;
                if (loadWeight > 150) return true;
            }
            return false;
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

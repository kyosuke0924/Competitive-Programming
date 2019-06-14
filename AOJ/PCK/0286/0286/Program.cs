using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0286
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nm = RArInt();
            Dictionary<int, int>[] persons = new Dictionary<int, int>[nm[0]];
            for (int i = 0; i < persons.Length; i++) persons[i] = new Dictionary<int, int>();

            while (true)
            {
                int[] vs = RArInt();
                if (vs.Sum() == 0) break;

                if (!persons[vs[0] - 1].ContainsKey(vs[1] - 1)) persons[vs[0] - 1].Add(vs[1] - 1, 0);
                persons[vs[0] - 1][vs[1] - 1] += vs[2];
            }

            int l = RInt();
            for (int i = 0; i < l; i++)
            {
                int[] unitPrices = RArInt();
                Console.WriteLine(WAr(persons.Select(x => x.Sum(y => unitPrices[y.Key] * y.Value))));
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

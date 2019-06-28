using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0298
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> times = new SortedSet<string>();
            int[] n = RArInt();
            for (int i = 1; i < n[0] * 2; i += 2)
            {
                times.Add(n[i].ToString("00") + ":" + n[i + 1].ToString("00"));
            }
            int[] m = RArInt();
            for (int i = 1; i < m[0] * 2; i += 2)
            {
                times.Add(m[i].ToString("00") + ":" + m[i + 1].ToString("00"));
            }

            Console.WriteLine(WAr(times.Select(x => x.Split(':')).Select(y => int.Parse(y[0]).ToString() + ":" + y[1])));
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

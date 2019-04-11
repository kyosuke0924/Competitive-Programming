using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0226
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string[] vs = RArSt();
                if (vs.All(x => x == "0")) break;

                string a = vs[0];
                string b = vs[1];

                int hit = 0;
                int blow = 0;
                for (int i = 0; i < a.Count(); i++)
                {
                    if (a.Contains(b[i]))
                    {
                        if (a[i] == b[i]) hit++;
                        else blow++;
                    }
                }
                Console.WriteLine("{0} {1}", hit, blow);
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

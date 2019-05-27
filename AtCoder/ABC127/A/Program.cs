using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vs = RArInt();
            int fee;
            if (vs[0] >= 13)
            {
                fee = vs[1];
            }
            else if (vs[0] >= 6)
            {
                fee = vs[1] / 2;
            }
            else
            {
                fee = 0;
            }               
            Console.WriteLine(fee);
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

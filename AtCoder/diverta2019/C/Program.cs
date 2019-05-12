using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = RInt();

            int res = 0;
            int firstB = 0;
            int lastA = 0;
            int self = 0;
            for (int i = 0; i < n; i++)
            {
                string s = RSt();
                if (s[0] == 'B') firstB++;
                if (s[s.Length - 1] == 'A') lastA++;
                if (s[0] == 'B' && s[s.Length - 1] == 'A') self++;
                string rep = s.Replace("AB", "");
                res += (s.Length - rep.Length) / 2;
            }

            if (lastA != firstB)
            {
                res += Math.Min(firstB, lastA);
            }
            else
            {
                if (lastA == self && self > 0)
                {
                    res += lastA - 1;
                }
                else
                {
                    res += lastA;
                }
            }

            Console.WriteLine(res);

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

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
            string s = RSt();
            int resA = s.Count(x => x == '#');
            int resB = s.Count(x => x == '.');
            int allChange = Math.Min(resA, resB);

            int[] sharpCnts = new int[s.Length];
            sharpCnts[0] = s[0] == '#' ? 1 : 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    sharpCnts[i] = sharpCnts[i - 1] + 1;
                }
                else
                {
                    sharpCnts[i] = sharpCnts[i - 1];
                }
            }

            int res = int.MaxValue;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == '.' && s[i + 1] == '#')
                {
                    res = Math.Min(res, sharpCnts[i] + ((s.Length - (i + 1)) - (sharpCnts[s.Length - 1] - sharpCnts[i + 1] + 1)));
                }
            }
            Console.WriteLine(Math.Min(res, allChange));
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

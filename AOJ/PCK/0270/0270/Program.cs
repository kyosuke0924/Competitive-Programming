using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0270
{
    class Program
    {
        const int LMT = 300000;
        static void Main(string[] args)
        {
            int[] nq = RArInt();
            int[] cards = RArInt();
            int[] MaxCards = new int[LMT + 1];
            for (int i = 0; i < cards.Length; i++) MaxCards[cards[i]] = cards[i];
            for (int i = 1; i <= LMT; i++) MaxCards[i] = Math.Max(MaxCards[i], MaxCards[i - 1]);
            for (int i = 0; i < nq[1]; i++)
            {
                int q = RInt();
                int res = 0;
                for (int j = q; j < MaxCards.Length; j += q)
                {
                    res = Math.Max(res, MaxCards[j - 1] % q);
                    if (res == q - 1) break;
                }
                Console.WriteLine(res);
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

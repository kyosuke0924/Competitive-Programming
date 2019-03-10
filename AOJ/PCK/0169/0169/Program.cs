using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0169
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] hand = RIntAr();
                if (hand.Sum() == 0) break;
                Console.WriteLine(CalcScore(hand));
            }
        }

        private static int CalcScore(int[] hand)
        {
            if (hand.Count() > 21) return 0;

            List<int> score = new List<int>() { 0 };
            for (int i = 0 ; i < hand.Count() ; i++)
            {
                if (hand[i] > 1)
                {
                    score = score.Select(x => x + (hand[i] > 10 ? 10 : hand[i])).Where(x => x <= 21).ToList();
                }
                else
                {
                    var score1 = score.Select(x => x + 1).Where(x => x <= 21);
                    var score2 = score.Select(x => x + 11).Where(x => x <= 21);
                    score = score1.Union(score2).Distinct().ToList();
                }
            }
            return score.Count() == 0 ? 0 : score.Max();
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

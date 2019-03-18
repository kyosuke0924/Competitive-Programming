using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D
{
    public class Program

    {
        static public int[] num = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static public int[] quantity = new int[] { 2, 5, 5, 4, 5, 6, 3, 7, 6 };

        public class Match
        {
            public int Num { get; set; }
            public int QUE { get; set; }
            public int CNT { get; set; }
            public Match(int n, int q) { Num = n; QUE = q; }
        }

        static public Match[] matches;

        public static void Main(string[] args)
        {
            int[] nm = RIntAr();
            int[] items = RIntAr();

            matches = new Match[nm[1]];
            for (int i = 0 ; i < items.Count() ; i++)
            {
                matches[i] = new Match(num[items[i] - 1], quantity[items[i] - 1]);
            }

            matches = matches.OrderBy(x => x.QUE).ThenByDescending(x => x.Num).ToArray();
            List<Match> newM = new List<Match>();
            foreach (var item in matches)
            {
                if (!newM.Any(x => x.QUE == item.QUE) && newM.Where(x => item.QUE % x.QUE == 0).Count() == 0) newM.Add(item);
            }
            matches = newM.ToArray();

            SetMatch(nm[0]);

            string res = "";
            foreach (var item in matches.OrderByDescending(x => x.Num))
            {
                res += new string(item.Num.ToString()[0], item.CNT);
            }
            Console.WriteLine(res);
        }

        private static bool SetMatch(int num)
        {
            if (num == 0) return true;
            for (int i = 0 ; i < matches.Count() ; i++)
            {
                if (num - matches[i].QUE >= 0)
                {
                    matches[i].CNT++;
                    if (SetMatch(num - matches[i].QUE)) return true;
                    matches[i].CNT--;
                }
            }
            return false;
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

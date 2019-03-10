using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0124
{
    public class Program

    {
        struct Team
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public int InputOrder { get; set; }
            public Team(string[] items,int i)
            {
                Name = items[0];
                Score = int.Parse(items[1]) * 3 + int.Parse(items[3]);
                InputOrder = i;
            }
        }

        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                Team[] teams = new Team[n];
                for (int i = 0 ; i < n ; i++) teams[i] = new Team(RStAr(), i);

                if (sb.Length > 0) sb.AppendLine("");
                foreach (var item in teams.OrderByDescending(x => x.Score).ThenBy(x => x.InputOrder))
                {
                    sb.AppendLine(item.Name + "," + item.Score);
                }
            }
            Console.Write(sb.ToString());
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

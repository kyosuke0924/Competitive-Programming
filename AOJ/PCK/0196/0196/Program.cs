using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0196
{
    public class Program

    {
        class Team
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Win { get; set; }
            public int Lose { get; set; }
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                List<Team> teams = new List<Team>(n);
                for (int i = 0 ; i < n ; i++)
                {
                    string[] items = RStAr();

                    Team tmp = new Team();
                    tmp.ID = i;
                    tmp.Name = items[0];
                    tmp.Win = items.Skip(1).Count(x => int.Parse(x) == 0);
                    tmp.Lose = items.Skip(1).Count(x => int.Parse(x) == 1);
                    teams.Add(tmp);
                }

                foreach (var item in teams.OrderByDescending(x => x.Win).ThenBy(x => x.Lose).ThenBy(x => x.ID))
                {
                    Console.WriteLine(item.Name);
                }

            }
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

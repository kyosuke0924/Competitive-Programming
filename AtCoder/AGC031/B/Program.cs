using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B
{
    public class Program

    {
        public class TurnableStone
        {
            public int Color { get; set; }
            public int Start { get; set; }
            public int End { get; set; }

            public TurnableStone(int color, int v, int i)
            {
                this.Color = color;
                this.Start = v;
                this.End = i;
            }
        }

        public static void Main(string[] args)
        {
            int n = RInt();
            List<TurnableStone> turnableStones = new List<TurnableStone>();

            int[] colorAppearance = new int[200000];
            for (int i = 1; i <= n; i++)
            {
                int color = RInt();
                if (colorAppearance[color] == 0 || colorAppearance[color] == i - 1)
                {
                    colorAppearance[color] = i;
                }
                else
                {
                    turnableStones.Add(new TurnableStone(color, colorAppearance[color], i));
                    colorAppearance[color] = 0;
                }
            }

            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (var item in turnableStones.OrderByDescending(x => x.Start))
            {
                var tmp = dic.Where(x => x.Key >= item.End);
                if (tmp.Count() == 0)
                {
                    dic.Add(item.Start, 2);
                }
                else
                {
                    dic.Add(item.Start, 2 * tmp.Value);
                }
            }

            Console.WriteLine(dic.Max(x => x.Value));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0119
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int m = RInt();
            int n = RInt();

            List<Tuple<int, int>> testimonies = new List<Tuple<int, int>>(n);
            for (int i = 0 ; i < n ; i++)
            {
                int[] items = RIntAr();
                testimonies.Add(new Tuple<int, int>(items[0], items[1]));
            }

            HashSet<int> enteringRoomOrder = new HashSet<int>();
            while (testimonies.Count > 0)
            {
                for (int i = 1 ; i <= m ; i++)
                {
                    if(!testimonies.Any(x => x.Item2 == i))
                    {
                        enteringRoomOrder.Add(i);
                        testimonies.RemoveAll(x => x.Item1 == i);
                    }
                }
            }
            enteringRoomOrder.Add(2);

            foreach (var item in enteringRoomOrder) Console.WriteLine(item);            
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

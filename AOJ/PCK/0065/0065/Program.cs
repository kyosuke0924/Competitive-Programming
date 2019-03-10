using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0065
{
    public class Program

    {
        public static void Main(string[] args)
        {

            Dictionary<int, int> lastMonth = new Dictionary<int, int>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "") break;

                int[] items = Array.ConvertAll(line.Trim().Split(','), e => int.Parse(e));
                if (!lastMonth.ContainsKey(items[0])) lastMonth.Add(items[0], 0);
                lastMonth[items[0]]++;
            }

            Dictionary<int, int> thisMonth = new Dictionary<int, int>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null) break;

                int[] items = Array.ConvertAll(line.Trim().Split(','), e => int.Parse(e));
                if (!thisMonth.ContainsKey(items[0])) thisMonth.Add(items[0], 0);
                thisMonth[items[0]]++;
            }

            foreach (var item in lastMonth)
            {
                if(thisMonth.ContainsKey(item.Key)) Console.WriteLine("{0} {1}",item.Key,item.Value + thisMonth[item.Key]);
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

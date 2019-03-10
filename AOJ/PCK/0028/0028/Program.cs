using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0028
{
    public class Program

    {
        public static void Main(string[] args)
        {
            Dictionary<int, int> items = new Dictionary<int, int>();
            while (true)
            {
                string line = RSt();
                if (string.IsNullOrEmpty(line)) break;

                int num = int.Parse(line);
                if (!items.ContainsKey(num)) items.Add(num,0); 
                items[num]++;
            }
            foreach (var item in items.OrderBy(x => x.Key).Where(x => x.Value == items.Max(y => y.Value)))
            {
                Console.WriteLine(item.Key);
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
        static string WAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WAr(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WAr(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0138
{
    public class Program

    {
        public static void Main(string[] args)
        {
            SortedList<int, double> set1 = new SortedList<int, double>(8);
            SortedList<int, double> set2 = new SortedList<int, double>(8);
            SortedList<int, double> set3 = new SortedList<int, double>(8);
            SortedList<int, double> setAll = new SortedList<int, double>(24);

            for (int i = 0 ; i < 24 ; i++)
            {
                double[] numAndTime = RDoubleAr();
                setAll.Add((int)numAndTime[0], numAndTime[1]);
                if (i < 8) set1.Add((int)numAndTime[0], numAndTime[1]);
                else if (i < 16) set2.Add((int)numAndTime[0], numAndTime[1]);
                else set3.Add((int)numAndTime[0], numAndTime[1]);
            }

            int cnt = 0;
            foreach (var item in set1.OrderBy(x => x.Value))
            {
                cnt++;
                Console.WriteLine("{0} {1}", item.Key, item.Value.ToString("0.00"));
                setAll.Remove(item.Key);
                if (cnt == 2) break;
            }
            cnt = 0;
            foreach (var item in set2.OrderBy(x => x.Value))
            {
                cnt++;
                Console.WriteLine("{0} {1}", item.Key, item.Value.ToString("0.00"));
                setAll.Remove(item.Key);
                if (cnt == 2) break;
            }
            cnt = 0;
            foreach (var item in set3.OrderBy(x => x.Value))
            {
                cnt++;
                Console.WriteLine("{0} {1}", item.Key, item.Value.ToString("0.00"));
                setAll.Remove(item.Key);
                if (cnt == 2) break;
            }
            cnt = 0;
            foreach (var item in setAll.OrderBy(x => x.Value))
            {
                cnt++;
                Console.WriteLine("{0} {1}", item.Key, item.Value.ToString("0.00"));
                if (cnt == 2) break;
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

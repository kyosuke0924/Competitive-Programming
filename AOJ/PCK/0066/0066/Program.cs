using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0066
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;
                Console.WriteLine(judge(line));
            }
        }

        private static char judge(string line)
        {
            List<int[]> winPattern = new List<int[]>
            {
                 new int[] {0,1,2}
                ,new int[] {3,4,5}
                ,new int[] {6,7,8}
                ,new int[] {0,3,6}
                ,new int[] {1,4,7}
                ,new int[] {2,5,8}
                ,new int[] {0,4,8}
                ,new int[] {2,4,6}
            };

            foreach (int[] item in winPattern)
            {
                var res = item.Select(x => line[x]).Distinct();
                if (res.Count() == 1 && res.First() != 's') return res.First();
            }
            return 'd';
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

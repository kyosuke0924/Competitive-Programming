using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0064
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int res = 0;
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null) break;

                string tmp = "";
                for (int i = 0 ; i < line.Length ; i++)
                {
                    if (line[i] >= 48 && line[i] <= 57)
                    {
                        tmp += line[i];
                    }
                    else
                    {
                        if (tmp.Length > 0)
                        {
                            res += int.Parse(tmp);
                            tmp = "";
                        }
                    }
                }
                if (tmp.Length > 0) res += int.Parse(tmp);
            } 
            Console.WriteLine(res);

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

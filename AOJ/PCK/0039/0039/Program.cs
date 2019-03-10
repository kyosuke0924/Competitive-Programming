using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0039
{
    public class Program

    {
        public static void Main(string[] args)
        {
            Dictionary<char, int> roman = new Dictionary<char, int>()
            {
                 {'I',1}
                ,{'V',5}
                ,{'X',10}
                ,{'L',50}
                ,{'C',100}
                ,{'D',500}
                ,{'M',1000}
            };

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int res = 0;
                for (int i = 0 ; i < line.Length - 1 ; i++)
                {
                    if(roman[line[i]] < roman[line[i + 1]]) res -= roman[line[i]];
                    else res += roman[line[i]];

                }
                res += roman[line[line.Length - 1]];
                Console.WriteLine(res);
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

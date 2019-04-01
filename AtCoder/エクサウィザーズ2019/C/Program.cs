using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            List<int>[] chars = new List<int>[26];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = new List<int>();
            }

            int[] vs = RIntAr();
            string s = RSt();

            int[] golems = new int[s.Length + 2];
            for (int i = 0; i < s.Length; i++)
            {
                chars[s[i] - 'A'].Add(i+1);
                golems[i + 1] = 1;
            }

            for (int i = 0; i < vs[1]; i++)
            {
                string[] items = RStAr();

                if (items[1][0] == 'R')
                {
                    for (int j = chars[items[0][0] - 'A'].Count() - 1; j >= 0; j--)
                    {
                        int idx = chars[items[0][0] - 'A'][j];
                        int tmp = golems[idx];
                        golems[idx] = 0;
                        golems[idx + 1] += tmp;
                    }
                }
                else
                {
                    for (int j = 0; j < chars[items[0][0] - 'A'].Count(); j++)
                    {
                        int idx = chars[items[0][0] - 'A'][j];
                        int tmp = golems[idx];
                        golems[idx] = 0;
                        golems[idx - 1] += tmp;
                    }
                }
            }

            Console.WriteLine(s.Length - golems[0] - golems[golems.Length - 1]);
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

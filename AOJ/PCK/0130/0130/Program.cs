using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0130
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = RInt();

            for (int lCnt = 0 ; lCnt < n ; lCnt++)
            {
                string line = RSt();
                line = line.Replace("->", "0");
                line = line.Replace("<-", "1");

                LinkedList<char> ans = new LinkedList<char>();
                HashSet<char> registration = new HashSet<char>();

                bool isFront = false;
                for (int i = 0 ; i < line.Length ; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (!registration.Contains(line[i]))
                        {
                            if (isFront) ans.AddFirst(line[i]);
                            else ans.AddLast(line[i]);
                            registration.Add(line[i]);
                        }
                    }
                    else
                    {
                        isFront = (line[i] == '1');
                    }
                }
                Console.WriteLine(WAr(ans, ""));
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

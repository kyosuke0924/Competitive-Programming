using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vs = RArInt();
            string s = RSt();

            List<int> zeloLen = new List<int>();
            List<int> oneLen = new List<int>();

            int cnt = 0;
            for (int i = 0; i < s.Length; i++)
            {
                cnt++;
                if (i == s.Length - 1 || s[i] != s[i + 1])
                {
                    if (s[i] == '0') zeloLen.Add(cnt); else oneLen.Add(cnt);
                    cnt = 0;
                }
            }

            if (zeloLen.Count() <= vs[1])
            {
                Console.WriteLine(s.Length);
                return;
            }

            int max = 0;
            int sum = 0;
            for (int i = 0; i < zeloLen.Count() - vs[1] + 1; i++)
            {
                if (i == 0)
                {
                    sum += zeloLen.Take(vs[1]).Sum();
                    if (s[0] == '1')
                    {
                        sum += oneLen.Take(vs[1] + 1).Sum();
                    }
                    else
                    {
                        sum += oneLen.Take(vs[1]).Sum();
                    }
                    max = sum;
                }
                else
                {
                    sum -= zeloLen[i - 1];
                    sum -= oneLen[i - 1];

                    sum += zeloLen[vs[1] + (i - 1)];
                    if (s[0] == '1')
                    {
                        sum += oneLen[vs[1] + i];
                    }
                    else
                    {
                        sum += oneLen[vs[1] + i];
                    }
                }
                max = Math.Max(max, sum);
            }
            Console.WriteLine(max);
        }
        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RArSt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RArInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RArLong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RArDouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0259
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string n = RSt();
                if (n == "0000") break;

                if (n.Distinct().Count() == 1)
                {
                    Console.WriteLine("NA");
                }
                else
                {
                    int cnt = 0;
                    while (n != "6174")
                    {
                        string l = new string(n.OrderByDescending(x => x).ToArray());
                        string s = string.Join("", l.Reverse());
                        n = (int.Parse(l) - int.Parse(s)).ToString().PadLeft(4, '0');
                        cnt++;
                    }
                    Console.WriteLine(cnt);
                }
            }
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

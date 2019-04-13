using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0280
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                string s = RSt();

                int fieldBill = 0;
                int[] players = new int[n];

                for (int i = 0; i < s.Length; i++)
                {
                    int idx = i % n;
                    players[idx]++;

                    switch (s[i])
                    {
                        case 'S':
                            fieldBill += players[idx];
                            players[idx] = 0;
                            break;
                        case 'L':
                            players[idx] += fieldBill;
                            fieldBill = 0;
                            break;
                    }
                }
                Console.WriteLine("{0} {1}", WAr(players.OrderBy(x => x)), fieldBill);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0240
{
    enum RateType { Simple = 1, Compound = 2 }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int year = RInt();
                Dictionary<int, double> banks = new Dictionary<int, double>();
                for (int i = 0; i < n; i++)
                {
                    int[] vs = RArInt();
                    banks.Add(vs[0], CalcBasicInterest(year, vs[1], vs[2]));
                }
                Console.WriteLine(banks.OrderByDescending(x => x.Value).FirstOrDefault().Key);
            }
        }

        static double CalcBasicInterest(int year, int interestRate, int type)
        {
            switch ((RateType)type)
            {
                case RateType.Simple:
                    return 1 + year * (interestRate / (double)100);
                case RateType.Compound:
                    return Math.Pow(1 + (interestRate / (double)100), year);
                default: return 0;
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

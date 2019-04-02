using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0218
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                for (int k = 0; k < n; k++)
                {
                    int[] vs = RAInt();

                    int max = vs.Max();
                    int sum = vs.Sum();
                    int sumME = vs.Take(2).Sum();

                    string res;
                    if (max == 100 || sum >= 240 || sumME >= 180)
                    {
                        res = "A";
                    }
                    else if (sum >= 210 || (sum >= 150 && (vs[0] >= 80 || vs[1] >= 80)))
                    {
                        res = "B";
                    }
                    else
                    {
                        res = "C";
                    }
                    Console.WriteLine(res);
                }
            }
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RASt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RAInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RALong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RADouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }
}

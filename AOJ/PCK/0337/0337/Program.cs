using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0337
{
    class Program
    {
        static int[] staEra = new int[] { 1868, 1912, 1926, 1989 };
        static string[] chrEra = new string[] { "M", "T", "S", "H" };

        static void Main(string[] args)
        {
            int[] ey = RArInt();
            if (ey[0] == 0)
            {
                for (int i = staEra.Length - 1; i >= 0; i--)
                {
                    if (ey[1] >= staEra[i])
                    {
                        Console.WriteLine(chrEra[i] + (ey[1] - staEra[i] + 1).ToString());
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine(staEra[ey[0] - 1] + ey[1] - 1);
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

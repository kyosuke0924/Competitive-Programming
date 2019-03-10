using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0137
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = RInt();
            for (int i = 0 ; i < n ; i++)
            {
                Console.WriteLine("Case {0}:", i + 1);

                int num = RInt();
                for (int j = 0 ; j < 10 ; j++)
                {
                    int randomNumber = int.Parse((num * num).ToString().PadLeft(8, '0').Substring(2, 4));
                    Console.WriteLine(randomNumber);
                    num = randomNumber;
                }
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

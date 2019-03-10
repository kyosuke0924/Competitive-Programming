using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0140
{
    public class Program

    {
        //static string busStop = "012345678954321012345678";
        static string busStop = "56789543210123456789";


        public static void Main(string[] args)
        {
            int n = RInt();
            int startIdx = -1;
            int endIdx = -1;

            for (int k = 0 ; k < n ; k++)
            {
                int[] startEnd = RIntAr();
                for (int i = 0 ; i < busStop.Length ; i++)
                {
                    if (int.Parse(busStop[i].ToString()) == startEnd[0])
                    {
                        for (int j = i ; j < busStop.Length ; j++)
                        {
                            if (int.Parse(busStop[j].ToString()) == startEnd[1])
                            {
                                startIdx = i;
                                endIdx = j;
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine(WAr(busStop.Substring(startIdx, endIdx - startIdx + 1), " "));
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

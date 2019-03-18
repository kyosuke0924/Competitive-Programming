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
            int n = RInt();
            long[] a = RLongAr();
            long[] b = RLongAr();

            if(a.Sum() < b.Sum())
            {
                Console.WriteLine("-1");
                return;
            }

            if (a.Where((x, i) => x < b[i]).Count() == 0)
            {
                Console.WriteLine("0");
                return;
            }

            int res = 0; 
            long[] dif = new long[n]; 
            for (int i = 0 ; i < n ; i++)
            {
                dif[i] = a[i] - b[i];
            }

            long sumshortage = dif.Where(x => x < 0).Sum() * -1;
            int shortageCnt = dif.Count(x => x < 0);
            Array.Sort(dif);

            int minusCnt = 0;
            for (int i = dif.Count() - 1 ; i >= 0 ; i--)
            {
                minusCnt++;
                sumshortage -= dif[i];
                if (sumshortage <= 0) break;                
            }

            res = shortageCnt + minusCnt;
            Console.WriteLine(res);
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

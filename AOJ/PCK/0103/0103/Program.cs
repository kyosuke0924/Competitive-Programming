using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0103
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = RInt();

            int inning = 0;
            int outCnt = 0;
            int score = 0;
            int onBase = 0;
            while (inning < n)
            {
                string result = RSt();
                switch (result)
                {
                    case "HOMERUN":
                        score += onBase + 1;
                        onBase = 0;
                        break;

                    case "HIT":
                        if (onBase < 3) onBase++;
                        else score++;
                        break;

                    case "OUT":
                        outCnt++;
                        if(outCnt == 3)
                        {
                            Console.WriteLine(score);
                            inning++;
                            outCnt = 0;
                            score = 0;
                            onBase = 0;
                        }
                        break;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0089
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[,] dp = new int[101, 51];

            int lineCount = 1;
            int beforeCol = 0;

            while (true)
            {

                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                int[] nums = Array.ConvertAll(line.Trim().Split(','), e => int.Parse(e));

                if (nums.Count() > beforeCol)
                {
                    for (int i = 0 ; i < nums.Count() ; i++)
                    {
                        dp[lineCount, i + 1] = nums[i] + Math.Max(dp[lineCount - 1, i], dp[lineCount - 1, i + 1]);
                    }

                }
                else
                {
                    for (int i = 0 ; i < nums.Count() ; i++)
                    {
                        dp[lineCount, i + 1] = nums[i] + Math.Max(dp[lineCount - 1, i + 2], dp[lineCount - 1, i + 1]);
                    }

                }

                lineCount++;
                beforeCol = nums.Count();
            }

            Console.WriteLine(dp[lineCount - 1, 1]);
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

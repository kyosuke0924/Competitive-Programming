using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _0139
{
    public class Program
    {
        static Regex snakeA = new Regex(@"^>'=+#=+~$", RegexOptions.Compiled);
        static Regex snakeB = new Regex(@"^>\^(Q=)+~~$", RegexOptions.Compiled);

        public static void Main(string[] args)
        {
            int n = RInt();
            for (int i = 0 ; i < n ; i++) Console.WriteLine(Judge(RSt()));
        }

        private static string Judge(string snake)
        {
            if (snakeB.IsMatch(snake)) return "B";
            else if (snakeA.IsMatch(snake))
            {
                if (snake.Count(x => x == '=') % 2 != 0) return "NA";

                string[] splitSnake = snake.Split(new char[] { '>', '\'', '#', '~' });
                if (splitSnake[2].Length != splitSnake[3].Length) return "NA";
                else return "A";
            }
            else return "NA";
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

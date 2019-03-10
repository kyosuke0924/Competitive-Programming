using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0198
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int cnt = 0;
                List<string> pips = new List<string>();

                for (int i = 0 ; i < n ; i++)
                {
                    string[] items = RStAr();
                    string pip = new string(items.Select(x => x[0]).ToArray());
                    if (!pips.Contains(pip))
                    {
                        cnt++;
                        foreach (var item in GetAllRoll(pip)) pips.Add(item);
                    }
                }
                Console.WriteLine(n - cnt);
            }
        }

        private static IEnumerable<string> GetAllRoll(string v)
        {
            yield return new string(new char[] { v[0], v[1], v[2], v[3], v[4], v[5] });
            yield return new string(new char[] { v[0], v[2], v[4], v[1], v[3], v[5] });
            yield return new string(new char[] { v[0], v[4], v[3], v[2], v[1], v[5] });
            yield return new string(new char[] { v[0], v[3], v[1], v[4], v[2], v[5] });

            yield return new string(new char[] { v[1], v[0], v[3], v[2], v[5], v[4] });
            yield return new string(new char[] { v[1], v[3], v[5], v[0], v[2], v[4] });
            yield return new string(new char[] { v[1], v[5], v[2], v[3], v[0], v[4] });
            yield return new string(new char[] { v[1], v[2], v[0], v[5], v[3], v[4] });

            yield return new string(new char[] { v[2], v[5], v[4], v[1], v[0], v[3] });
            yield return new string(new char[] { v[2], v[4], v[0], v[5], v[1], v[3] });
            yield return new string(new char[] { v[2], v[0], v[1], v[4], v[5], v[3] });
            yield return new string(new char[] { v[2], v[1], v[5], v[0], v[4], v[3] });

            yield return new string(new char[] { v[3], v[0], v[4], v[1], v[5], v[2] });
            yield return new string(new char[] { v[3], v[4], v[5], v[0], v[1], v[2] });
            yield return new string(new char[] { v[3], v[5], v[1], v[4], v[0], v[2] });
            yield return new string(new char[] { v[3], v[1], v[0], v[5], v[4], v[2] });

            yield return new string(new char[] { v[4], v[0], v[2], v[3], v[5], v[1] });
            yield return new string(new char[] { v[4], v[2], v[5], v[0], v[3], v[1] });
            yield return new string(new char[] { v[4], v[5], v[3], v[2], v[0], v[1] });
            yield return new string(new char[] { v[4], v[3], v[0], v[5], v[2], v[1] });

            yield return new string(new char[] { v[5], v[1], v[3], v[2], v[4], v[0] });
            yield return new string(new char[] { v[5], v[3], v[4], v[1], v[2], v[0] });
            yield return new string(new char[] { v[5], v[4], v[2], v[3], v[1], v[0] });
            yield return new string(new char[] { v[5], v[2], v[1], v[4], v[3], v[0] });

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

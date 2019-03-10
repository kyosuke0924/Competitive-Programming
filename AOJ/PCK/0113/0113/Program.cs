using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0113
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int[] items = Array.ConvertAll(line.Trim().Split(' '), e => int.Parse(e));
                int p = items[0];
                int q = items[1];

                List<int> quotient = new List<int>(80);
                List<int> remainder = new List<int>(80);

                int cur = p; int cnt = 0;
                while (true)
                {
                    int div = cur / q;
                    int mod = cur % q;

                    quotient.Add(div);

                    if (mod == 0)
                    {
                        Console.WriteLine(WAr(quotient.Skip(1), ""));
                        break;
                    }

                    int idxMod = remainder.IndexOf(mod);
                    if (idxMod > -1)
                    {
                        Console.WriteLine(WAr(quotient.Skip(1), ""));
                        Console.WriteLine(String.Join("", Enumerable.Repeat(' ', idxMod).ToArray()).PadRight(quotient.Count() - 1, '^'));
                        break;
                    }

                    remainder.Add(mod);
                    cur = mod;
                    cur *= 10;
                    cnt++;
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

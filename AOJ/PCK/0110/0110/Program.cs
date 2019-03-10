using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0110
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                bool flg = false;
                for (int i = 0 ; i < 10 ; i++)
                {

                    string tmp = line;
                    tmp = tmp.Replace("X", i.ToString());

                    string[] items = tmp.Trim().Split("+=".ToCharArray());
                    if (items.Any(x => x[0] == '0' && x.Length > 1)) continue;

                    if (Sum(items[0], items[1]) == items[2])
                    {
                        Console.WriteLine(i);
                        flg = true;
                        break;
                    }
                }
                if(!flg) Console.WriteLine("NA");
            }

        }

        public static string Sum(string a , string b)
        {
            const int N = 126;
            a = string.Join("", a.PadLeft(N, '0').Reverse());
            b = string.Join("", b.PadLeft(N, '0').Reverse());

            string[] resAr = new string[N];
            bool carrying = false;
            for (int j = 0 ; j < resAr.Length ; j++)
            {
                string tmp = (int.Parse(a[j].ToString()) + int.Parse(b[j].ToString()) + (carrying ? 1 : 0)).ToString();
                resAr[j] = tmp.Substring(tmp.Length - 1, 1);
                carrying = (int.Parse(tmp) > 9) ? true : false;
            }

            return string.Join("", resAr.Reverse().SkipWhile(x => x == "0").ToArray());
            //return ans == "" ? "0" : ans;

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

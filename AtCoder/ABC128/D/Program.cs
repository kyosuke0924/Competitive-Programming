using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D
{
    class Program
    {
        static int n, maxK;
        static Dictionary<string, int> memo;

        static void Main(string[] args)
        {

            int[] nk = RArInt();
            n = nk[0];
            maxK = nk[1];
            int[] vs = RArInt();
            memo = new Dictionary<string, int>();

            int res = 0;
            int opeCnt = Math.Min(maxK, n);

            for (int lCnt = 0; lCnt <= opeCnt; lCnt++)
            {
                for (int rCnt = 0; rCnt <= opeCnt; rCnt++)
                {
                    if (lCnt + rCnt > opeCnt) continue;

                    var l = vs.Take(lCnt);
                    var r = vs.Skip(vs.Length - rCnt).Take(rCnt);

                    List<int> li = new List<int>();
                    foreach (var item in l) li.Add(item);
                    foreach (var item in r) li.Add(item);
                    li = li.OrderBy(x => x).ToList();

                    for (int i = 0; i < maxK - (lCnt + rCnt); i++)
                    {
                        if (i > li.Count - 1) break;
                        if (li[i] < 0) li[i] = 0;
                        else break;
                    }
                    res = Math.Max(res, li.Sum());
                }

            }
            Console.WriteLine(res < 0 ? 0 : res);

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

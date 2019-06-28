using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0385
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = RInt();
            int[] a = RArInt();
            int q = RInt();
            int[][] xy = new int[q][];
            for (int i = 0; i < q; i++) { xy[i] = RArInt(); }

            int[] correct = a.OrderBy(x => x).ToArray();
            int wrongCnt = 0;
            for (int i = 0; i < a.Length; i++) if (a[i] != correct[i]) wrongCnt++;

            if (wrongCnt == 0) Console.WriteLine(0);
            else
            {
                int res = -1;
                for (int i = 0; i < q; i++)
                {
                    int x = xy[i][0] - 1, y = xy[i][1] - 1;
                    if (a[x] == correct[x] && a[y] != correct[x]) wrongCnt++;
                    if (a[y] == correct[y] && a[x] != correct[y]) wrongCnt++;
                    if (a[x] != correct[x] && a[y] == correct[x]) wrongCnt--;
                    if (a[y] != correct[y] && a[x] == correct[y]) wrongCnt--;
                    if (wrongCnt == 0)
                    {
                        res = i + 1;
                        break;
                    }
                    int tmp = a[x]; a[x] = a[y]; a[y] = tmp;
                }
                Console.WriteLine(res);
            }
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

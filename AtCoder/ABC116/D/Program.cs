using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D
{
    public class Program

    {
        public struct Sushi
        {
            public int t; //ネタ
            public int d; //おいしさ
            public bool selected;
            public Sushi(int v1, int v2)
            {
                t = v1; d = v2; selected = false;
            }
        }

        public static void Main(string[] args)
        {
            int[] NK = RIntAr();
            Sushi[] sushi = new Sushi[NK[0]];
            bool[] selected = new bool[NK[0]];

            for (int i = 0 ; i < NK[0] ; i++)
            {
                int[] tmp = RIntAr();
                sushi[i] = new Sushi(tmp[0], tmp[1]);
            }

            sushi = sushi.OrderByDescending(x => x.d).ToArray();
            HashSet<int> selectedT = new HashSet<int>();

            long sum = sushi[0].d + 1;
            selectedT.Add(sushi[0].t);
            sushi[0].selected = true;

            int cnt = 1;
            while (cnt < NK[1])
            {
                int sSameMaxI = -1;
                int sDiffMaxI = -1;
                for (int i = 0 ; i < NK[0] ; i++)
                {
                    if (sSameMaxI < 0 && !sushi[i].selected && selectedT.Contains(sushi[i].t)) sSameMaxI = i;
                    if (sDiffMaxI < 0 && !sushi[i].selected && !selectedT.Contains(sushi[i].t)) sDiffMaxI = i;
                    if (sSameMaxI >= 0 && sDiffMaxI >= 0) break;
                }

                if (sSameMaxI >= 0 && sDiffMaxI < 0)
                {
                    sum += sushi[sSameMaxI].d;
                    sushi[sSameMaxI].selected = true;
                }
                else if (sSameMaxI < 0 && sDiffMaxI >= 0)
                {
                    int x = selectedT.Count();
                    sum += sushi[sDiffMaxI].d - x * x + (x + 1) * (x + 1);

                    sushi[sDiffMaxI].selected = true;
                    selectedT.Add(sushi[sDiffMaxI].t);
                }
                else
                {
                    int x = selectedT.Count();
                    long s1 = sushi[sSameMaxI].d;
                    long s2 = sushi[sDiffMaxI].d - x * x + (x + 1) * (x + 1);

                    if (s2 >= s1)
                    {
                        sum += s2;
                        sushi[sDiffMaxI].selected = true;
                        selectedT.Add(sushi[sDiffMaxI].t);
                    }
                    else
                    {
                        sum += s1;
                        sushi[sSameMaxI].selected = true;
                    }
                }
                cnt++;
            }
            Console.WriteLine(sum);
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

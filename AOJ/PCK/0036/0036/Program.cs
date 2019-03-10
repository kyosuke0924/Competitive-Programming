using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0036
{
    public class Program

    {
        public static void Main(string[] args)
        {

            Dictionary<string, char[,]> patterns = new Dictionary<string, char[,]>();
            patterns.Add("A", new char[2, 2] { { '1', '1' }, { '1', '1' } });
            patterns.Add("B", new char[4, 1] { { '1' }, { '1' }, { '1' }, { '1' } });
            patterns.Add("C", new char[1, 4] { { '1', '1', '1', '1' } });
            patterns.Add("D", new char[3, 2] { { '0', '1' }, { '1', '1' }, { '1', '0' } });
            patterns.Add("E", new char[2, 3] { { '1', '1', '0' }, { '0', '1', '1' } });
            patterns.Add("F", new char[3, 2] { { '1', '0' }, { '1', '1' }, { '0', '1' } });
            patterns.Add("G", new char[2, 3] { { '0', '1', '1' }, { '1', '1', '0' } });

            while (true)
            {
                char[,] map = new char[8, 8];
                for (int i = 0 ; i < 8 ; i++)
                {
                    string item = RSt();
                    for (int j = 0 ; j < 8 ; j++)
                    {
                        map[i, j] = item[j];
                    }
                }

                foreach (var item in patterns)
                {
                    StringBuilder sb = new StringBuilder();
                    PatternMatch(map, item.Value, sb);
                    if (sb.Length > 0)
                    {
                        Console.WriteLine(item.Key);
                        break;
                    }
                }

                string line = RSt();
                if (line == null) break;

            }
        }

        public static void PatternMatch(char[,] target, char[,] pattern, StringBuilder sb)
        {

            const long B1 = 100000007;
            const long B2 = 100000009;

            int tRowCnt = target.GetLength(0);
            int pRowCnt = pattern.GetLength(0);
            int tColCnt = target.GetLength(1);
            int pColCnt = pattern.GetLength(1);

            if (pRowCnt > tRowCnt || pColCnt > tColCnt) return;

            //パターンのハッシュ値
            long pHash = 0;
            long[] tmp = new long[pRowCnt];

            for (int i = 0 ; i < pRowCnt ; i++)
            {
                for (int j = 0 ; j < pColCnt ; j++)
                {
                    tmp[i] = tmp[i] * B1 + pattern[i, j];
                }
            }

            for (int i = 0 ; i < pRowCnt ; i++) pHash = pHash * B2 + tmp[i];

            //ターゲットのハッシュ値

            long t1 = 1;
            for (int i = 0 ; i < pColCnt ; i++) t1 *= B1;

            long t2 = 1;
            for (int i = 0 ; i < pRowCnt ; i++) t2 *= B2;

            long[,] tmp2 = new long[tRowCnt, tColCnt - pColCnt + 1];
            bool[,] matchTbl = new bool[tRowCnt - pRowCnt + 1, tColCnt - pColCnt + 1];
            for (int i = 0 ; i < tRowCnt ; i++)
            {
                long e = 0;
                for (int j = 0 ; j < pColCnt ; j++) e = e * B1 + target[i, j];

                for (int j = 0 ; j + pColCnt <= tColCnt ; j++)
                {
                    tmp2[i, j] = e;
                    if (j + pColCnt < tColCnt) e = e * B1 - t1 * target[i, j] + target[i, j + pColCnt];
                }

            }

            for (int j = 0 ; j + pColCnt <= tColCnt ; j++)
            {
                long e = 0;
                for (int i = 0 ; i < pRowCnt ; i++) e = e * B2 + tmp2[i, j];

                for (int i = 0 ; i + pRowCnt <= tRowCnt ; i++)
                {
                    if (e == pHash) matchTbl[i, j] = true;
                    if (i + pRowCnt < tRowCnt) e = e * B2 - t2 * tmp2[i, j] + tmp2[i + pRowCnt, j];
                }
            }

            for (int i = 0 ; i < matchTbl.GetLength(0) ; i++)
            {
                for (int j = 0 ; j < matchTbl.GetLength(1) ; j++)
                {
                    if (matchTbl[i, j]) sb.AppendLine(i.ToString() + " " + j.ToString());
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

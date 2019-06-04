using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0263
{
    class Program
    {
        const int BITMAX = 1 << 16;
        static int n, c;
        static int[] ptn;
        static int[] push;

        static void Main(string[] args)
        {
            while (true)
            {
                int[] nc = RArInt();
                if (nc.Sum() == 0) break;
                Init(nc);
                Console.WriteLine(GetMaxScore());
            }

        }

        private static void Init(int[] nc)
        {
            n = nc[0]; c = nc[1];
            ptn = new int[n];
            for (int i = 0; i < ptn.Length; i++)
            {
                int[] vs = RArInt();
                for (int j = 0; j < vs.Length; j++)
                {
                    ptn[i] = (ptn[i] << 1) + vs[j];
                }
            }

            push = new int[c];
            for (int i = 0; i < push.Length; i++)
            {
                int[] vs = RArInt();
                for (int j = 0; j < vs.Length; j++)
                {
                    push[i] = (push[i] << 1) + vs[j];
                }
            }
        }

        private static int GetMaxScore()
        {
            int[,] score = new int[n + 1, BITMAX];
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < BITMAX; j++)
                {
                    score[i, j] = -1;
                }
            }
            score[0, 0] = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < BITMAX; j++)
                {
                    if (score[i, j] > -1)
                    {
                        int board = j | ptn[i];
                        for (int k = 0; k < push.Count(); k++)
                        {
                            int point = BitCount(board & push[k]);
                            int next = board & ~push[k];
                            score[i + 1, next] = Math.Max(score[i + 1, next], score[i, j] + point);
                        }
                    }
                }
            }

            int res = 0;
            for (int i = 0; i < BITMAX; i++) res = Math.Max(res, score[n, i]);

            return res;
        }

        /// <summary>
        /// ビットの立っている個数をカウントする
        /// </summary>
        /// <param name="bits">int型整数</param>
        /// <returns></returns>
        private static int BitCount(int bits)
        {
            bits = (bits & 0x55555555) + (bits >> 1 & 0x55555555);    //  2bitごとに計算
            bits = (bits & 0x33333333) + (bits >> 2 & 0x33333333);    //  4bitごとに計算
            bits = (bits & 0x0f0f0f0f) + (bits >> 4 & 0x0f0f0f0f);    //  8bitごとに計算
            bits = (bits & 0x00ff00ff) + (bits >> 8 & 0x00ff00ff);    //  16ビットごとに計算   
            return (bits & 0x0000ffff) + (bits >> 16);
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

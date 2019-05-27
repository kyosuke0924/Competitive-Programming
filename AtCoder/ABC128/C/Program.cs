using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nm = RArInt();
            int[][] joint = new int[nm[1]][];

            for (int i = 0; i < nm[1]; i++)
            {
                joint[i] = RArInt().Skip(1).Select(x => x - 1).ToArray();
            }

            int[] status = RArInt();

            int res = 0;
            for (int i = 0; i < (1 << nm[0]); i++)
            {
                if (IsOKPtn(i, joint, status)) res++;
            }
            Console.WriteLine(res);

        }

        private static bool IsOKPtn(int ptn, int[][] joint, int[] status)
        {
            for (int i = 0; i < joint.Count(); i++)
            {
                int cnt = 0;
                for (int k = 0; k < joint[i].Length; k++)
                {
                    if (((ptn >> joint[i][k]) & 1) == 1) cnt++;
                }
                if (cnt % 2 != status[i]) return false;
            }

            return true;
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

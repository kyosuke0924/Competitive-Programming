using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0126
{
    public class Program

    {
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int end = RInt();

            for (int start = 0 ; start < end ; start++)
            {
                char[,] fault = new char[9, 9];
                for (int i = 0 ; i < fault.GetLength(0) ; i++)
                {
                    for (int j = 0 ; j < fault.GetLength(1) ; j++)
                    {
                        fault[i, j] = ' ';
                    }
                }

                int[,] map = new int[9, 9];
                for (int i = 0 ; i < map.GetLength(0) ; i++)
                {
                    int[] items = RIntAr();
                    for (int j = 0 ; j < map.GetLength(1) ; j++)
                    {
                        map[i, j] = items[j];
                    }
                }


                for (int i = 0 ; i < map.GetLength(0) ; i++)
                {
                    for (int j = 0 ; j < map.GetLength(1) ; j++)
                    {
                        int x = map[i, j];

                        //horizontal Search
                        for (int k = j + 1 ; k < map.GetLength(0) ; k++)
                        {
                            if (x == map[i, k]) fault[i, j] = fault[i, k] = '*';
                        }

                        //vertical Search
                        for (int k = i + 1 ; k < map.GetLength(1) ; k++)
                        {
                            if (x == map[k, j]) fault[i, j] = fault[k, j] = '*';
                        }

                        //Block Search
                        int s = 3 * (i % 3) + (j % 3);
                        for (int k = s + 1 ; k < map.GetLength(0) ; k++)
                        {
                            int iBase = i - i % 3;
                            int jBase = j - j % 3;
                            if (x == map[iBase + k / 3, jBase + k % 3]) fault[i, j] = fault[iBase + k / 3, jBase + k % 3] = '*';
                        }
                    }
                }

                if (sb.Length != 0) sb.AppendLine("");
                for (int i = 0 ; i < map.GetLength(0) ; i++)
                {
                    for (int j = 0 ; j < map.GetLength(1) ; j++)
                    {
                        sb.Append(fault[i, j]);
                        sb.Append(map[i, j]);
                    }
                    sb.Append(Environment.NewLine);
                }
            }

            Console.Write(sb.ToString());
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

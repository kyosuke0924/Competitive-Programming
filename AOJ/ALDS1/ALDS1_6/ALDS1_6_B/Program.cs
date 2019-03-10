using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_6_B
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] line = ReadIntAr();
            int i = Partition(line, 0, line.Length - 1);

            Console.WriteLine(String.Join(" ",line.Select((x,index) => (index == i) ? "[" + x.ToString() + "]" : x.ToString()).ToArray()));
        }

        /// <summary>
        /// パーティション
        /// -配列をr番目の値より小さいグループと大きいグループに分割する
        /// </summary>
        /// <param name="array">対象配列</param>
        /// <param name="p">開始インデックス</param>
        /// <param name="r">基準インデックス</param>
        /// <returns>分割後の基準インデックスの位置</returns>
        public static int Partition(int[] array,int p,int r)
        {
            int x = array[r];
            int i = p - 1;
            for (int j = p ; j < r ; j++)
            {
                if (array[j] <= x)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }
            Swap(ref array[i+1], ref array[r]);
            return i + 1;
        }
        private static void Swap<T>(ref T v1, ref T v2) { var tmp = v1; v1 = v2; v2 = tmp; }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_6_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n  = ReadInt();
            int[] line = ReadIntAr();
            CountingSort(line);
            Console.WriteLine(string.Join(" ", line.Select(x => x.ToString()).ToArray()));
        }

        /// <summary>
        /// カウンティングソート
        /// </summary>
        /// <param name="array">対象配列</param>
        /// <returns></returns>
        public static void CountingSort(int[] array)
        {
            int[] res  = new int[array.Length];
            int[] tmp =  new int[array.Max()+1];
            for (int i = 0 ; i < array.Length ; i++) { tmp[array[i]]++; }
            for (int i = 1 ; i < tmp.Length ; i++) { tmp[i] += tmp[i - 1]; }
            for (int i = array.Length - 1 ; i >= 0 ; i--)
            {
                res[tmp[array[i]]-1] = array[i];
                tmp[array[i]]--;
            }
        }

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

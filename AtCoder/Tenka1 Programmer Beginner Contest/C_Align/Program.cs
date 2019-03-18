using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_Align
{
    public class Program

    {
        public static void Main(string[] args)
        {

            int n = ReadInt();
            List<long> line = new List<long>();
            for (int i = 0 ; i < n ; i++) line.Add(ReadInt());
            line.Sort();

            if(n % 2 == 0)
            {

                List<long> minHalf = new List<long>();
                List<long> maxHalf = new List<long>();

                //数列が偶数
                long res;
                for (int i = 0 ; i < n/2 ; i++)
                {
                    minHalf.Add(line[i]); //小さい順
                    maxHalf.Add(line[n - 1- i]); //大きい順
                }

                res = maxHalf.Sum(x => 2 * x)- minHalf.Sum(x => 2 * x) + minHalf[minHalf.Count - 1] - maxHalf[maxHalf.Count - 1];
                Console.WriteLine(res.ToString());
            }
            else
            {

                List<long> minHalf = new List<long>();
                List<long> maxHalf = new List<long>();

                //数列が奇数
                for (int i = 0 ; i < n / 2 ; i++)
                {
                    minHalf.Add(line[i]); //小さい順
                    maxHalf.Add(line[n - 1 - i]); //大きい順
                }
                minHalf.Add(line[(n - 1) / 2]);
                long res1 = maxHalf.Sum(x => 2 * x) - minHalf.Sum(x => 2 * x) + minHalf[minHalf.Count - 1] + minHalf[minHalf.Count - 2];

                minHalf.Remove(line[(n - 1) / 2]);
                maxHalf.Add(line[(n - 1) / 2]);

                long res2 = maxHalf.Sum(x => 2 * x) - minHalf.Sum(x => 2 * x) - maxHalf[maxHalf.Count - 1] - maxHalf[maxHalf.Count - 2] ;
                Console.WriteLine(Math.Max(res1,res2).ToString());

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

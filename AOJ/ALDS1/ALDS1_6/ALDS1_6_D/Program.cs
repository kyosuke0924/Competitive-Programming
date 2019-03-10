using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_6_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] line = ReadIntAr();
            Console.WriteLine(SillySort(line).ToString());
        }

        /// <summary>
        /// 最小コストソート
        /// - 配列を交換するコストを(w1+w2）とした時の最小コストを求める
        /// </summary>
        /// <param name="seq">対象配列</param>
        /// <returns></returns>
        public static int SillySort(int[] seq)
        {

            int cost = 0, s;
            node[] nodes = new node[seq.Count()];
            node[] tmp = new node[seq.Count()];

            for (int i = 0 ; i < seq.Count() ; i++) { tmp[i].value = seq[i]; tmp[i].place = i; }
            tmp = tmp.OrderBy(x => x.value).ToArray();
            for (int i = 0 ; i < seq.Count() ; i++) { nodes[i].value = seq[i]; nodes[tmp[i].place].place = i; }
            s = tmp[0].value;

            for (int i = 0 ; i < seq.Count() ; i++)
            {
                int j = nodes[i].place;
                if (j >= 0 && j != i)
                {
                    int n = 1, sum, amin;
                    amin = sum = nodes[i].value;
                    while (j != i)
                    {
                        int next = nodes[j].place;
                        amin = Math.Min(amin, nodes[j].value);
                        sum += nodes[j].value;
                        n++;
                        nodes[j].place = -1;
                        j = next;
                    }
                    cost += Math.Min(sum + ((n - 2) * amin), sum + amin + (n + 1) * s);
                }
            }

            return cost;
        }
        public struct node { public int value; public int place; }

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

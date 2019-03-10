using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace ALDS1_15_C
{
    public class Program

    {
        public struct Node : IComparable<Node>
        {
            public int Start { get; private set; }
            public int End { get; private set; }

            public Node(int s, int e)
            {
                Start = s;
                End = e;
            }

            public int CompareTo(Node other)
            {
                if (End - other.End > 0) return -1;
                else if (End - other.End < 0) return 1;
                else
                {
                    if (Start - other.Start > 0) return -1;
                    else if (End - other.End < 0) return 1;
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            int n = ReadInt();
            PriorityQueue<Node> pq = new PriorityQueue<Node>();

            for (int i = 0 ; i < n ; i++)
            {
                int[] item = ReadIntAr();
                pq.Enqueue(new Node(item[0], item[1]));
            }

            int res = 0;
            int currentTime = 0;
            while (pq.Count > 0)
            {
                Node tmp = pq.Dequeue();
                if (currentTime < tmp.Start)
                {
                    res++;
                    currentTime = tmp.End;
                }
            }
            Console.WriteLine(res.ToString());
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

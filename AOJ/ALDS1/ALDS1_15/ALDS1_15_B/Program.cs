using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace ALDS1_15_B
{
    public class Program

    {
        public struct Node:IComparable<Node>
        {
            public int Value { get; private set; }
            public int Weight { get; private set; }
            public double ValuePerWaight { get; private set; }

            public Node(int v,int w)
            {
                Value = v;
                Weight = w;
                ValuePerWaight = v / (double)w;
            }

            public int CompareTo(Node other)
            {
                if (ValuePerWaight - other.ValuePerWaight > 0)
                {
                    return 1;
                }
                else if (ValuePerWaight - other.ValuePerWaight < 1)
                {
                    return -1;
                }
                else { return 0; }
            }
        }

        public static void Main(string[] args)
        {
            int[] line = ReadIntAr();
            PriorityQueue<Node> pq = new PriorityQueue<Node>();

            for (int i = 0 ; i < line[0] ; i++)
            {
                int[] item = ReadIntAr();
                pq.Enqueue(new Node(item[0], item[1]));
            }

            int CurrentWeight = 0;
            decimal CurrentValue = 0;

            while (pq.Count > 0)
            {
                Node tmp = pq.Dequeue();

                if (CurrentWeight + tmp.Weight <= line[1])
                {
                    CurrentWeight += tmp.Weight;
                    CurrentValue += tmp.Value;
                }
                else
                {
                    int remainingWeight = line[1] - CurrentWeight;
                    CurrentWeight += remainingWeight;
                    CurrentValue += (decimal)tmp.ValuePerWaight * remainingWeight;
                    break;
                }            
            }
            Console.WriteLine(CurrentValue.ToString("F8"));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace ALDS1_9_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] line = ReadIntAr();

            CompleteBinaryTree<int> cbt = new CompleteBinaryTree<int>(n);
            for (int i = 0 ; i < n ; i++)
            {
                cbt.BinaryHeap[i] = line[i];
            }

            for (int i = 0 ; i < n ; i++)
            {
                Console.Write("node {0}: key = {1}, ", i + 1, cbt.BinaryHeap[i]);
                if (cbt.GetParent(i) != -1) Console.Write("parent key = {0}, ", cbt.BinaryHeap[cbt.GetParent(i)]);
                if (cbt.LeftChild(i) != -1) Console.Write("left key = {0}, ", cbt.BinaryHeap[cbt.LeftChild(i)]);
                if (cbt.RightChild(i) != -1) Console.Write("right key = {0}, ", cbt.BinaryHeap[cbt.RightChild(i)]);
                Console.Write(Environment.NewLine);
            }
        }

        class CompleteBinaryTree<T>
        {
            public T[] BinaryHeap { get; private set; }
            public int Count { get; private set; }

            public CompleteBinaryTree(int n)
            {
                BinaryHeap = new T[n];
                Count = 0;
            }

            public int GetParent(int i)
            {
                return ((i + 1) / 2) - 1;
            }
            public int LeftChild(int i)
            {
                int tmp = (i + 1) * 2 - 1;
                if (tmp < BinaryHeap.Count()) return tmp;
                else return -1;
            }
            public int RightChild(int i)
            {
                int tmp = (i + 1) * 2;
                if (tmp < BinaryHeap.Count()) return tmp;
                else return -1;
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

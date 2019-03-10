using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_9_B
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
                cbt.BinaryHeap[i + 1] = line[i];
            }

            cbt.buildMaxHeap();
            Console.WriteLine(" "+string.Join(" ", cbt.BinaryHeap.Where((x,index) => index > 0).Select(x => x.ToString()).ToArray()));
        }

        class CompleteBinaryTree<T> where T : IComparable<T>
        {
            public T[] BinaryHeap { get;private set; }
            public int Count { get; private set; }

            public CompleteBinaryTree(int n)
            {
                BinaryHeap = new T[n+1];
                Count = 0;
            }

            public int GetParent(int i)
            {
                return i / 2;
            }
            public int LeftChild(int i)
            {
                int tmp = i * 2;
                if (tmp < BinaryHeap.Count()) return tmp;
                else return -1;
            }
            public int RightChild(int i)
            {
                int tmp = i * 2 + 1;
                if (tmp < BinaryHeap.Count()) return tmp;
                else return -1;
            }

            public void buildMaxHeap()
            {
                for (int i = BinaryHeap.Count() / 2 ; i >= 1 ; i--)
                {
                    maxHeapify(i);
                }
            }

            private void maxHeapify(int i)
            {
                int l = LeftChild(i);
                int r = RightChild(i);
                int largest;
                if (l != -1 && BinaryHeap[l].CompareTo(BinaryHeap[i]) > 0)
                {
                    largest = l;
                }
                else { largest = i; }
                if (r != -1 && BinaryHeap[r].CompareTo(BinaryHeap[largest]) > 0)
                {
                    largest = r;
                }

                if (largest != i)
                {
                    T tmp = BinaryHeap[i];
                    BinaryHeap[i] = BinaryHeap[largest];
                    BinaryHeap[largest] = tmp;
                    maxHeapify(largest);
                }
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

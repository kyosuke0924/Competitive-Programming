using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
    class CompleteBinaryTree<T> where T : IComparable<T>
    {
        public T[] BinaryHeap { get; private set; }
        public int Count { get; private set; }

        public CompleteBinaryTree(int n)
        {
            BinaryHeap = new T[n + 1]; //0インデックスは番兵
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
}

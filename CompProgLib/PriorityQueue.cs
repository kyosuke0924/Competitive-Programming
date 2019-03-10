using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
    public class PriorityQueue<T> where T : IComparable<T>

    {

        private List<T> Buffer { get; set; }

        public int Count { get { return Buffer.Count; } }

        public PriorityQueue() { Buffer = new List<T>(); }
        public PriorityQueue(int capacity) { Buffer = new List<T>(capacity); }


        /// <summary>
        /// ヒープ化されている配列リストに新しい要素を追加する。
        /// </summary>
        public void Enqueue(T item)
        {
            int n = Buffer.Count;
            Buffer.Add(item);

            while (n != 0)
            {
                int i = (n - 1) / 2;
                if (Buffer[n].CompareTo(Buffer[i]) > 0)
                {
                    T tmp = Buffer[n]; Buffer[n] = Buffer[i]; Buffer[i] = tmp;
                }
                n = i;
            }
        }

        /// <summary>
        /// ヒープから最大値を取り出し、削除する。
        /// </summary>
        public T Dequeue()
        {
            T ret = Buffer[0];
            int n = Buffer.Count - 1;
            Buffer[0] = Buffer[n];
            Buffer.RemoveAt(n);

            for (int i = 0, j ; (j = 2 * i + 1) < n ;)
            {
                if ((j != n - 1) && (Buffer[j].CompareTo(Buffer[j + 1]) < 0))
                    j++;
                if (Buffer[i].CompareTo(Buffer[j]) < 0)
                {
                    T tmp = Buffer[j]; Buffer[j] = Buffer[i]; Buffer[i] = tmp;
                }
                i = j;
            }
            return ret;
        }

        /// <summary>
        /// ヒープから最大値を参照する。
        /// </summary>
        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException();
            return this.Buffer[0];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0095
{
    public class Program

    {
        public struct Node : IComparable<Node>
        {
            public int ID { get; set; }
            public int CNT { get; set; }
            public Node(int[] items) { ID = items[0]; CNT = items[1]; }
            public int CompareTo(Node other)
            {
                if (CNT != other.CNT) return CNT - other.CNT;
                else return other.ID - ID;
            }
        }

        public static void Main(string[] args)
        {
            PriorityQueue<Node> pq = new PriorityQueue<Node>();
            int n = RInt();
            for (int i = 0 ; i < n ; i++) pq.Enqueue(new Node(RIntAr()));
            var ans = pq.Dequeue();
            Console.WriteLine("{0} {1}", ans.ID, ans.CNT);
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

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

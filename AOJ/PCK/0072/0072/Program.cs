using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0072
{
    public class Program

    {
        static public Dictionary<int, Info> Adj { get; set; }
        public class Info
        {
            public bool IsVisited { get; internal set; }
            public List<KeyValuePair<int, int>> Vertex { get; internal set; }
            public Info() { Vertex = new List<KeyValuePair<int, int>>(); }
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int m = RInt();
                Adj = new Dictionary<int, Info>(m);
                for (int i = 0 ; i < m ; i++)
                {
                    int[] items = RIntAr(',');

                    if (!Adj.ContainsKey(items[0])) { Adj.Add(items[0], new Info()); }
                    Adj[items[0]].Vertex.Add(new KeyValuePair<int, int>(items[1], items[2] / 100 -1));

                    if (!Adj.ContainsKey(items[1])) { Adj.Add(items[1], new Info()); }
                    Adj[items[1]].Vertex.Add(new KeyValuePair<int, int>(items[0], items[2] / 100 -1));

                }

                Console.WriteLine(Prim());
            }

        }

        /// <summary>
        /// 最小全域木のコストを求める（プリム法）
        /// </summary>
        /// <returns></returns>
        class Edge : IComparable<Edge>
        {
            public int NextV { get; set; }
            public int Cost { get; set; }

            public Edge(int nextV, int cost)
            {
                NextV = nextV;
                Cost = cost;
            }

            public int CompareTo(Edge other)
            {
                return -1 * Cost.CompareTo(other.Cost);
            }
        }
        public static int Prim()
        {
            PriorityQueue<Edge> pq = new PriorityQueue<Edge>();
            int totalCost = 0;
            pq.Enqueue(new Edge(Adj.First().Key, 0));

            while (pq.Count > 0)
            {
                Edge e = pq.Dequeue();
                if (!Adj[e.NextV].IsVisited)
                {
                    Adj[e.NextV].IsVisited = true;
                    totalCost += e.Cost;
                    foreach (KeyValuePair<int, int> vertex in Adj[e.NextV].Vertex)
                    {
                        pq.Enqueue(new Edge(vertex.Key, vertex.Value));
                    }
                }
            }
            return totalCost;
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

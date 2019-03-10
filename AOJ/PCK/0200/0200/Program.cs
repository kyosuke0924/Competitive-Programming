using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0200
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] nm = RIntAr();
                if (nm.Sum() == 0) break;
                Init(nm);

                int k = RInt();
                for (int i = 0 ; i < k ; i++)
                {
                    int[] items = RIntAr();
                    Dijkstra(items[0], items[2]);
                    Console.WriteLine(Adj[items[1]].Distance);
                }
            }
        }

        private static void Init(int[] nm)
        {
            Adj = new Dictionary<int, Node>();
            for (int i = 1 ; i <= nm[1] ; i++)
            {
                Adj.Add(i, new Node());
            }

            for (int i = 0 ; i < nm[0] ; i++)
            {
                int[] items = RIntAr();
                Adj[items[0]].Vertex.Add(new KeyValuePair<int, List<int>>(items[1], new List<int> { items[2], items[3] }));
                Adj[items[1]].Vertex.Add(new KeyValuePair<int, List<int>>(items[0], new List<int> { items[2], items[3] }));
            }
        }

        /// <summary>
        /// 始点からの距離をセットする（ダイクストラ法）
        /// </summary>
        /// <param name="s">始点</param>

        public static Dictionary<int, Node> Adj { get; set; }
        public class Node
        {
            public List<KeyValuePair<int, List<int>>> Vertex { get; internal set; }
            public int Distance { get; internal set; }

            public Node()
            {
                Vertex = new List<KeyValuePair<int, List<int>>>();
                Distance = int.MaxValue;
            }
        }

        class Candidate : IComparable<Candidate>
        {
            public int V { get; set; }
            public int Distance { get; set; }

            public Candidate(int v, int d) { Distance = d; V = v; }
            public int CompareTo(Candidate other) { return -1 * Distance.CompareTo(other.Distance); }
        }

        public static void Dijkstra(int s, int costOtTime)
        {
            foreach (var item in Adj) item.Value.Distance = int.MaxValue;
            Adj[s].Distance = 0;
            PriorityQueue<Candidate> pq = new PriorityQueue<Candidate>();
            pq.Enqueue(new Candidate(s, Adj[s].Distance));

            while (pq.Count > 0)
            {

                Candidate c = pq.Dequeue();
                int v = c.V;
    
                if (Adj[v].Distance < c.Distance) continue;

                foreach (KeyValuePair<int, List<int>> nextV in Adj[v].Vertex)
                {
                    if (Adj[nextV.Key].Distance > Adj[v].Distance + nextV.Value[costOtTime])
                    {
                        Adj[nextV.Key].Distance = Adj[v].Distance + nextV.Value[costOtTime];
                        pq.Enqueue(new Candidate(nextV.Key, Adj[nextV.Key].Distance));
                    }
                }

            }
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

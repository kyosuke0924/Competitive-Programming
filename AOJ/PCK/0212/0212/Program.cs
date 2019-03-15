using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0212
{
    public class Program

    {
        public class IDAndRem : IEquatable<IDAndRem>
        {
            public int ID { get; set; }
            public int RemTicket { get; set; }
            public IDAndRem(int iD, int remTicket) { ID = iD; RemTicket = remTicket; }
            public bool Equals(IDAndRem other)
            {
                if (other == null) return false;
                else return ID == other.ID && RemTicket == other.RemTicket;
            }
            public override int GetHashCode() { return ID.GetHashCode() ^ RemTicket.GetHashCode(); }
        }

        public class Node
        {
            public List<KeyValuePair<IDAndRem, int>> Vertex { get; internal set; }
            public int Distance { get; internal set; }
            public Node()
            {
                Vertex = new List<KeyValuePair<IDAndRem, int>>();
                Distance = int.MaxValue;
            }
        }

        public static Dictionary<IDAndRem, Node> Adj { get; set; }

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] vs = RIntAr();
                if (vs.Sum() == 0) break;
                Init(vs);
                Dijkstra(new IDAndRem(vs[3], vs[0]));
                Console.WriteLine(Adj.Where(x => x.Key.ID == vs[4]).Min(x => x.Value.Distance));
            }
        }

        private static void Init(int[] vs)
        {
            Adj = new Dictionary<IDAndRem, Node>();
            int c = vs[0], n = vs[1], m = vs[2];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= c; j++)
                {
                    Adj.Add(new IDAndRem(i, j), new Node());
                }
            }

            for (int i = 0; i < m; i++)
            {
                int[] items = RIntAr();
                for (int j = c; j >= 0; j--)
                {
                    Adj[new IDAndRem(items[0], j)].Vertex.Add(new KeyValuePair<IDAndRem, int>(new IDAndRem(items[1], j), items[2]));
                    Adj[new IDAndRem(items[1], j)].Vertex.Add(new KeyValuePair<IDAndRem, int>(new IDAndRem(items[0], j), items[2]));

                    if (j > 0)
                    {
                        Adj[new IDAndRem(items[0], j)].Vertex.Add(new KeyValuePair<IDAndRem, int>(new IDAndRem(items[1], j - 1), items[2] / 2));
                        Adj[new IDAndRem(items[1], j)].Vertex.Add(new KeyValuePair<IDAndRem, int>(new IDAndRem(items[0], j - 1), items[2] / 2));
                    }
                }
            }
        }

        /// <summary>
        /// 始点からの距離をセットする（ダイクストラ法）
        /// </summary>
        /// <param name="s">始点</param>
        class Candidate : IComparable<Candidate>
        {
            public IDAndRem V { get; set; }
            public int Distance { get; set; }

            public Candidate(IDAndRem v, int d) { Distance = d; V = v; }
            public int CompareTo(Candidate other) { return -1 * Distance.CompareTo(other.Distance); }
        }

        public static void Dijkstra(IDAndRem s)
        {
            foreach (var item in Adj) item.Value.Distance = int.MaxValue;

            Adj[s].Distance = 0;
            PriorityQueue<Candidate> pq = new PriorityQueue<Candidate>();
            pq.Enqueue(new Candidate(s, Adj[s].Distance));

            while (pq.Count > 0)
            {
                Candidate c = pq.Dequeue();
                IDAndRem v = c.V;
                int d = c.Distance;

                if (Adj[v].Distance < c.Distance) continue;

                foreach (KeyValuePair<IDAndRem, int> nextV in Adj[v].Vertex)
                {
                    if (Adj[nextV.Key].Distance > Adj[v].Distance + nextV.Value)
                    {
                        Adj[nextV.Key].Distance = Adj[v].Distance + nextV.Value;
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

            for (int i = 0, j; (j = 2 * i + 1) < n;)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0244
{
    class Program
    {
        public enum Ticket { Unused, Using, Used }

        public class IDAndTik : IEquatable<IDAndTik>
        {
            public int ID { get; set; }
            public Ticket Status { get; set; }
            public IDAndTik(int iD, Ticket status) { ID = iD; Status = status; }
            public bool Equals(IDAndTik other)
            {
                if (other == null) return false;
                else return ID == other.ID && Status == other.Status;
            }
            public override int GetHashCode() { return ID.GetHashCode() ^ Status.GetHashCode(); }
        }

        public class Node
        {
            public List<KeyValuePair<IDAndTik, int>> V { get; internal set; }
            public int Distance { get; internal set; }
            public Node()
            {
                V = new List<KeyValuePair<IDAndTik, int>>();
                Distance = int.MaxValue;
            }
        }

        public static Dictionary<IDAndTik, Node> Adj { get; set; }
        static int n, m;

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] vs = RArInt();
                if (vs.Sum() == 0) break;
                n = vs[0]; m = vs[1];
                Init();
                Dijkstra(new IDAndTik(1, 0));
                Console.WriteLine(Adj.Where(x => x.Key.ID == n && x.Key.Status != Ticket.Using).Min(x => x.Value.Distance));
            }
        }

        private static void Init()
        {
            Adj = new Dictionary<IDAndTik, Node>();
            for (int i = 1; i <= n; i++)
            {
                foreach (Ticket value in Enum.GetValues(typeof(Ticket)))
                {
                    Adj.Add(new IDAndTik(i, value), new Node());
                }
            }

            for (int i = 0; i < m; i++)
            {
                int[] vs = RArInt();
                for (int j = 0; j < 2; j++)
                {
                    Adj[new IDAndTik(vs[j], Ticket.Unused)].V.Add(new KeyValuePair<IDAndTik, int>(new IDAndTik(vs[j ^ 1], Ticket.Unused), vs[2]));
                    Adj[new IDAndTik(vs[j], Ticket.Unused)].V.Add(new KeyValuePair<IDAndTik, int>(new IDAndTik(vs[j ^ 1], Ticket.Using), 0));
                    Adj[new IDAndTik(vs[j], Ticket.Using)].V.Add(new KeyValuePair<IDAndTik, int>(new IDAndTik(vs[j ^ 1], Ticket.Used), 0));
                    Adj[new IDAndTik(vs[j], Ticket.Used)].V.Add(new KeyValuePair<IDAndTik, int>(new IDAndTik(vs[j ^ 1], Ticket.Used), vs[2]));
                }
            }
        }

        /// <summary>
        /// 始点からの距離をセットする（ダイクストラ法）
        /// </summary>
        /// <param name="s">始点</param>
        class Candidate : IComparable<Candidate>
        {
            public IDAndTik V { get; set; }
            public int Distance { get; set; }

            public Candidate(IDAndTik v, int d) { Distance = d; V = v; }
            public int CompareTo(Candidate other) { return -1 * Distance.CompareTo(other.Distance); }
        }

        public static void Dijkstra(IDAndTik s)
        {
            foreach (var item in Adj) item.Value.Distance = int.MaxValue;

            Adj[s].Distance = 0;
            PriorityQueue<Candidate> pq = new PriorityQueue<Candidate>();
            pq.Enqueue(new Candidate(s, Adj[s].Distance));

            while (pq.Count > 0)
            {
                Candidate c = pq.Dequeue();
                IDAndTik v = c.V;
                int d = c.Distance;

                if (Adj[v].Distance < c.Distance) continue;

                foreach (KeyValuePair<IDAndTik, int> nextV in Adj[v].V)
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
        static string[] RArSt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RArInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RArLong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RArDouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
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

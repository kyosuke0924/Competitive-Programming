using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0155
{
    public class Program

    {
        static public Dictionary<int, Building> Adj;
        static public int[] Path;
        public class Building
        {
            public int X { get; set; }
            public int Y { get; set; }
            public double Distance { get; internal set; }
            public List<KeyValuePair<int, double>> NextBuilding { get; internal set; }
            public Building(int[] v) { X = v[1]; Y = v[2]; Distance = int.MaxValue; }

        }

        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                Adj = new Dictionary<int, Building>();
                for (int i = 0 ; i < n ; i++)
                {
                    int[] items = RIntAr();
                    Building tmp = new Building(items);

                    List<KeyValuePair<int, double>> nextBuilding = new List<KeyValuePair<int, double>>();

                    foreach (var item in Adj)
                    {
                        int distance = (int)Math.Pow(Math.Abs(tmp.X - item.Value.X), 2) + (int)Math.Pow(Math.Abs(tmp.Y - item.Value.Y), 2);
                        if (distance <= 2500)
                        {
                            nextBuilding.Add(new KeyValuePair<int, double>(item.Key, Math.Sqrt(distance)));
                            item.Value.NextBuilding.Add(new KeyValuePair<int, double>(items[0], Math.Sqrt(distance)));
                        }
                    }
                    tmp.NextBuilding = nextBuilding;
                    Adj.Add(items[0], tmp);
                }

                int m = RInt();
                for (int i = 0 ; i < m ; i++)
                {
                    Path = new int[n + 1];
                    int[] items = RIntAr();
                    foreach (var item in Adj) item.Value.Distance = int.MaxValue;

                    Dijkstra(items[0]);

                    if (Path[items[1]] == 0)
                    {
                        Console.WriteLine("NA");
                    }
                    else
                    {
                        Stack<int> res = new Stack<int>();
                        res.Push(items[1]);
                        while (Path[res.Peek()] > 0) res.Push(Path[res.Peek()]);
                        Console.WriteLine(WAr(res));
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
            public int V { get; set; }
            public double Distance { get; set; }

            public Candidate(int v, double d) { Distance = d; V = v; }
            public int CompareTo(Candidate other) { return -1 * Distance.CompareTo(other.Distance); }
        }

        public static void Dijkstra(int s)
        {
            Adj[s].Distance = 0;
            PriorityQueue<Candidate> pq = new PriorityQueue<Candidate>();
            pq.Enqueue(new Candidate(s, Adj[s].Distance));

            while (pq.Count > 0)
            {

                Candidate c = pq.Dequeue();
                int v = c.V;
                double d = c.Distance;

                if (Adj[v].Distance < c.Distance)
                {
                    continue;
                }

                foreach (KeyValuePair<int, double> nextV in Adj[v].NextBuilding)
                {
                    if (Adj[nextV.Key].Distance > Adj[v].Distance + nextV.Value)
                    {
                        Adj[nextV.Key].Distance = Adj[v].Distance + nextV.Value;
                        Path[nextV.Key] = v;
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

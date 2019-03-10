using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0180
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] nm = RIntAr();
                if (nm.Sum() == 0) break;

                Graph gh = new Graph();
                for (int i = 0 ; i < nm[0] ; i++) gh.Adj.Add(i, new Graph.Node(new List<int>()));

                for (int i = 0 ; i < nm[1] ; i++)
                {
                    var tmp = RIntAr();
                    gh.AddVertex(tmp[0], tmp[1], tmp[2]);
                    gh.AddVertex(tmp[1], tmp[0], tmp[2]);
                }

                Console.WriteLine(gh.Prim());
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

    public class Graph
    {
        public class Node
        {
            public List<KeyValuePair<int, int>> Vertex { get; internal set; }
            public int D { get; internal set; }
            public int F { get; internal set; }
            public bool IsVisited { get; internal set; }
            public int Group { get; internal set; }
            public int Depth { get; internal set; }
            public int Distance { get; internal set; }

            public Node(List<int> v)
            {
                Vertex = v.Select(x => new KeyValuePair<int, int>(x, -1)).ToList();
                Depth = -1;
                Group = -1;
                Distance = int.MaxValue;
            }

            public Node(List<KeyValuePair<int, int>> v)
            {
                Vertex = v;
                Depth = -1;
                Group = -1;
                Distance = int.MaxValue;
            }

        }

        public Dictionary<int, Node> Adj { get; set; }
        public int Count { get { return Adj.Count; } }

        public Graph()
        {
            Adj = new Dictionary<int, Node>();
        }

        public void AddVertex(int index, int v, int cost)
        {
            if (!Adj[index].Vertex.Contains(new KeyValuePair<int, int>(v, cost)))
            {
                Adj[index].Vertex.Add(new KeyValuePair<int, int>(v, cost));
            }
        }


        /// <summary>
        /// 指定した頂点をセットする
        /// </summary>
        /// <param name="index">頂点u</param>
        /// <param name="item">頂点uに接続する頂点</param>
        public void SetGraph(int index, int[] item)
        {
            if (item == null)
            {
                Adj.Add(index, new Node(new List<int>()));
            }
            else
            {
                Adj.Add(index, new Node(item.ToList()));
            }
        }

        public void SetGraph(int index, List<KeyValuePair<int, int>> item)
        {
            if (item == null)
            {
                Adj.Add(index, new Node(new List<int>()));
            }
            else
            {
                Adj.Add(index, new Node(item));
            }
        }

        public void SetGraph(int index, int v, int c)
        {
            if (!Adj.ContainsKey(index))
            {
                SetGraph(index);
            }
            Adj[index].Vertex.Add(new KeyValuePair<int, int>(v, c));
        }

        public void SetGraph(int index)
        {
            if (!Adj.ContainsKey(index))
            {
                Adj.Add(index, new Node(new List<KeyValuePair<int, int>>()));
            }
        }


        /// <summary>
        /// 行列を0で初期化する
        /// </summary>
        public void Clear() { Adj.Clear(); }

        /// <summary>
        /// 深さ優先探索
        /// </summary>
        private int Time = 0;
        public void DFS(int v)
        {
            Adj[v].D = ++Time;
            Adj[v].IsVisited = true;
            foreach (KeyValuePair<int, int> vertex in Adj[v].Vertex)
            {
                if (!Adj[vertex.Key].IsVisited) DFS(vertex.Key);
            }
            Adj[v].F = ++Time;
        }

        /// <summary>
        /// 訪問済フラグをクリアする
        /// </summary>
        private void InitVisitFlag()
        {
            foreach (KeyValuePair<int, Node> item in Adj) item.Value.IsVisited = false;
        }

        /// <summary>
        /// 幅優先探索
        /// </summary>
        /// <param name="v"></param>
        public void BFS(int v)
        {
            Queue<Node> que = new Queue<Node>();

            Adj[v].Depth = 0;
            Adj[v].IsVisited = true;
            que.Enqueue(Adj[v]);

            while (que.Count() != 0)
            {
                Node node = que.Dequeue();
                foreach (KeyValuePair<int, int> vertex in node.Vertex)
                {
                    if (!Adj[vertex.Key].IsVisited)
                    {
                        Adj[vertex.Key].IsVisited = true;
                        Adj[vertex.Key].Depth = node.Depth + 1;
                        que.Enqueue(Adj[vertex.Key]);

                    }
                }
            }

        }

        /// <summary>
        /// 頂点間の最小頂点数を返す
        /// </summary>
        /// <param name="start">始点</param>
        /// <param name="end">終点</param>
        /// <returns>
        /// 始点と終点の距離
        /// 始点と終点が連結されていない場合は-1を返す
        /// </returns>
        public int GetDistance(int start, int end)
        {
            InitVisitFlag();
            Queue<Node> que = new Queue<Node>();

            Adj[start].IsVisited = true;
            Adj[start].Depth = 0;

            if (start == end) return Adj[start].Depth;
            que.Enqueue(Adj[start]);

            while (que.Count() != 0)
            {
                Node node = que.Dequeue();
                foreach (KeyValuePair<int, int> vertex in node.Vertex)
                {
                    if (!Adj[vertex.Key].IsVisited)
                    {
                        Adj[vertex.Key].IsVisited = true;
                        Adj[vertex.Key].Depth = node.Depth + 1;

                        if (vertex.Key == end) return Adj[vertex.Key].Depth;
                        que.Enqueue(Adj[vertex.Key]);
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// 連結である頂点に同一のグループ番号をセットする
        /// </summary>
        public void SetGroup()
        {
            int group = 0;
            foreach (KeyValuePair<int, Node> item in Adj)
            {
                if (item.Value.Group < 0)
                {
                    _SetGroup(item.Key, group);
                }
                group++;
            }
        }

        private void _SetGroup(int key, int group)
        {

            Queue<Node> que = new Queue<Node>();

            Adj[key].Group = group;
            que.Enqueue(Adj[key]);

            while (que.Count() != 0)
            {
                Node node = que.Dequeue();
                foreach (KeyValuePair<int, int> vertex in node.Vertex)
                {
                    if (Adj[vertex.Key].Group < 0)
                    {
                        Adj[vertex.Key].Group = group;
                        que.Enqueue(Adj[vertex.Key]);
                    }
                }
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
        public int Prim()
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

        /// <summary>
        /// 始点からの距離をセットする（ダイクストラ法）
        /// </summary>
        /// <param name="s">始点</param>
        class Candidate : IComparable<Candidate>
        {
            public int V { get; set; }
            public int Distance { get; set; }

            public Candidate(int v, int d) { Distance = d; V = v; }
            public int CompareTo(Candidate other) { return -1 * Distance.CompareTo(other.Distance); }
        }
        public void Dijkstra(int s)
        {
            Adj[s].Distance = 0;
            PriorityQueue<Candidate> pq = new PriorityQueue<Candidate>();
            pq.Enqueue(new Candidate(s, Adj[s].Distance));

            while (pq.Count > 0)
            {

                Candidate c = pq.Dequeue();
                int v = c.V;
                int d = c.Distance;

                if (Adj[v].Distance < c.Distance)
                {
                    continue;
                }

                foreach (KeyValuePair<int, int> nextV in Adj[v].Vertex)
                {
                    if (Adj[nextV.Key].Distance > Adj[v].Distance + nextV.Value)
                    {
                        Adj[nextV.Key].Distance = Adj[v].Distance + nextV.Value;
                        pq.Enqueue(new Candidate(nextV.Key, Adj[nextV.Key].Distance));
                    }
                }

            }
        }

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


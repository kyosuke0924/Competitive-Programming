using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0144
{
    public class Program

    {
        public static void Main(string[] args)
        {
            Graph gh = new Graph();
            int n = RInt();
            for (int i = 0 ; i < n ; i++)
            {
                int[] items = RIntAr();
                gh.SetGraph(items[0], items.Skip(2).ToArray());
            }

            int p = RInt();
            for (int i = 0 ; i < p ; i++)
            {
                int[] sdv = RIntAr();
                int distance = gh.GetDistance(sdv[0], sdv[1]);
                Console.WriteLine((distance < sdv[2] && distance != -1) ? (distance + 1).ToString() : "NA");
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

}

public class Graph
{
    public class Node
    {
        public List<KeyValuePair<int, int>> Vertex { get; internal set; }
        public bool IsVisited { get; internal set; }
        public int Depth { get; internal set; }

        public Node(List<int> v)
        {
            Vertex = v.Select(x => new KeyValuePair<int, int>(x, -1)).ToList();
            Depth = -1;
        }
    }

    public Dictionary<int, Node> Adj { get; set; }
    public int Count { get { return Adj.Count; } }

    public Graph()
    {
        Adj = new Dictionary<int, Node>();
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

    /// <summary>
    /// 訪問済フラグをクリアする
    /// </summary>
    private void InitVisitFlag()
    {
        foreach (KeyValuePair<int, Node> item in Adj) item.Value.IsVisited = false;
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
}


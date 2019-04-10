using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0224
{
    class Program
    {
        public const string START = "H";
        public const string GOAL = "D";

        public static Dictionary<string, Node> Adj { get; set; }
        public class Node
        {
            public List<KeyValuePair<string, int>> Vertex { get; internal set; }
            public Node()
            {
                Vertex = new List<KeyValuePair<string, int>>();
            }
        }

        public static Dictionary<string, int[]> distances;
        public static int CakeShopCnt;
        public static int[] CakeCals;

        static void Main(string[] args)
        {
            while (true)
            {
                int[] vs = RArInt();
                if (vs.Sum() == 0) break;
                Init(vs);
                Console.WriteLine(CalcMinCal());
            }
        }

        private static void Init(int[] vs)
        {
            CakeShopCnt = vs[0];
            CakeCals = RArInt();

            Adj = new Dictionary<string, Node>();
            distances = new Dictionary<string, int[]>();

            Adj.Add(START, new Node());
            distances.Add(START, new int[1 << CakeShopCnt]);

            Adj.Add(GOAL, new Node());
            distances.Add(GOAL, new int[1 << CakeShopCnt]);

            for (int i = 0; i < vs[0]; i++)
            {
                string key = "C" + (i + 1).ToString();
                Adj.Add(key, new Node());
                distances.Add(key, new int[1 << CakeShopCnt]);
            }
            for (int i = 0; i < vs[1]; i++)
            {
                string key = "L" + (i + 1).ToString();
                Adj.Add(key, new Node());
                distances.Add(key, new int[1 << CakeShopCnt]);

            }
            for (int i = 0; i < vs[3]; i++)
            {
                string[] items = RArSt();
                Adj[items[0]].Vertex.Add(new KeyValuePair<string, int>(items[1], int.Parse(items[2]) * vs[2]));
                Adj[items[1]].Vertex.Add(new KeyValuePair<string, int>(items[0], int.Parse(items[2]) * vs[2]));
            }
            foreach (var distance in distances)
            {
                for (int i = 0; i < distance.Value.Length; i++)
                {
                    distance.Value[i] = int.MaxValue;
                }
            }
        }

        class Candidate : IComparable<Candidate>
        {
            public string V { get; set; }
            public int Distance { get; set; }
            public int Path { get; set; }

            public Candidate(string v, int d, int path) { Distance = d; V = v; Path = path; }
            public int CompareTo(Candidate other) { return -1 * Distance.CompareTo(other.Distance); }
        }
        private static int CalcMinCal()
        {
            distances[START][0] = 0;
            PriorityQueue<Candidate> pq = new PriorityQueue<Candidate>();
            pq.Enqueue(new Candidate("H", distances["H"][0], 0));

            while (pq.Count > 0)
            {
                Candidate c = pq.Dequeue();
                string v = c.V;
                int d = c.Distance;
                int p = c.Path;

                if (distances[v][p] < d) continue;

                foreach (KeyValuePair<string, int> nextV in Adj[v].Vertex)
                {
                    if (nextV.Key[0] == 'C')
                    {
                        int curCakeShop = int.Parse(nextV.Key[1].ToString()) - 1;
                        if ((p & (1 << curCakeShop)) > 0) continue;
                        int nextP = p | (1 << curCakeShop);
                        int nextD = distances[v][p] + nextV.Value - CakeCals[curCakeShop];

                        if (distances[nextV.Key][nextP] > nextD)
                        {
                            distances[nextV.Key][nextP] = nextD;
                            pq.Enqueue(new Candidate(nextV.Key, nextD, nextP));
                        }
                    }
                    else
                    {
                        int nextD = distances[v][p] + nextV.Value;

                        if (distances[nextV.Key][p] > nextD)
                        {
                            distances[nextV.Key][p] = nextD;
                            pq.Enqueue(new Candidate(nextV.Key, nextD, p));
                        }
                    }
                }
            }
            return distances[GOAL].Min();
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

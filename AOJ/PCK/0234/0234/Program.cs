using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0234
{
    class Program
    {
        enum VisitedStatus { UnVisited, VisitedWithLessOxy, Visited }

        class State : IComparable<State>
        {
            public int I { get; set; }
            public int J { get; set; }
            public int Cost { get; set; }
            public int RestOxy { get; set; }
            public int[,] Visited { get; set; }
            public State(int i, int j, int cost, int restOxy, int[,] visited)
            {
                I = i;
                J = j;
                Cost = cost;
                RestOxy = restOxy;

                Visited = new int[visited.GetLength(0), visited.GetLength(1)];
                for (int vi = 0; vi < visited.GetLength(0); vi++)
                {
                    for (int vj = 0; vj < visited.GetLength(1); vj++)
                    {
                        Visited[vi, vj] = visited[vi, vj];
                    }
                }
                Visited[i, j] = restOxy;
            }

            public int CompareTo(State other)
            {
                return -1 * (this.Cost - other.Cost);
            }

            public VisitedStatus GetVisitedStatus(int i, int j, int restOxy)
            {
                if (Visited[i, j] == int.MaxValue) return VisitedStatus.UnVisited;
                if (Visited[i, j] < restOxy) return VisitedStatus.VisitedWithLessOxy;
                else return VisitedStatus.Visited;
            }
        }

        static readonly int[] dj = new int[] { 1, -1, 0 };
        static readonly int[] di = new int[] { 0, 0, 1 };
        static int maxCost;
        static int maxOxy;
        static int startOxy;
        static int[,] map;

        static void Main(string[] args)
        {
            while (true)
            {
                int[] wh = RArInt();
                if (wh.Sum() == 0) break;
                Init(wh);
                Console.WriteLine(CalcMinCost());
            }
        }

        private static void Init(int[] wh)
        {
            int[] vs = RArInt();
            maxCost = vs[0]; maxOxy = vs[1]; startOxy = vs[2];

            map = new int[wh[1], wh[0]];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                vs = RArInt();
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = vs[j];
                }
            }
        }

        private static string CalcMinCost()
        {
            PriorityQueue<State> q = new PriorityQueue<State>();

            startOxy--;
            if (startOxy <= 0) return "NA";

            int[,] startVisited = new int[map.GetLength(0), map.GetLength(1)];
            for (int vi = 0; vi < startVisited.GetLength(0); vi++)
            {
                for (int vj = 0; vj < startVisited.GetLength(1); vj++)
                {
                    startVisited[vi, vj] = int.MaxValue;
                }
            }

            for (int i = 0; i < map.GetLength(1); i++)
            {
                if (map[0, i] < 0)
                {
                    q.Enqueue(new State(0, i, -map[0, i], startOxy, startVisited));
                }
                else
                {
                    q.Enqueue(new State(0, i, 0, SupplyOxy(startOxy, 0, i), startVisited));
                }
            }

            while (q.Count > 0)
            {
                State cur = q.Dequeue();

                if (cur.I == map.GetLength(0) - 1)
                    return cur.Cost.ToString();

                cur.RestOxy--;
                if (cur.RestOxy <= 0) continue;

                for (int i = 0; i < di.Length; i++)
                {
                    int nextI = cur.I + di[i];
                    int nextJ = cur.J + dj[i];
                    if (!CanMove(nextJ)) continue;

                    if (map[nextI, nextJ] < 0)
                    {
                        int nextOxy = cur.RestOxy;
                        switch (cur.GetVisitedStatus(nextI, nextJ, nextOxy))
                        {
                            case VisitedStatus.UnVisited:
                                int nextCost = cur.Cost + -map[nextI, nextJ];
                                if (nextCost <= maxCost) q.Enqueue(new State(nextI, nextJ, nextCost, nextOxy, cur.Visited));
                                break;
                            case VisitedStatus.VisitedWithLessOxy:
                                q.Enqueue(new State(nextI, nextJ, cur.Cost, nextOxy, cur.Visited));
                                break;
                        }
                    }
                    else
                    {
                        int nextOxy = SupplyOxy(cur.RestOxy, nextI, nextJ);
                        switch (cur.GetVisitedStatus(nextI, nextJ, nextOxy))
                        {
                            case VisitedStatus.UnVisited:
                                q.Enqueue(new State(nextI, nextJ, cur.Cost, nextOxy, cur.Visited));
                                break;
                            case VisitedStatus.VisitedWithLessOxy:
                                q.Enqueue(new State(nextI, nextJ, cur.Cost, cur.RestOxy, cur.Visited));
                                break;
                        }
                    }
                }
            }
            return "NA";
        }

        private static bool CanMove(int j)
        {
            return 0 <= j && j < map.GetLength(1);
        }

        private static int SupplyOxy(int curOxy, int i, int j)
        {
            return Math.Min(maxOxy, curOxy + map[i, j]);
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
                if ((j != n - 1) && (Buffer[j].CompareTo(Buffer[j + 1]) < 0)) j++;
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


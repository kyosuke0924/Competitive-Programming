using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0215
{

    public class Creature
    {
        public int ID { get; set; }
        public int I { get; set; }
        public int J { get; set; }
        public Creature(int id, int i, int j) { ID = id; I = i; J = j; }
        public static int CalcDistance(Creature a, Creature b)
        {
            return Math.Abs(a.I - b.I) + Math.Abs(a.J - b.J);
        }
    }

    public class Program
    {
        private const int TYPES = 5;
        private const int MAXCNT_IN_TYPE = 1000;

        private static Creature start;
        private static Creature goal;
        private static List<Creature>[] creatures;
        private static int[] distances;

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] vs = RIntAr();
                if (vs.Sum() == 0) break;

                Init(vs);
                if (creatures.Count(x => x.Count() == 0) > 1)
                {
                    Console.WriteLine("NA"); //2種類以上のクリーチャーがフィールドにいない場合は達成不可
                }
                else
                {
                    var tup = CalcDistance();
                    Console.WriteLine(tup.Item1 == int.MaxValue ? "NA" : "{0} {1}", tup.Item1 + 1, tup.Item2);
                }
            }
        }

        private static void Init(int[] vs)
        {
            creatures = new List<Creature>[TYPES];
            for (int i = 0; i < creatures.Count(); i++) creatures[i] = new List<Creature>(MAXCNT_IN_TYPE);

            int id = 1;
            for (int i = 0; i < vs[1]; i++)
            {
                string line = RSt();
                for (int j = 0; j < vs[0]; j++)
                {
                    switch (line[j])
                    {
                        case 'S':
                            start = new Creature(0, i, j);
                            break;
                        case 'G':
                            goal = new Creature(TYPES * MAXCNT_IN_TYPE + 1, i, j);
                            break;
                        case '.':
                            break;
                        default:
                            int type = int.Parse(line[j].ToString()) - 1;
                            creatures[type].Add(new Creature(id, i, j));
                            id++;
                            break;
                    }
                }
            }
        }

        private static Tuple<int, int> CalcDistance()
        {
            int minIdx = int.MaxValue;
            int minD = int.MaxValue;
            for (int i = 0; i < TYPES; i++)
            {
                distances = new int[TYPES * MAXCNT_IN_TYPE + 2];
                for (int j = 0; j < distances.Length; j++) distances[j] = int.MaxValue;
                Dijkstra(i);
                if (distances[goal.ID] < minD)
                {
                    minIdx = i;
                    minD = distances[goal.ID];
                }
            }
            return new Tuple<int, int>(minIdx, minD);
        }

        /// <summary>
        /// 始点からの距離をセットする（ダイクストラ法）
        /// </summary>
        /// <param name="s">始めに所持している属性</param>
        class Candidate : IComparable<Candidate>
        {
            public int I { get; set; } //何本目の辺か
            public Creature V { get; set; }
            public int Distance { get; set; }
            public Candidate(int i, Creature v, int d) { I = i; V = v; Distance = d; }
            public int CompareTo(Candidate other) { return -1 * Distance.CompareTo(other.Distance); }
        }
        public static void Dijkstra(int s)
        {
            distances[start.ID] = 0;
            PriorityQueue<Candidate> pq = new PriorityQueue<Candidate>();
            pq.Enqueue(new Candidate(1, start, 0));

            while (pq.Count > 0)
            {
                Candidate c = pq.Dequeue();
                int i = c.I;
                Creature v = c.V;
                int d = c.Distance;

                if (distances[v.ID] < d) continue;
                if (v.ID == goal.ID) break;

                List<Creature> nexts = new List<Creature>();
                if (i < TYPES) nexts = creatures[(s + i) % TYPES];
                else nexts.Add(goal);

                foreach (var nextV in nexts)
                {
                    int tmpdist = distances[v.ID] + Creature.CalcDistance(v, nextV);
                    if (distances[nextV.ID] > tmpdist)
                    {
                        distances[nextV.ID] = tmpdist;
                        pq.Enqueue(new Candidate(i + 1, nextV, distances[nextV.ID]));
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
                if ((j != n - 1) && (Buffer[j].CompareTo(Buffer[j + 1]) < 0))  j++;
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
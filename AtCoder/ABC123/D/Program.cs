using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D
{

    class Program
    {
        public class Cand : IComparable<Cand>
        {
            public int Ai;
            public int Bi;
            public int Ci;
            public Cand(int ai, int bi, int ci)
            {
                Ai = ai;
                Bi = bi;
                Ci = ci;
            }
            public long Value()
            {
                return As[Ai] + Bs[Bi] + Cs[Ci];
            }

            public int CompareTo(Cand other)
            {
                long diff = Value() - other.Value();

                if (diff > 0) return 1;
                if (diff < 0) return -1;
                else return 0;
            }
        }

        public static long[] As;
        public static long[] Bs;
        public static long[] Cs;

        static void Main(string[] args)
        {
            int[] xyzk = RArInt();

            int aMax = xyzk[0];
            int bMax = xyzk[1];
            int cMax = xyzk[2];
            int k = xyzk[3];

            As = RArLong();
            Bs = RArLong();
            Cs = RArLong();

            As = As.OrderByDescending(x => x).ToArray();
            Bs = Bs.OrderByDescending(x => x).ToArray();
            Cs = Cs.OrderByDescending(x => x).ToArray();

            PriorityQueue<Cand> pq = new PriorityQueue<Cand>();
            pq.Enqueue(new Cand(0, 0, 0));

            int cnt = 0;
            bool[,,] closed = new bool[aMax, bMax, cMax];

            while (pq.Count > 0)
            {
                if (cnt == k) break;
                Cand cand = pq.Dequeue();

                if (!closed[cand.Ai, cand.Bi, cand.Ci])
                {
                    Console.WriteLine(cand.Value());
                    closed[cand.Ai, cand.Bi, cand.Ci] = true;

                    if (cand.Ai + 1 < aMax) pq.Enqueue(new Cand(cand.Ai + 1, cand.Bi, cand.Ci));
                    if (cand.Bi + 1 < bMax) pq.Enqueue(new Cand(cand.Ai, cand.Bi + 1, cand.Ci));
                    if (cand.Ci + 1 < cMax) pq.Enqueue(new Cand(cand.Ai, cand.Bi, cand.Ci + 1));
                    cnt++;
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

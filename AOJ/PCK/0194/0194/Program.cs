using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0194
{
    public class Program

    {
        public enum Direction { S, W, N, E, Count }
        public static int[] di = new int[] { 1, 0, -1, 0 };
        public static int[] dj = new int[] { 0, -1, 0, 1 };

        public class State : IComparable<State>
        {
            public int I { get; set; }
            public int J { get; set; }
            public Direction AppDir { get; set; }
            public int Time { get; set; }
            public State(int i, int j, Direction appdir, int time)
            {
                I = i; J = j; AppDir = appdir; Time = time;
            }

            public int CompareTo(State other)
            {
                return -1 * (Time - other.Time);
            }
        }

        public static bool[,,,] visited;//i,j,direction,time
        public static int d;
        public static int[,] signal; //i,j
        public static bool[,,] notPass; //i,j,direction
        public static int[,,] delay; //i,j,direction

        public static int endI;
        public static int endJ;

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] mn = RIntAr();
                if (mn.Sum() == 0) break;

                Init(mn);

                string[] startEnd = RStAr();
                string[] start = startEnd[0].Split('-');
                string[] end = startEnd[1].Split('-');

                endI = ChangeCharToInt(end[0][0]);
                endJ = int.Parse(end[1]) - 1;

                PriorityQueue<State> q = new PriorityQueue<State>();
                q.Enqueue(new State(ChangeCharToInt(start[0][0]), int.Parse(start[1]) - 1, Direction.W, 0));
                visited[ChangeCharToInt(start[0][0]), int.Parse(start[1]) - 1, (int)Direction.W, 0] = true;

                int min = 100;

                while (q.Count > 0)
                {
                    State cur = q.Dequeue();
                   
                    if (cur.I == endI && cur.J == endJ)
                    {
                        min = cur.Time;
                        break;
                    }

                    for (int i = 0 ; i < (int)Direction.Count ; i++)
                    {
                        if ((Direction)i == cur.AppDir) continue;

                        Direction nextD = (Direction)i;
                        int nextI = cur.I + di[(int)nextD];
                        int nextJ = cur.J + dj[(int)nextD];
                        int nextT = cur.Time + d + delay[cur.I, cur.J, (int)nextD];

                        if (IsInArea(nextI, nextJ) && nextT < min && !visited[nextI, nextJ, (int)GetOpponent(nextD), nextT])
                        {
                            if (!notPass[cur.I, cur.J, (int)nextD] && IsSignalOK(nextI, nextJ, GetOpponent(nextD), nextT))
                            {
                                visited[nextI, nextJ, (int)GetOpponent(nextD), nextT] = true;
                                q.Enqueue(new State(nextI, nextJ, GetOpponent(nextD), nextT));
                            }
                        }
                    }
                }

                Console.WriteLine(min);

            }
        }

        private static void Init(int[] mn)
        {

            d = RInt();
            visited = new bool[mn[0], mn[1], (int)Direction.Count, 101];

            signal = new int[mn[0], mn[1]];
            int ns = RInt();
            for (int k = 0 ; k < ns ; k++) //signal
            {
                string[] items = RStAr();
                string[] ij = items[0].Split('-');
                signal[ChangeCharToInt(ij[0][0]), int.Parse(ij[1]) - 1] = int.Parse(items[1]);
            }

            notPass = new bool[mn[0], mn[1], 4];
            int nc = RInt();
            for (int k = 0 ; k < nc ; k++)
            {
                string[] items = RStAr();
                string[] ij1 = items[0].Split('-');
                string[] ij2 = items[1].Split('-');
                notPass[ChangeCharToInt(ij1[0][0]), int.Parse(ij1[1]) - 1, (int)GetDirection(ij1, ij2)] = true;
                notPass[ChangeCharToInt(ij2[0][0]), int.Parse(ij2[1]) - 1, (int)GetDirection(ij2, ij1)] = true;
            }

            delay = new int[mn[0], mn[1], 4];
            int nj = RInt();
            for (int i = 0 ; i < nj ; i++)
            {
                string[] items = RStAr();
                string[] ij1 = items[0].Split('-');
                string[] ij2 = items[1].Split('-');
                delay[ChangeCharToInt(ij1[0][0]), int.Parse(ij1[1]) - 1, (int)GetDirection(ij1, ij2)] = int.Parse(items[2]);
                delay[ChangeCharToInt(ij2[0][0]), int.Parse(ij2[1]) - 1, (int)GetDirection(ij2, ij1)] = int.Parse(items[2]);
            }

        }

        private static int ChangeCharToInt(char c) { return c - 'a'; }

        private static Direction GetOpponent(Direction d) { return (Direction)(((int)d + 2) % (int)Direction.Count); }

        private static Direction GetDirection(string[] ij1, string[] ij2)
        {
            int si = ChangeCharToInt(ij1[0][0]);
            int sj = int.Parse(ij1[1]) - 1;
            int ti = ChangeCharToInt(ij2[0][0]);
            int tj = int.Parse(ij2[1]) - 1;

            if (si == ti)
            {
                if (sj < tj) return Direction.E;
                else return Direction.W;
            }
            else
            {
                if (si < ti) return Direction.S;
                else return Direction.N;
            }
        }

        private static bool IsSignalOK(int i, int j, Direction d, int time)
        {
            if (signal[i, j] == 0) return true;
            return (time / signal[i, j]) % 2 == (int)d % 2;
        }

        private static bool IsInArea(int i, int j)
        {
            return 0 <= i && i < visited.GetLength(0) && 0 <= j && j < visited.GetLength(1);
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




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0223
{
    class Program
    {
        struct State
        {
            public int Ti { get; set; }
            public int Tj { get; set; }
            public int Ki { get; set; }
            public int Kj { get; set; }
            public int MoveTimes { get; set; }
            public State(int ti, int tj, int ki, int kj, int moveTimes)
            {
                Ti = ti;
                Tj = tj;
                Ki = ki;
                Kj = kj;
                MoveTimes = moveTimes;
            }
            public bool IsSamePosition() { return Ti == Ki && Tj == Kj; }
        }

        static public readonly int[] di = new int[] { 0, -1, 0, 1 };
        static public readonly int[] dj = new int[] { 1, 0, -1, 0 };
        static public bool[,] map;
        static public Tuple<int, int> ts;
        static public Tuple<int, int> ks;

        static void Main(string[] args)
        {
            while (true)
            {
                int[] vs = RArInt();
                if (vs.Sum() == 0) break;

                Init(vs);
                Console.WriteLine(CalcMeetHours());
            }
        }

        private static void Init(int[] vs)
        {
            map = new bool[vs[1] + 2, vs[0] + 2];

            vs = RArInt();
            ts = new Tuple<int, int>(vs[1], vs[0]);

            vs = RArInt();
            ks = new Tuple<int, int>(vs[1], vs[0]);

            for (int i = 1; i < map.GetLength(0) - 1; i++)
            {
                vs = RArInt();
                for (int j = 1; j < map.GetLength(1) - 1; j++)
                {
                    map[i, j] = vs[j - 1] == 0 ? true : false;
                }
            }
        }

        private static string CalcMeetHours()
        {
            bool[,,,] closed = new bool[map.GetLength(0), map.GetLength(1), map.GetLength(0), map.GetLength(1)];

            Queue<State> states = new Queue<State>();
            states.Enqueue(new State(ts.Item1, ts.Item2, ks.Item1, ks.Item2, 0));
            closed[ts.Item1, ts.Item2, ks.Item1, ks.Item2] = true;

            while (states.Count > 0)
            {
                State state = states.Dequeue();
                
                if (state.IsSamePosition()) return state.MoveTimes.ToString();
                if (state.MoveTimes > 100) return "NA";

                for (int i = 0; i < di.Length; i++)
                {
                    int nextTi = state.Ti + di[i];
                    int nextTj = state.Tj + dj[i];
                    int nextKi = state.Ki + di[(i + 2) % 4];
                    int nextKj = state.Kj + dj[(i + 2) % 4];

                    if (!map[nextTi, nextTj])
                    {
                        nextTi = state.Ti;
                        nextTj = state.Tj;
                    }
                    if (!map[nextKi, nextKj])
                    {
                        nextKi = state.Ki;
                        nextKj = state.Kj;
                    }

                    if (!closed[nextTi, nextTj, nextKi, nextKj])
                    {
                        states.Enqueue(new State(nextTi, nextTj, nextKi, nextKj, state.MoveTimes + 1));
                        closed[nextTi, nextTj, nextKi, nextKj] = true;
                    }
                }
            }
            return "NA";
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0230
{
    class Program
    {
        enum Wall { Normal, Ladder, Slip }

        class State
        {
            public int Building { get; set; }
            public int Floor { get; set; }
            public int MoveTimes { get; set; }
            public State(int building, int floor, int moveTimes)
            {
                Building = building;
                Floor = floor;
                MoveTimes = moveTimes;
            }
        }

        public static int[][] building;

        static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;
                Init(n);
                Console.WriteLine(CalcMoveTimes());
            }
        }

        private static void Init(int n)
        {
            building = new int[2][];
            for (int i = 0; i < building.Length; i++) building[i] = RArInt();
        }

        private static string CalcMoveTimes()
        {
            bool[][] closed = new bool[building.Length][];
            Queue<State> q = new Queue<State>();

            for (int i = 0; i < building.Length; i++)
            {
                closed[i] = new bool[building[i].Length];

                int s = 0;
                if (building[i][0] == (int)Wall.Ladder) s = GetDest(i, 0, (int)Wall.Ladder);       
                q.Enqueue(new State(i, s, 0));
                closed[i][s] = true;
            }

            while (q.Count() > 0)
            {
                State state = q.Dequeue();
                if (state.Floor == building[0].Length - 1) return state.MoveTimes.ToString();

                for (int i = 0; i < 3; i++)
                {
                    if (state.Floor + i > building[0].Length - 1) continue;

                    int nextBuligind = state.Building ^ 1;
                    int nextFloor = state.Floor + i;

                    if (building[nextBuligind][nextFloor] != (int)Wall.Normal)
                    {
                        nextFloor = GetDest(nextBuligind, nextFloor, building[nextBuligind][nextFloor]);
                    }

                    if (!closed[nextBuligind][nextFloor])
                    {
                        q.Enqueue(new State(nextBuligind, nextFloor, state.MoveTimes + 1));
                        closed[nextBuligind][nextFloor] = true;
                    }
                }
            }
            return "NA";
        }

        private static int GetDest(int buildNum, int x, int wall)
        {
            if (wall == (int)Wall.Ladder)
            {
                for (int i = x + 1; i < building[buildNum].Length; i++)
                {
                    if (building[buildNum][i] != (int)Wall.Ladder) return i - 1;
                }
                return building[buildNum].Length - 1;
            }
            else
            {
                for (int i = x - 1; i >= 0; i--)
                {
                    if (building[buildNum][i] != (int)Wall.Slip) return i;
                }
                return 0;
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

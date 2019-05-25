using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0245
{
    class Program
    {
        const int BLANK_NUM = -1;
        static readonly int[] di = new int[] { 0, -1, 0, 1 };
        static readonly int[] dj = new int[] { -1, 0, 1, 0 };

        class State
        {
            public int I { get; set; }
            public int J { get; set; }
            public int Time { get; set; }
            public int Amount { get; set; }
            public int GotItem { get; set; }

            public State(int i, int j, int time, int amount, int gotItem)
            {
                I = i;
                J = j;
                Time = time;
                Amount = amount;
                GotItem = gotItem;
            }
        }

        class Item
        {
            public int Price { get; set; }
            public int Start { get; set; }
            public int End { get; set; }

            public Item(int price, int start, int end)
            {
                Price = price;
                Start = start;
                End = end;
            }
        }

        static int[,] map;
        static Dictionary<int, Item> Items;
        static int sI, sJ;

        static void Main(string[] args)
        {
            while (true)
            {
                int[] xy = RArInt();
                if (xy.Sum() == 0) break;
                Init(xy);
                Console.WriteLine(CalcMaxAmount());
            }
        }

        private static void Init(int[] xy)
        {
            map = new int[xy[1], xy[0]];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                string[] ms = RArSt();
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (ms[j] == "P")
                    {
                        map[i, j] = BLANK_NUM;
                        sI = i; sJ = j;
                    }
                    else if (ms[j] == ".") map[i, j] = BLANK_NUM;
                    else map[i, j] = int.Parse(ms[j]);
                }
            }

            Items = new Dictionary<int, Item>();
            int n = RInt();
            for (int i = 0; i < n; i++)
            {
                int[] vs = RArInt();
                Items.Add(vs[0], new Item(vs[1], vs[2], vs[3]));
            }
        }

        private static int CalcMaxAmount()
        {
            int res = 0;
            int maxE = Items.Max(x => x.Value.End);
            bool[,,,] visited = new bool[map.GetLength(0), map.GetLength(1), (int)Math.Pow(2, Items.Count()), maxE + 1];

            Queue<State> q = new Queue<State>();
            q.Enqueue(new State(sI, sJ, 0, 0, 0));

            while (q.Count > 0)
            {
                State cur = q.Dequeue();
                res = Math.Max(res, cur.Amount);

                if (cur.GotItem == (int)Math.Pow(2, Items.Count()) - 1)
                {
                    break;
                }

                if (cur.Time >= maxE) continue;
                if (visited[cur.I, cur.J, cur.GotItem, cur.Time]) continue;
                visited[cur.I, cur.J, cur.GotItem, cur.Time] = true;

                int nAmount = cur.Amount;
                int nItems = cur.GotItem;

                for (int i = 0; i < di.Length; i++)
                {
                    int nI = cur.I + di[i];
                    int nJ = cur.J + dj[i];
                    if (IsInArea(nI, nJ) && map[nI, nJ] != BLANK_NUM && ((nItems >> map[nI, nJ]) & 1) == 0)
                    {
                        if (Items[map[nI, nJ]].Start <= cur.Time && cur.Time < Items[map[nI, nJ]].End)
                        {
                            nAmount += Items[map[nI, nJ]].Price;
                            nItems |= 1 << map[nI, nJ];
                        }
                    }
                }

                for (int i = 0; i < di.Length; i++)
                {
                    int nI = cur.I + di[i];
                    int nJ = cur.J + dj[i];
                    if (IsInArea(nI, nJ) && map[nI, nJ] == BLANK_NUM)
                    {
                        q.Enqueue(new State(nI, nJ, cur.Time + 1, nAmount, nItems));
                    }
                }

            }

            return res;
        }

        private static bool IsInArea(int i, int j)
        {
            return 0 <= i && i < map.GetLength(0) && 0 <= j && j < map.GetLength(1);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0172
{
    public class Program
    {

        public enum Result { GoHome, CantOff, Helpme }
        public enum Action { TurnOn, TurnOff, Move }

        public static Room[] rooms;
        public class Room
        {
            public List<int> AdjRoom { get; set; }
            public List<int> Switch { get; set; }
            public Room()
            {
                AdjRoom = new List<int>();
                Switch = new List<int>();
            }
        }

        public static Queue<State> states;
        public class State
        {
            public int CurRoomID { get; set; }
            public int BitOnOff { get; set; }
            public int Step { get; set; }
            public List<Tuple<Action, int>> Actions { get; set; }

            public State(int[] startOnOff)
            {
                CurRoomID = 0;
                for (int i = 0 ; i < startOnOff.Length ; i++) BitOnOff |= ((startOnOff[i] == 1 ? 1 : 0) << i);
                Step = 0;
                Actions = new List<Tuple<Action, int>>();
            }
            public State(int curRoomID, int startOnOff, int step, List<Tuple<Action, int>> actions)
            {
                CurRoomID = curRoomID;
                BitOnOff = startOnOff;
                Step = step;
                Actions = actions;
            }
        }

        public static bool[,] visited;

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] nm = RIntAr();
                if (nm.Sum() == 0) break;

                Init(nm);
                Tuple<Result, State> res = Solve();
                Print(res);
            }
        }

        private static void Print(Tuple<Result, State> res)
        {
            switch (res.Item1)
            {
                case Result.GoHome:
                    Console.WriteLine("You can go home in {0} steps.", res.Item2.Step);
                    for (int i = 0 ; i < res.Item2.Actions.Count() ; i++)
                    {
                        switch (res.Item2.Actions[i].Item1)
                        {
                            case Action.TurnOn:
                                Console.WriteLine("Switch on room {0}.", res.Item2.Actions[i].Item2 + 1);
                                break;
                            case Action.TurnOff:
                                Console.WriteLine("Switch off room {0}.", res.Item2.Actions[i].Item2 + 1);
                                break;
                            case Action.Move:
                                Console.WriteLine("Move to room {0}.", res.Item2.Actions[i].Item2 + 1);
                                break;
                        }
                    }
                    break;
                case Result.CantOff:
                    Console.WriteLine("You can not switch off all lights.");
                    break;
                case Result.Helpme:
                    Console.WriteLine("Help me!");
                    break;
            }
        }

        private static Tuple<Result, State> Solve()
        {
            Tuple<Result, State> res = new Tuple<Result, State>(Result.Helpme, null); ;

            while (states.Count() > 0)
            {

                State cur = states.Dequeue();
                if (visited[cur.CurRoomID, cur.BitOnOff]) continue;

                visited[cur.CurRoomID, cur.BitOnOff] = true;

                if (cur.CurRoomID == rooms.Count() - 1)
                {
                    if (cur.BitOnOff == (1 << rooms.Count() - 1))
                    {
                        res = new Tuple<Result, State>(Result.GoHome, cur);
                        break;
                    }
                    else
                    {
                        res = new Tuple<Result, State>(Result.CantOff, null);
                    }
                }

                for (int i = 0 ; i < rooms[cur.CurRoomID].Switch.Count() ; i++)
                {
                    if (rooms[cur.CurRoomID].Switch[i] != cur.CurRoomID)
                    {
                        List<Tuple<Action, int>> nextAction = cur.Actions.Select(x => x).ToList();
                        if (((cur.BitOnOff >> rooms[cur.CurRoomID].Switch[i]) & 1) == 1) //switch off
                        {
                            nextAction.Add(new Tuple<Action, int>(Action.TurnOff, rooms[cur.CurRoomID].Switch[i]));
                        }
                        else  //switch on
                        {
                            nextAction.Add(new Tuple<Action, int>(Action.TurnOn, rooms[cur.CurRoomID].Switch[i]));
                        }
                        states.Enqueue(new State(cur.CurRoomID, (cur.BitOnOff ^ (1 << rooms[cur.CurRoomID].Switch[i])), cur.Step + 1, nextAction));
                    }
                }

                for (int i = 0 ; i < rooms[cur.CurRoomID].AdjRoom.Count() ; i++) //move
                {
                    if ((cur.BitOnOff & (1 << rooms[cur.CurRoomID].AdjRoom[i])) > 0)
                    {
                        List<Tuple<Action, int>> nextAction = cur.Actions.Select(x => x).ToList();
                        nextAction.Add((new Tuple<Action, int>(Action.Move, rooms[cur.CurRoomID].AdjRoom[i])));
                        states.Enqueue(new State(rooms[cur.CurRoomID].AdjRoom[i], cur.BitOnOff, cur.Step + 1, nextAction));
                    }
                }

            }

            return res;

        }

        private static void Init(int[] nm)
        {
            int n = nm[0];
            int m = nm[1];

            rooms = new Room[n];
            for (int i = 0 ; i < n ; i++) rooms[i] = new Room();
            for (int i = 0 ; i < m ; i++)
            {
                string[] items = RStAr();
                rooms[int.Parse(items[0]) - 1].AdjRoom.Add(int.Parse(items[1]) - 1);
                rooms[int.Parse(items[1]) - 1].AdjRoom.Add(int.Parse(items[0]) - 1);
            }

            states = new Queue<State>();
            states.Enqueue(new State(RIntAr2()));

            for (int i = 0 ; i < n ; i++)
            {
                string line = RSt();
                string[] switches = line.Trim().Split(' ');
                foreach (var item in switches.Skip(1).Select(x => x))
                {
                    try
                    {
                        // int intItem;
                        //if(int.TryParse(item, out intItem)) rooms[i].Switch.Add(intItem - 1);
                        rooms[i].Switch.Add(int.Parse(item) - 1);

                    }
                    catch (FormatException ex)
                    {
                        byte[] byteItem = Encoding.ASCII.GetBytes(line);
                        throw new FormatException(ex.Message + "「" + WAr(byteItem) + "」");
                    }

                }
                rooms[i].Switch.Sort();
            }
            visited = new bool[n, (1 << n)];

        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static int[] RIntAr1(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static int[] RIntAr2(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static int[] RIntAr3(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}

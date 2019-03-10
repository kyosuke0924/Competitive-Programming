using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0147
{
    public class Program

    {
        static Client[] seat = new Client[17];
        static Queue<Client> clients = new Queue<Client>(100);
        static Queue<Client> waiting = new Queue<Client>(100);
        static Dictionary<int, int> position = new Dictionary<int, int>(2) { { 2, 0 }, { 5, 0 } };

        class Client
        {
            public int ID { get; }
            public int Count { get; }
            public int MealTimes { get; }
            public int VisitClock { get; }
            public int SeatingClock { get; private set; }
            public int LeaveClock { get; private set; }

            public Client(int i)
            {
                ID = i;
                Count = i % 5 == 1 ? 5 : 2;
                MealTimes = 17 * (i % 2) + 3 * (i % 3) + 19;
                VisitClock = 5 * i;
            }

            public void Seating(int i)
            {
                SeatingClock = i;
                LeaveClock = i + MealTimes;
            }
        }

        public static void Main(string[] args)
        {

            Dictionary<int, int> WaitTime = new Dictionary<int, int>(100);
            for (int i = 0 ; i < 100 ; i++) clients.Enqueue(new Client(i));

            int t = 0;
            CalcSeatPos();

            do
            {
                //visitsProcessing
                if (clients.Count() > 0 && clients.Peek().VisitClock == t) waiting.Enqueue(clients.Dequeue());

                //leaveProcessing
                if (Leave(t)) CalcSeatPos();

                //seatingProcessing
                while (waiting.Count > 0)
                {
                    int pos = position[waiting.Peek().Count];
                    if (pos >= 0)
                    {
                        Client tmp = waiting.Dequeue();
                        tmp.Seating(t);
                        for (int i = 0 ; i < tmp.Count ; i++) seat[pos + i] = tmp;
                        CalcSeatPos();
                        WaitTime.Add(tmp.ID, tmp.SeatingClock - tmp.VisitClock);
                    }
                    else break;
                }

                t++;

            } while (clients.Count > 0 | waiting.Count > 0 | seat.Any(x => x != null));

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;
                Console.WriteLine(WaitTime[int.Parse(line)]);
            }
        }

        private static bool Leave(int t)
        {
            bool res = false;
            for (int i = 0 ; i < seat.Count() ; i++)
            {
                if (seat[i] != null && seat[i].LeaveClock == t)
                {
                    seat[i] = null;
                    res = true;
                }
            }
            return res;
        }


        private static void CalcSeatPos()
        {
            int pos2 = -1;
            int pos5 = -1;
            int continuousVacancy = 0;
            for (int i = 0 ; i < seat.Count() ; i++)
            {
                if (seat[i] == null) continuousVacancy++;
                else continuousVacancy = 0;

                if (pos2 == -1 && continuousVacancy == 2) pos2 = i - 1;
                if (pos5 == -1 && continuousVacancy == 5) pos5 = i - 4;
                if (pos2 >= 0 && pos5 >= 0) break;
            }

            position[2] = pos2;
            position[5] = pos5;
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

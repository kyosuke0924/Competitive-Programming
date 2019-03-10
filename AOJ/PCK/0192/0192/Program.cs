using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0192
{
    public class Program

    {

        static Stack<Car>[] parkingArea;
        static Queue<Car> cars = new Queue<Car>(100);
        static Queue<Car> waiting = new Queue<Car>(100);
        static Queue<Car> leaved = new Queue<Car>(100);

        class Car
        {
            public int ID { get; }
            public int ParkingTimes { get; }
            public int VisitClock { get; }
            public int ParkingClock { get; private set; }
            public int LeaveClock { get; private set; }

            public Car(int i, int parkingTimes)
            {
                ID = i;
                ParkingTimes = parkingTimes;
                VisitClock = 10 * (i - 1);
            }

            public void Parking(int t)
            {
                ParkingClock = t;
                LeaveClock = t + ParkingTimes;
            }
        }


        public static void Main(string[] args)
        {
            while (true)
            {

                int[] mn = RIntAr();
                if (mn.Sum() == 0) break;

                Init();
                for (int i = 1 ; i <= mn[1] ; i++) cars.Enqueue(new Car(i, RInt()));
                parkingArea = new Stack<Car>[mn[0]];
                for (int i = 0 ; i < parkingArea.Length ; i++) parkingArea[i] = new Stack<Car>(2);

                int t = 0;
                do
                {

                    //visitsProcessing
                    if (cars.Count() > 0 && cars.Peek().VisitClock == t) waiting.Enqueue(cars.Dequeue());

                    //leaveProcessing
                    Leave(t);

                    //parkingProcessing
                    Parking(t);

                    t++;

                } while (leaved.Count() < mn[1]);

                Console.WriteLine(WAr(leaved.Select(x => x.ID)));

            }
        }

        private static void Init()
        {
            cars = new Queue<Car>(100);
            waiting = new Queue<Car>(100);
            leaved = new Queue<Car>(100);
        }

        private static void Leave(int t)
        {
            for (int i = 0 ; i < parkingArea.Count() ; i++)
            {
                while (parkingArea[i].Count > 0)
                {
                    if (parkingArea[i].Peek().LeaveClock <= t) leaved.Enqueue(parkingArea[i].Pop());
                    else break;
                }
            }
        }

        private static void Parking(int t)
        {
            while (waiting.Count > 0)
            {
                if (parkingArea.All(x => x.Count() == 2)) break;
                Car cur = waiting.Dequeue();
                cur.Parking(t);
                parkingArea[GetPosition(cur)].Push(cur);
            }
        }

        private static int GetPosition(Car cur)
        {

            int pos = -1;
            int minDiffTime = int.MinValue;

            for (int i = 0 ; i < parkingArea.Length ; i++)
            {
                if (parkingArea[i].Count == 0) return i;

                if (parkingArea[i].Count == 1)
                {
                    int diffTime = parkingArea[i].Peek().LeaveClock - cur.LeaveClock;
                    if (0 <= diffTime)
                    {
                        if (minDiffTime < 0 || diffTime < minDiffTime)
                        {
                            pos = i; minDiffTime = diffTime;
                        }
                    }
                    else
                    {
                        if (diffTime > minDiffTime)
                        {
                            pos = i; minDiffTime = diffTime;
                        }
                    }
                }
            }
            return pos;
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

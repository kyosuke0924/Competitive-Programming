using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0199
{
    public class Program

    {
        public static char[] chairs;
        public static SortedSet<int> UnSeated;
        public static SortedSet<int> Seated;
        public static SortedSet<int> SeatedA;

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] nm = RIntAr();
                if (nm.Sum() == 0) break;

                Init(nm[0]);

                for (int i = 0 ; i < nm[1] ; i++)
                {
                    char country = RSt()[0];
                    switch (country)
                    {
                        case 'A': SeatA(country); break;
                        case 'B': SeatB(country); break;
                        case 'C': SeatC(country); break;
                        case 'D': SeatD(country); break;
                    }
                }
                Console.WriteLine(WAr(chairs, ""));
            }
        }

        private static void SeatA(char country)
        {
            Seat(country, UnSeated.Min());
        }

        private static void SeatB(char country)
        {
            var notNearByA = UnSeated.Except(SeatedA.Select(x => x + 1)).Except(SeatedA.Select(x => x - 1));
            if (notNearByA.Count() > 0) Seat(country, notNearByA.Max());
            else Seat(country, UnSeated.Min());
        }

        private static void SeatC(char country)
        {
            foreach (var item in Seated)
            {
                if (UnSeated.Contains(item + 1))
                {
                    Seat(country, item + 1);
                    return;
                }
                else if (UnSeated.Contains(item - 1))
                {
                    Seat(country, item - 1);
                    return;
                }
            }

            if (chairs.Count() % 2 == 0) Seat('C', (chairs.Count() / 2));
            else Seat(country, (chairs.Count() - 1) / 2);
        }

        private static void SeatD(char country)
        {
            int[] dist = new int[chairs.Count()];
            for (int i = 0 ; i < dist.Count() ; i++) dist[i] = chairs.Count();

            foreach (var item in Seated)
            {
                for (int i = item ; i < dist.Count() ; i++) dist[i] = i - item;
                for (int i = item - 1 ; i >= 0 ; i--)
                {
                    if (item - i < dist[i]) dist[i] = item - i;
                    else break;
                }
            }
            Seat(country, dist.Select((x, i) => new { num = x, idx = i }).OrderByDescending(x => x.num).ThenBy(x => x.idx).First().idx);
        }

        private static void Init(int n)
        {
            chairs = new char[n];
            for (int i = 0 ; i < chairs.Length ; i++) chairs[i] = '#';

            UnSeated = new SortedSet<int>();
            for (int i = 0 ; i < chairs.Length ; i++) UnSeated.Add(i);

            Seated = new SortedSet<int>();
            SeatedA = new SortedSet<int>();
        }

        private static void Seat(char country, int i)
        {
            chairs[i] = country;
            UnSeated.Remove(i);
            Seated.Add(i);
            if (country == 'A') SeatedA.Add(i);
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

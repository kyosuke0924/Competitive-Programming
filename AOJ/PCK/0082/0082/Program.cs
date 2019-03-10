using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0082
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] Rides = new int[] { 4, 1, 4, 1, 2, 1, 2, 1 };

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int[] items = Array.ConvertAll(line.Trim().Split(' '), e => int.Parse(e));

                int maxArr = -1;
                int maxCapa = -1;
                for (int i = 0 ; i < Rides.Length ; i++)
                {
                    int[] curRides = Rides.Select((x, index) => Rides[(index + i) % Rides.Length]).ToArray();
                    int tmpCapa = items.Select((x, index) => x < curRides[index] ? x : curRides[index]).Sum();

                    int Arr = int.Parse(string.Join("", curRides.Select(x => x.ToString())));
                    if (tmpCapa > maxCapa || tmpCapa == maxCapa && Arr < maxArr)
                    {
                        maxArr = Arr;
                        maxCapa = tmpCapa;
                    }
                }
                Console.WriteLine(string.Join(" ", maxArr.ToString().Select(x => x).ToArray()));
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

}

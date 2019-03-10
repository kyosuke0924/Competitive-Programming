using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0146
{
    public class Program

    {
        public static WareHouse[] wareHouses;
        public struct WareHouse
        {
            public int ID { get; set; }
            public int Distance { get; set; }
            public int Value { get; set; }
            public WareHouse(int[] v)
            {
                ID = v[0];
                Distance = v[1];
                Value = v[2] * 20;
            }
        }

        public static void Main(string[] args)
        {
            int n = RInt();
            wareHouses = new WareHouse[n];
            for (int i = 0 ; i < n ; i++) { wareHouses[i] = new WareHouse(RIntAr()); }

            double[,] dp = new double[(1 << n), n];
            int[,] path = new int[(1 << n), n];
            for (int i = 0 ; i < dp.GetLength(0) ; i++)
            {
                for (int j = 0 ; j < dp.GetLength(1) ; j++)
                {
                    dp[i, j] = int.MaxValue;
                }
            }

            for (int i = 0 ; i < n ; i++)
            {
                dp[1 << i, i] = getTime(0, -1, i);
                path[1 << i, i] = -1;
            }

            for (int s = 0 ; s < dp.GetLength(0) ; s++) //訪問済の集合
            {
                for (int i = 0 ; i < n ; i++)//現在の地点
                {
                    if ((s & 1 << i) == 0) continue;
                    for (int j = 0 ; j < n ; j++) //次に訪れる地点
                    {
                        if ((s & 1 << j) > 0) continue;

                        if(dp[s | 1 << j, j] > dp[s, i] + getTime(s, i, j))
                        {
                            dp[s | 1 << j, j] = dp[s, i] + getTime(s, i, j);
                            path[s | 1 << j, j] = i;
                        }                    
                    }
                }
            }

            //RouteRecovery
            List<int> shortest = new List<int>(n);
            double time = double.MaxValue;
            int set = (1 << n) - 1;
            int idx = -1;
            for (int i = 0 ; i < n ; i++)
            {
                if(dp[set, i] < time)
                {
                    time = dp[set, i]; idx = i;
                }
            }
            while (idx >= 0)
            {
                shortest.Add(idx);
                int nextIdx = path[set, idx];
                set ^= 1 << idx;
                idx = nextIdx;
            }

            shortest.Reverse();
            Console.WriteLine(WAr(shortest.Select(x => wareHouses[x].ID)));
        }

        private static double getTime(int s, int i, int j)
        {
            double sumValue = wareHouses.Where((x, idx) => (s & 1 << idx) > 0).Sum(x => x.Value);
            double speed = 2000 / (70 + sumValue);
            return Math.Abs((i >= 0 ? wareHouses[i].Distance : 0) - wareHouses[j].Distance) / speed;
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

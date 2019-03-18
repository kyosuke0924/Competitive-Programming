using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0213
{
    public class Program

    {
        public class Customer
        {
            public int ID { get; set; }
            public int Area { get; set; }
            public Point DefaultP { get; set; }

            public Customer(int[] vs)
            {
                ID = vs[0];
                Area = vs[1];
            }
        }

        public class Point
        {
            public int I { get; set; }
            public int J { get; set; }
            public Point(int i, int j) { this.I = i; J = j; }
        }

        private static int[,] map;
        private static List<Customer> customers;
        private static int[,] ansMap;
        private static int ansCnt;

        public static void Main(string[] args)
        {
            while (true)
            {
                int[] xyn = RIntAr();
                if (xyn.Sum() == 0) break;
                Init(xyn);
                SetLot(0);
                Print();
            }
        }

        private static void Init(int[] xyn)
        {
            ansCnt = 0;
            ansMap = new int[xyn[1], xyn[0]];
            map = new int[xyn[1], xyn[0]];
            customers = new List<Customer>(xyn[2]);
            for (int i = 0; i < xyn[2]; i++)
            {
                customers.Add(new Customer(RIntAr()));
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                int[] vs = RIntAr();
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = vs[j];
                    if (vs[j] > 0)
                    {
                        Customer ctm = customers.Where(x => x.ID == vs[j]).First();
                        ctm.DefaultP = new Point(i, j);
                    }
                }
            }
        }

        private static bool SetLot(int k)
        {
            if (k == customers.Count())
            {
                ansCnt++;
                if (ansCnt == 1)
                {
                    // １つ目の答えでは、答えを保持して処理継続
                    Array.Copy(map, ansMap, map.Length);
                    return false;
                }
                else
                {
                    // 答えが複数あれば打ち切り
                    return true;
                }
            }
            else
            {
                foreach (int width in GetDivisor(customers[k].Area).OrderBy(x => x))
                {
                    int height = customers[k].Area / width;
                    foreach (Point p in GetCandidateP(customers[k], height, width))
                    {
                        SetMap(customers[k], p, height, width);
                        if (SetLot(k + 1)) return true;
                        UnsetMap(customers[k], p, height, width);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 整数の約数を列挙する(未ソート)
        /// </summary>
        /// <param name="n">整数</param>
        /// <returns>約数の列挙子</returns>
        public static IEnumerable<int> GetDivisor(int n)
        {
            int boundary = (int)Math.Floor(Math.Sqrt(n));
            for (int i = 1; i <= boundary; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    if (i != n / i) yield return n / i;
                }
            }
        }

        private static IEnumerable<Point> GetCandidateP(Customer cmt, int height, int width)
        {
            if (map.GetLength(0) < height || map.GetLength(1) < width)
            {
                yield break;
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int si = cmt.DefaultP.I - i;
                    int sj = cmt.DefaultP.J - j;
                    if (CanSet(cmt, si, sj, height, width)) yield return new Point(si, sj);
                }
            }
        }

        private static bool CanSet(Customer cmt, int si, int sj, int height, int width)
        {
            if (!IsInArea(si, sj) || !IsInArea(si + height - 1, sj + width - 1)) return false;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[si + i, sj + j] > 0 && map[si + i, sj + j] != cmt.ID) return false;
                }
            }
            return true;
        }

        private static bool IsInArea(int i, int j)
        {
            return 0 <= i && i < map.GetLength(0) && 0 <= j && j < map.GetLength(1);
        }

        private static void SetMap(Customer ctm, Point p, int height, int width, bool flg = true)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (p.I + i == ctm.DefaultP.I && p.J + j == ctm.DefaultP.J) continue;
                    map[p.I + i, p.J + j] = flg ? ctm.ID : 0;
                }
            }
        }

        private static void UnsetMap(Customer ctm, Point p, int height, int width)
        {
            SetMap(ctm, p, height, width, false);
        }

        private static void Print()
        {
            if (ansCnt != 1)
            {
                Console.WriteLine("NA");
            }
            else
            {
                for (int i = 0; i < ansMap.GetLength(0); i++)
                {
                    for (int j = 0; j < ansMap.GetLength(1); j++)
                    {
                        if (j > 0) Console.Write(' ');
                        Console.Write(ansMap[i, j]);

                    }
                    Console.Write(Environment.NewLine);
                }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace _0068
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                List<Vector> ps = new List<Vector>(n);

                for (int i = 0 ; i < n ; i++)
                {
                    double[] items = RDoubleAr(',');
                    ps.Add(new Vector(items[0], items[1]));
                }

                var convex = getConvex(ps);
                Console.WriteLine(n - convex.Count());
            }
        }

        /// <summary>
        /// 凸包となる点を取得する（グラハムスキャン）
        /// </summary>
        /// <param name="ps">点集合（原点からのベクトル集合）</param>
        /// <returns>凸包となる点集合</returns>
        public static Vector[] getConvex(List<Vector> ps)
        {
            int n = ps.Count;
            ps = ps.OrderBy(x => x.X).ThenBy(x => x.Y).ToList();

            int k = 0;
            Vector[] convex = new Vector[n * 2];

            for (int i = 0 ; i < n ; i++)
            {
                while (k > 1 && Vector.CrossProduct(convex[k - 1] - convex[k - 2], ps[i] - convex[k - 1]) <= 0) k--;
                convex[k++] = ps[i];
            }

            for (int i = n - 2, t = k ; i >= 0 ; i--)
            {
                while (t < k && Vector.CrossProduct(convex[k - 1] - convex[k - 2], ps[i] - convex[k - 1]) <= 0) k--;
                convex[k++] = ps[i];
            }

            Array.Resize(ref convex, k - 1);
            return convex;
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

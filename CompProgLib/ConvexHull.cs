using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
    class ConvexHull
    {
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

    }
}

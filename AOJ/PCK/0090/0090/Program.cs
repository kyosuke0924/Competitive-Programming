using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0090
{
    public class Program

    {
        internal class Seal
        {
            public decimal X { get; set; }
            public decimal Y { get; set; }
            public Seal(decimal v1, decimal v2) { X = v1; Y = v2; }
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                List<Seal> seals = new List<Seal>(n);
                for (int i = 0 ; i < n ; i++)
                {
                    decimal[] items = Array.ConvertAll(Console.ReadLine().Trim().Split(','), e => decimal.Parse(e));
                    seals.Add(new Seal(items[0], items[1]));
                }

                //中心座標が一致する円の数を数え、初期値とする
                int cnt = seals.GroupBy(x => new { x.X, x.Y }).Select(x => x.Count()).Max();
                for (int i = 0 ; i < n - 1 ; i++)
                {
                    for (int j = i + 1 ; j < n ; j++)
                    {
                        //2円の交点がいくつの円に内包されているか
                        if (isOverlapped(seals[i].X, seals[i].Y, seals[j].X, seals[j].Y, 2) && !(seals[i].X == seals[j].X && seals[i].Y == seals[j].Y))
                        {
                            List<Tuple<decimal, decimal>> crossPoint = GetCrossPoint(seals[i].X, seals[i].Y, seals[j].X, seals[j].Y);
                            Tuple<decimal, decimal> crossP1 = new Tuple<decimal, decimal>(crossPoint[0].Item1, crossPoint[0].Item2);
                            Tuple<decimal, decimal> crossP2 = new Tuple<decimal, decimal>(crossPoint[1].Item1, crossPoint[1].Item2);

                            int overlapP1 = 0;
                            int overlapP2 = 0;
                            foreach (var item in seals.Where((x, index) => index != i && index != j))
                            {
                                if (isOverlapped(crossP1.Item1, crossP1.Item2, item.X, item.Y, 1)) overlapP1++;
                                if (isOverlapped(crossP2.Item1, crossP2.Item2, item.X, item.Y, 1)) overlapP2++;
                            }
                            cnt = Math.Max(cnt, Math.Max(overlapP1, overlapP2) + 2);
                        }
                    }
                }
                Console.WriteLine(cnt);
            }
        }

        //内包判定
        private static bool isOverlapped(decimal x1, decimal y1, decimal x2, decimal y2, decimal d)
        {
            decimal dSquare = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
            return Math.Round(dSquare, 6, MidpointRounding.AwayFromZero) > d * d ? false : true;
        }

        //交点を求める
        private static List<Tuple<decimal, decimal>> GetCrossPoint(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            double d = Math.Sqrt((double)((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
            double theta = Math.Atan2((double)(y2 - y1), (double)(x2 - x1));
            double a = Math.Acos(d / 2);

            decimal p1x = x1 + (decimal)Math.Cos(theta + a);
            decimal p2x = x1 + (decimal)Math.Cos(theta - a);

            decimal p1y = y1 + (decimal)Math.Sin(theta + a);
            decimal p2y = y1 + (decimal)Math.Sin(theta - a);

            return new List<Tuple<decimal, decimal>>() { new Tuple<decimal, decimal>(p1x, p1y), new Tuple<decimal, decimal>(p2x, p2y) };
        }

        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }

    }

}

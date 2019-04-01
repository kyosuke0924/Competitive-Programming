using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0214
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int n = int.Parse(Console.ReadLine().Trim());
                if (n == 0) break;

                for (int cnt = 0; cnt < n; cnt++)
                {
                    bool errFlg = false; //AOJジャッジのエラー除け用
                    string[] mSt = RStAr();
                    if (mSt.Length > 8) errFlg = true;
                    int m = int.Parse(mSt[0].Trim());

                    List<double[]> iluminations = new List<double[]>();
                    UnionFind uf = new UnionFind(m);

                    for (int i = 0; i < m; i++)
                    {
                        double[] vs;
                        if (errFlg)
                        {
                            vs = mSt.Skip(1).Select(x => double.Parse(x)).ToArray();
                        }
                        else
                        {
                            string errst = string.Empty;
                            try
                            {
                                errst = Console.ReadLine().Trim();
                                vs = Array.ConvertAll(errst.Split(' '), e => double.Parse(e));
                            }
                            catch (FormatException)
                            {
                                //byte[] data = Encoding.ASCII.GetBytes(errst);
                                //string err = string.Empty;
                                //for (int ee = 0; ee < data.Length; ee++)
                                //{
                                //    err += Convert.ToString(data[ee], 16) + "-";
                                //}
                                //throw new Exception(err);
                                vs = Array.ConvertAll(errst.Replace("  ", " ").Split(' '), e => double.Parse(e));
                            }

                        }
                        errFlg = false;

                        for (int j = 0; j < iluminations.Count; j++)
                        {
                            if (IsCrossed(iluminations[j], vs)) uf.Unite(i, j);
                        }
                        iluminations.Add(vs);
                    }
                    Console.WriteLine(uf.Parents.Distinct().Count());
                }
            }
        }

        private static bool IsCrossed(double[] quadA, double[] quadB)
        {
            return IsEnclosedVertex(quadA, quadB) || IsEdgeCrossed(quadA, quadB);
        }

        private static bool IsEnclosedVertex(double[] quadA, double[] quadB)
        {
            for (int i = 0; i < quadA.Length; i += 2)
            {
                if (IsQuadrangleIntersectedPoint(quadB, quadA[i], quadA[i + 1])) return true;
            }

            for (int i = 0; i < quadB.Length; i += 2)
            {
                if (IsQuadrangleIntersectedPoint(quadA, quadB[i], quadB[i + 1])) return true;
            }

            return false;
        }

        private static bool IsEdgeCrossed(double[] quadA, double[] quadB)
        {
            for (int i = 0; i < quadA.Length; i += 2)
            {
                for (int j = 0; j < quadB.Length; j += 2)
                {
                    if (IsLineSegmentCrossed
                        (quadA[ i      % quadA.Length], quadA[(i + 1) % quadA.Length],
                         quadA[(i + 2) % quadA.Length], quadA[(i + 3) % quadA.Length],
                         quadB [j      % quadB.Length], quadB[(j + 1) % quadB.Length],
                         quadB[(j + 2) % quadB.Length], quadB[(j + 3) % quadB.Length]
                        )
                    ) return true;
                }
            }
            return false;
        }

        public static bool IsQuadrangleIntersectedPoint(double[] vs, double px, double py)
        {
            return IsQuadrangleIntersectedPoint(vs[0], vs[1], vs[2], vs[3], vs[4], vs[5], vs[6], vs[7], px, py);
        }

        /// <summary>
        /// 四角形ABCDと点Pの内包判定
        /// ※四角形ABCDは凸であることが前提
        /// </summary>
        /// <param name="ax">点Aのx座標</param>
        /// <param name="ay">点Aのy座標</param>
        /// <param name="bx">点Bのx座標/param>
        /// <param name="by">点Bのy座標</param>
        /// <param name="cx">点Cのx座標</param>
        /// <param name="cy">点Cのy座標</param>
        /// <param name="dx">点Dのx座標</param>
        /// <param name="dy">点Dのy座標</param>
        /// <param name="px">点Pのx座標</param>
        /// <param name="py">点Pのy座標</param>
        /// <returns></returns>
        public static bool IsQuadrangleIntersectedPoint(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy, double px, double py)
        {
            Vector a = new Vector(ax, ay);
            Vector b = new Vector(bx, by);
            Vector c = new Vector(cx, cy);
            Vector d = new Vector(dx, dy);
            Vector p = new Vector(px, py);

            double c1 = Vector.CrossProduct(b - a, p - b);
            double c2 = Vector.CrossProduct(c - b, p - c);
            double c3 = Vector.CrossProduct(d - c, p - d);
            double c4 = Vector.CrossProduct(a - d, p - a);

            double EPS = 1e-8;
            return (c1 >= 0 && c2 >= 0 && c3 >= 0 && c4 >= 0) || (c1 <= 0 && c2 <= 0 && c3 <= 0 && c4 <= 0);
        }

        /// <summary>
        /// 線分ABと線分CDの交差判定
        /// </summary>
        /// <param name="ax">線分ABの始点x座標</param>
        /// <param name="ay">線分ABの始点y座標</param>
        /// <param name="bx">線分ABの終点x座標</param>
        /// <param name="by">線分ABの終点y座標</param>
        /// <param name="cx">線分CDの始点x座標</param>
        /// <param name="cy">線分CDの始点y座標</param>
        /// <param name="dx">線分CDの終点x座標</param>
        /// <param name="dy">線分CDの終点y座標</param>
        /// <returns></returns>
        public static bool IsLineSegmentCrossed(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy)
        {
            Vector a = new Vector(ax, ay);
            Vector b = new Vector(bx, by);
            Vector c = new Vector(cx, cy);
            Vector d = new Vector(dx, dy);

            if ((Vector.CrossProduct(b - a, c - a) * Vector.CrossProduct(b - a, d - a) < 1e-10) &&
                (Vector.CrossProduct(d - c, a - c) * Vector.CrossProduct(d - c, b - c) < 1e-10))
            {

                Vector cd = d - c;
                double d1 = Math.Abs(Vector.CrossProduct(cd, a - c));
                double d2 = Math.Abs(Vector.CrossProduct(cd, b - c));
                double t = d1 / (d1 + d2);

                return true;
            }
            else
            {
                return false;
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

    public partial struct Vector
    {

        #region Internal Fields	
        internal double _x;
        internal double _y;
        #endregion Internal Fields	

        #region Public Properties	
        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }
        #endregion Public Properties

        #region Constructors
        public Vector(double x, double y) { _x = x; _y = y; }
        public Vector(double[] line) { _x = line[0]; _y = line[1]; }
        #endregion Constructors

        public static double CrossProduct(Vector vector1, Vector vector2) { return vector1._x * vector2._y - vector1._y * vector2._x; }

        #region Public Operators

        public static Vector operator -(Vector vector) { return new Vector(-vector._x, -vector._y); }
        public void Negate() { _x = -_x; _y = -_y; }
        public static Vector operator +(Vector vector1, Vector vector2) { return new Vector(vector1._x + vector2._x, vector1._y + vector2._y); }
        public static Vector Add(Vector vector1, Vector vector2) { return new Vector(vector1._x + vector2._x, vector1._y + vector2._y); }
        public static Vector operator -(Vector vector1, Vector vector2) { return new Vector(vector1._x - vector2._x, vector1._y - vector2._y); }
        public static Vector Subtract(Vector vector1, Vector vector2) { return new Vector(vector1._x - vector2._x, vector1._y - vector2._y); }
        public static Vector operator *(Vector vector, double scalar) { return new Vector(vector._x * scalar, vector._y * scalar); }
        public static Vector Multiply(Vector vector, double scalar) { return new Vector(vector._x * scalar, vector._y * scalar); }
        public static Vector operator *(double scalar, Vector vector) { return new Vector(vector._x * scalar, vector._y * scalar); }
        public static Vector Multiply(double scalar, Vector vector) { return new Vector(vector._x * scalar, vector._y * scalar); }
        public static Vector operator /(Vector vector, double scalar) { return vector * (1.0 / scalar); }
        public static Vector Divide(Vector vector, double scalar) { return vector * (1.0 / scalar); }
        public static double operator *(Vector vector1, Vector vector2) { return vector1._x * vector2._x + vector1._y * vector2._y; }
        public static double Multiply(Vector vector1, Vector vector2) { return vector1._x * vector2._x + vector1._y * vector2._y; }
        public static double Determinant(Vector vector1, Vector vector2) { return vector1._x * vector2._y - vector1._y * vector2._x; }

        #endregion Public Operators
    }

    public class UnionFind
    {
        public int[] Parents { get; private set; }
        private readonly int[] rank;

        public UnionFind(int n)
        {
            Parents = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++) Parents[i] = i;
        }

        public int Find(int x)
        {
            if (Parents[x] == x) return x;
            else return Parents[x] = Find(Parents[x]);
        }

        public void Unite(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y) return;

            if (rank[x] < rank[y])
            {
                Parents[x] = y;
            }
            else
            {
                Parents[y] = x;
                if (rank[x] == rank[y]) rank[x]++;
            }
        }

        public bool IsSameGroup(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }

}

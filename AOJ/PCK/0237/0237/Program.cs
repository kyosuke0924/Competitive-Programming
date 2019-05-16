using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0237
{
    class Program
    {

        public const double EPS = 1e-10;
        public const double EPS2 = 1e-2;

        class Triangle
        {
            public double[] Vs { get; set; } //三角形の頂点
            public double[] Beams { get; set; } //三角形から放たれるビームの各頂点
            public Triangle(double[] vs)
            {
                Vs = vs;
                SetBeam();
            }

            private void SetBeam()
            {
                double ax = Vs[0]; double ay = Vs[1];
                double bx = Vs[2]; double by = Vs[3];
                double cx = Vs[4]; double cy = Vs[5];
                double a = new Vector(bx - cx, by - cy).LengthSquared;
                double b = new Vector(ax - cx, ay - cy).LengthSquared;
                double c = new Vector(ax - bx, ay - by).LengthSquared;

                double topX, topY, b1x, b1y, b2x, b2y;
                if (Math.Abs(a - b) < EPS)
                {
                    topX = cx; topY = cy; b1x = ax; b1y = ay; b2x = bx; b2y = by;
                }
                else if (Math.Abs(b - c) < EPS)
                {
                    topX = ax; topY = ay; b1x = bx; b1y = by; b2x = cx; b2y = cy;
                }
                else
                {
                    topX = bx; topY = by; b1x = cx; b1y = cy; b2x = ax; b2y = ay;
                }

                Vector v = new Vector(topX - ((b1x + b2x) / (double)2), topY - ((b1y + b2y) / (double)2));
                v.Normalize();
                v *= d;
                Beams = new double[] { b1x, b1y, b2x, b2y, b2x + v.X, b2y + v.Y, b1x + v.X, b1y + v.Y };
            }
        }

        static Triangle[] triangles;
        static bool[,] adj;
        static int d;
        static List<List<int>> scc;

        static void Main(string[] args)
        {
            while (true)
            {
                int[] nd = RArInt();
                if (nd.Sum() == 0) break;
                Init(nd);
                SetGraph();
                SCC();
                Console.WriteLine(CalcTouchCount());
            }
        }

        private static void Init(int[] nd)
        {
            d = nd[1];
            adj = new bool[nd[0], nd[0]];
            triangles = new Triangle[nd[0]];
            for (int i = 0; i < nd[0]; i++) triangles[i] = new Triangle(RArDouble());
        }

        private static void SetGraph()
        {
            for (int i = 0; i < triangles.Length; i++)
            {
                for (int j = 0; j < triangles.Length; j++)
                {
                    if (i == j) continue;
                    if (IsPolygonIntersected(triangles[i].Beams, triangles[j].Vs)) adj[i, j] = true;
                }
            }
        }

        private static bool IsPolygonIntersected(double[] rec, double[] tri)
        {
            for (int i = 0; i < tri.Length; i += 2)
            {
                if (IsPolygonIncludePoint(rec, tri[i], tri[i + 1])) return true;
            }
            for (int i = 0; i < rec.Length; i += 2)
            {
                if (IsPolygonIncludePoint(tri, rec[i], rec[i + 1])) return true;
            }
            return false;
        }

        public static bool IsPolygonIncludePoint(double[] pol, double px, double py)
        {
            Vector p = new Vector(px, py);
            Vector[] vecs = new Vector[pol.Length / 2];
            for (int i = 0; i < pol.Length; i += 2) vecs[i / 2] = new Vector(pol[i], pol[i + 1]);

            double[] crossProducts = new double[vecs.Length];
            for (int i = 0; i < vecs.Length; i++)
            {
                Vector next = vecs[(i + 1) % vecs.Length];
                if (Vector.RangeOfPointAndLineSegment(vecs[i].X, vecs[i].Y, next.X, next.Y, px, py) <= EPS2) return true;
                crossProducts[i] = Vector.CrossProduct(next - vecs[i], p - next);
            }
            return crossProducts.All(x => x >= 0) || crossProducts.All(x => x <= 0);
        }

        private static void SCC()
        {
            bool[] visited = new bool[triangles.Length];
            Stack<int> order = new Stack<int>();
            for (int i = 0; i < triangles.Length; i++)
            {
                Dfs(i, order, visited);
            }

            visited = new bool[triangles.Length];
            scc = new List<List<int>>();

            int idx = 0;
            while (order.Count() > 0)
            {
                int v = order.Pop();
                if (!visited[v])
                {
                    scc.Add(new List<int>());
                    RDfs(v, idx, visited);
                    idx++;
                }
            }
        }

        private static void Dfs(int v, Stack<int> order, bool[] visited)
        {
            if (!visited[v])
            {
                visited[v] = true;
                for (int i = 0; i < triangles.Length; i++) if (adj[v, i]) Dfs(i, order, visited);
                order.Push(v);
            }
        }

        private static void RDfs(int v, int idx, bool[] visited)
        {
            if (!visited[v])
            {
                visited[v] = true;
                for (int i = 0; i < triangles.Length; i++) if (adj[i, v]) RDfs(i, idx, visited);
                scc[idx].Add(v);
            }
        }

        private static int CalcTouchCount()
        {
            int res = 0;
            foreach (var item in scc)
            {
                if (!HasInTriangle(item)) res++;
            }
            return res;
        }

        private static bool HasInTriangle(List<int> vs)
        {
            foreach (var item in vs)
            {
                for (int i = 0; i < triangles.Length; i++)
                {
                    if (adj[i, item] && !vs.Any(x=> x == i)) return true;
                }
            }
            return false;
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RArSt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RArInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RArLong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RArDouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

    public partial struct Vector : IFormattable
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

        #region Public Methods	
        public static bool operator ==(Vector vector1, Vector vector2) { return vector1.X == vector2.X && vector1.Y == vector2.Y; }
        public static bool operator !=(Vector vector1, Vector vector2) { return !(vector1 == vector2); }
        public static bool Equals(Vector vector1, Vector vector2) { return vector1.X.Equals(vector2.X) && vector1.Y.Equals(vector2.Y); }
        public override bool Equals(object o)
        {
            if ((null == o) || !(o is Vector)) return false;
            Vector value = (Vector)o;
            return Vector.Equals(this, value);
        }
        public bool Equals(Vector value) { return Vector.Equals(this, value); }
        public override int GetHashCode() { return X.GetHashCode() ^ Y.GetHashCode(); }
        #endregion Public Methods	

        #region Internal Properties	
        public override string ToString() { return ConvertToString(null /* format string */, null /* format provider */); }
        public string ToString(IFormatProvider provider) { return ConvertToString(null /* format string */, provider); }
        string IFormattable.ToString(string format, IFormatProvider provider) { return ConvertToString(format, provider); }
        internal string ConvertToString(string format, IFormatProvider provider)
        {
            char separator = ' ';
            return String.Format(provider, "{1:" + format + "}{0}{2:" + format + "}", separator, _x, _y);
        }
        #endregion Internal Properties	

        #region Public Methods

        public double Length { get { return Math.Sqrt(_x * _x + _y * _y); } }
        public double LengthSquared { get { return _x * _x + _y * _y; } }
        public void Normalize()
        {
            this /= Math.Max(Math.Abs(_x), Math.Abs(_y));
            this /= Length;
        }

        public static double CrossProduct(Vector vector1, Vector vector2) { return vector1._x * vector2._y - vector1._y * vector2._x; }
        public static double AngleBetween(Vector vector1, Vector vector2)
        {
            double sin = vector1._x * vector2._y - vector2._x * vector1._y;
            double cos = vector1._x * vector2._x + vector1._y * vector2._y;
            return Math.Atan2(sin, cos) * (180 / Math.PI);
        }

        public static Vector Rotation(Vector v, double angle) { return Rotation(v, angle, new Vector(0, 0)); }
        public static Vector Rotation(Vector v, double angle, Vector basePoint)
        {
            double rad = angle * Math.PI / 180;
            Vector res = new Vector();
            res.X = (v.X - basePoint.X) * Math.Cos(rad) - (v.Y - basePoint.Y) * Math.Sin(rad) + basePoint.X;
            res.Y = (v.X - basePoint.X) * Math.Sin(rad) + (v.Y - basePoint.Y) * Math.Cos(rad) + basePoint.Y;
            return res;
        }

        /// <summary>
        /// 線分ABと点Pの距離を求める
        /// </summary>
        /// <param name="sx">線分ABの始点x座標</param>
        /// <param name="sy">線分ABの始点y座標</param>
        /// <param name="ex">線分ABの終点x座標</param>
        /// <param name="ey">線分ABの終点y座標</param>
        /// <param name="px">地点Pのx座標</param>
        /// <param name="py">地点Pのy座標</param>
        /// <returns></returns>
        public static double RangeOfPointAndLineSegment(double sx, double sy, double ex, double ey, double px, double py)
        {
            Vector A = new Vector(sx, sy);
            Vector B = new Vector(ex, ey);
            Vector P = new Vector(px, py);
            return (P - CalcClosestPointOnLineSegment(A, B, P)).Length;
        }

        private static Vector CalcClosestPointOnLineSegment(Vector A, Vector B, Vector P)
        {

            Vector a = B - A;
            Vector b = P - A;
            double r = (a * b) / (a * a);

            if (r <= 0) return A;
            else if (r >= 1) return B;
            else return A + r * a;
        }

        #endregion Public Methods

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
}

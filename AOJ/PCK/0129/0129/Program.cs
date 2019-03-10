using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0129
{
    public class Program

    {
        struct Circle
        {
            public double X { get; }
            public double Y { get; }
            public double R { get; }
            public Circle(double x, double y, double r) { X = x; Y = y; R = r; }
        }

        struct Point
        {
            public double X { get; }
            public double Y { get; }
            public Point(double x, double y) { X = x; Y = y; }
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                List<Circle> circles = new List<Circle>(n);
                for (int i = 0 ; i < n ; i++)
                {
                    int[] items = RIntAr();
                    circles.Add(new Circle(items[0], items[1], items[2]));
                }

                int m = RInt();
                for (int i = 0 ; i < m ; i++)
                {
                    int[] items = RIntAr();
                    Point taro = new Point(items[0], items[1]);
                    Point it = new Point(items[2], items[3]);
                    Console.WriteLine(isHidden(taro, it, circles) ? "Safe" : "Danger");
                }
            }

        }

        private static bool isHidden(Point taro, Point it, List<Circle> circles)
        {
            foreach (var item in circles)
            {
                double distanceLineOfSight = Vector.RangeOfPointAndLineSegment(taro.X, taro.Y, it.X, it.Y, item.X, item.Y);
                if (distanceLineOfSight > item.R) continue;
                if (IsInACircle(item, taro) && IsInACircle(item, it)) continue;
                else return true;
            }
            return false;
        }

        private static bool IsInACircle(Circle item, Point p)
        {
            return  Math.Pow(Math.Abs(item.X - p.X),2) + Math.Pow(Math.Abs(item.Y - p.Y), 2) < Math.Pow(item.R, 2);
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

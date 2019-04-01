using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{

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
        /// <param name="px">交点Pのx座標</param>
        /// <param name="py">交点Pのy座標</param>
        /// <returns></returns>
        public static bool IsLineSegmentCrossed(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy, out double px, out double py)
        {
            Vector a = new Vector(ax, ay);
            Vector b = new Vector(bx, by);
            Vector c = new Vector(cx, cy);
            Vector d = new Vector(dx, dy);

            px = 0;
            py = 0;

            if ((CrossProduct(b - a, c - a) * CrossProduct(b - a, d - a) < 1e-10) &&
                (CrossProduct(d - c, a - c) * CrossProduct(d - c, b - c) < 1e-10))
            {

                Vector cd = d - c;
                double d1 = Math.Abs(CrossProduct(cd, a - c));
                double d2 = Math.Abs(CrossProduct(cd, b - c));
                double t = d1 / (d1 + d2);

                px = (a + (b - a) * t).X;
                py = (a + (b - a) * t).Y;

                return true;
            }
            else
            {
                return false;
            }

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
        public static bool IsQuadrangleIntersected(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy,  double px,  double py)
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

            return (c1 > 0 && c2 > 0 && c3 > 0 && c4 > 0) || (c1 < 0 && c2 < 0 && c3 < 0 && c4 < 0);

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

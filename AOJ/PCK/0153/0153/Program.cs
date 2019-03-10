using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0153
{
    public class Program

    {
        const double EPS = 1E-10;
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] aXY = RIntAr(); if (aXY.Sum() == 0) break;
                int[] bXY = RIntAr();
                int[] cXY = RIntAr();
                int[] pXY = RIntAr();
                int r = RInt();

                bool isCenterInTrianle = IsPointInTrianle(pXY, aXY, bXY, cXY);

                if (getDistance(pXY, aXY) <= r * r && getDistance(pXY, bXY) <= r * r && getDistance(pXY, cXY) <= r * r)
                {
                    Console.WriteLine("b");
                }
                else if (isCenterInTrianle == true && getDistance(pXY, aXY, bXY) >= r * r && getDistance(pXY, bXY, cXY) >= r * r && getDistance(pXY, cXY, aXY) >= r * r)
                {
                    Console.WriteLine("a");
                }
                else if (isCenterInTrianle == false && getDistance(pXY, aXY, bXY) > r * r && getDistance(pXY, bXY, cXY) > r * r && getDistance(pXY, cXY, aXY) > r * r)
                {
                    Console.WriteLine("d");
                }
                else
                {
                    Console.WriteLine("c");
                }
            }
        }

        private static bool IsPointInTrianle(int[] pXY, int[] aXY, int[] bXY, int[] cXY)
        {
            Vector a = new Vector(aXY[0], aXY[1]);
            Vector b = new Vector(bXY[0], bXY[1]);
            Vector c = new Vector(cXY[0], cXY[1]);
            Vector p = new Vector(pXY[0], pXY[1]);

            double c1 = Vector.CrossProduct(b - a, p - b);
            double c2 = Vector.CrossProduct(c - b, p - c);
            double c3 = Vector.CrossProduct(a - c, p - a);

            if ((c1 > 0 && c2 > 0 && c3 > 0) || (c1 < 0 && c2 < 0 && c3 < 0)) return true;
            else return false;
        }

        private static int getDistance(int[] pXY, int[] aXY)
        {
            int a = (int)Math.Pow(Math.Abs(pXY[0] - aXY[0]), 2);
            int b = (int)Math.Pow(Math.Abs(pXY[1] - aXY[1]), 2);
            return a + b;
        }

        private static double getDistance(int[] pXY, int[] aXY, int[] bXY)
        {
            return Vector.RangeOfPointAndLineSegment(aXY[0], aXY[1], bXY[0], bXY[1], pXY[0], pXY[1]);
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
            public static int RangeOfPointAndLineSegment(double sx, double sy, double ex, double ey, double px, double py)
            {
                Vector A = new Vector(sx, sy);
                Vector B = new Vector(ex, ey);
                Vector P = new Vector(px, py);
                return (int)(P - CalcClosestPointOnLineSegment(A, B, P)).LengthSquared;
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
}

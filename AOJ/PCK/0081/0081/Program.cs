using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0081
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                double[] items = Array.ConvertAll(line.Trim().Split(','), e => double.Parse(e));

                Vector vP1 = new Vector(items[0], items[1]);
                Vector vP2 = new Vector(items[2], items[3]);
                Vector vQ = new Vector(items[4], items[5]);

                Vector vP1P2 = vP2 - vP1;
                Vector vP1Q = vQ - vP1;

                double ang = Vector.AngleBetween(vP1P2, vP1Q);
                Vector vR = vP1 + Vector.Rotation(vP1Q, -(ang * 2));

                Console.WriteLine("{0} {1}", vR.X.ToString("0.000000"), vR.Y.ToString("0.000000"));

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

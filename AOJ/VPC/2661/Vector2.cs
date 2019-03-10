// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Globalization;
using System.Text;

namespace System.Numerics
{

    public partial struct Vector2 : IEquatable<Vector2>, IFormattable
    {

        public double X;
        public double Y;

        #region Constructors
        public Vector2(double value) : this(value, value) { }
        public Vector2(double x, double y) { X = x; Y = y; }
        public Vector2(int[] line) { X = line[0]; Y = line[1]; }
        #endregion Constructors

        #region Public Static Properties
        public static Vector2 Zero { get { return new Vector2(); } }
        public static Vector2 One { get { return new Vector2(1.0f, 1.0f); } }
        public static Vector2 UnitX { get { return new Vector2(1.0f, 0.0f); } }
        public static Vector2 UnitY { get { return new Vector2(0.0f, 1.0f); } }
        #endregion Public Static Properties

        #region Public Instance Methods
        public void CopyTo(double[] array) { CopyTo(array, 0); }
        public void CopyTo(double[] array, int index)
        {
            if (array == null) throw new NullReferenceException();
            if (index < 0 || index >= array.Length) throw new ArgumentOutOfRangeException();
            if ((array.Length - index) < 2) throw new ArgumentException();
            array[index] = X;
            array[index + 1] = Y;
        }
        public bool Equals(Vector2 other) { return this.X == other.X && this.Y == other.Y; }

        public override int GetHashCode()
        {
            int hash = this.X.GetHashCode();
            hash = HashCodeHelper.CombineHashCodes(hash, this.Y.GetHashCode());
            return hash;
        }
        internal static class HashCodeHelper { internal static int CombineHashCodes(int h1, int h2) { return (((h1 << 5) + h1) ^ h2); } }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2)) return false;
            return Equals((Vector2)obj);
        }

        public override string ToString() { return ToString("G", CultureInfo.CurrentCulture); }
        public string ToString(string format) { return ToString(format, CultureInfo.CurrentCulture); }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            StringBuilder sb = new StringBuilder();
            string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
            sb.Append('<');
            sb.Append(this.X.ToString(format, formatProvider));
            sb.Append(separator);
            sb.Append(' ');
            sb.Append(this.Y.ToString(format, formatProvider));
            sb.Append('>');
            return sb.ToString();
        }

        public double Length()
        {
                double ls = Vector2.Dot(this, this);
                return (double)Math.Sqrt(ls);
        }

        public double LengthSquared()
        {
                return Vector2.Dot(this, this);
        }
        #endregion Public Instance Methods

        #region Public Static Methods

        public static double Dot(Vector2 value1, Vector2 value2) { return value1.X * value2.X + value1.Y * value2.Y; }
        public static Vector2 Min(Vector2 value1, Vector2 value2) { return new Vector2((value1.X < value2.X) ? value1.X : value2.X, (value1.Y < value2.Y) ? value1.Y : value2.Y); }
        public static Vector2 Max(Vector2 value1, Vector2 value2) { return new Vector2((value1.X > value2.X) ? value1.X : value2.X, (value1.Y > value2.Y) ? value1.Y : value2.Y); }
        public static Vector2 Abs(Vector2 value) { return new Vector2(Math.Abs(value.X), Math.Abs(value.Y)); }
        public static Vector2 SquareRoot(Vector2 value) { return new Vector2((double)Math.Sqrt(value.X), (double)Math.Sqrt(value.Y)); }

        public static double Distance(Vector2 value1, Vector2 value2)
        {
                Vector2 difference = value1 - value2;
                double ls = Vector2.Dot(difference, difference);
                return (double)System.Math.Sqrt(ls);
        }

        public static double DistanceSquared(Vector2 value1, Vector2 value2)
        {
                Vector2 difference = value1 - value2;
                return Vector2.Dot(difference, difference);
        }

        public static Vector2 Normalize(Vector2 value)
        {       
                double length = value.Length();
                return value / length; 
        }

        public static Vector2 Reflect(Vector2 vector, Vector2 normal)
        {
                double dot = Vector2.Dot(vector, normal);
                return vector - (2 * dot * normal);
        }

        public static Vector2 Clamp(Vector2 value1, Vector2 min, Vector2 max)
        {

            double x = value1.X;
            x = (x > max.X) ? max.X : x;
            x = (x < min.X) ? min.X : x;

            double y = value1.Y;
            y = (y > max.Y) ? max.Y : y;
            y = (y < min.Y) ? min.Y : y;

            return new Vector2(x, y);
        }

        public static Vector2 Lerp(Vector2 value1, Vector2 value2, double amount)
        {
            return new Vector2(
                value1.X + (value2.X - value1.X) * amount,
                value1.Y + (value2.Y - value1.Y) * amount);
        }
        #endregion Public Static Methods

        #region Public Static Operators
        public static Vector2 operator +(Vector2 left, Vector2 right) { return new Vector2(left.X + right.X, left.Y + right.Y); }
        public static Vector2 operator -(Vector2 left, Vector2 right) { return new Vector2(left.X - right.X, left.Y - right.Y); }
        public static Vector2 operator *(Vector2 left, Vector2 right) { return new Vector2(left.X * right.X, left.Y * right.Y); }
        public static Vector2 operator *(double left, Vector2 right) { return new Vector2(left, left) * right; }
        public static Vector2 operator *(Vector2 left, double right) { return left * new Vector2(right, right); }
        public static Vector2 operator /(Vector2 left, Vector2 right) { return new Vector2(left.X / right.X, left.Y / right.Y); }
        public static Vector2 operator /(Vector2 value1, double value2) { return new Vector2(value1.X * (1.0d / value2), value1.Y * (1.0d / value2)); }
        public static Vector2 operator -(Vector2 value) { return Zero - value; }
        public static bool operator ==(Vector2 left, Vector2 right) { return left.Equals(right); }
        public static bool operator !=(Vector2 left, Vector2 right) { return !(left == right); }
        #endregion Public Static Operators

        #region Public operator methods
        public static Vector2 Add(Vector2 left, Vector2 right) { return left + right; }
        public static Vector2 Subtract(Vector2 left, Vector2 right) { return left - right; }
        public static Vector2 Multiply(Vector2 left, Vector2 right) { return left * right; }
        public static Vector2 Multiply(Vector2 left, double right) { return left * right; }
        public static Vector2 Multiply(double left, Vector2 right) { return left * right; }
        public static Vector2 Divide(Vector2 left, Vector2 right) { return left / right; }
        public static Vector2 Divide(Vector2 left, double divisor) { return left / divisor; }
        public static Vector2 Negate(Vector2 value) { return -value; }
        #endregion Public operator methods
    }
}




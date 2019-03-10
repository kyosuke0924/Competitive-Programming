using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2661
{
    public class Program

    {
        public static void Main(string[] args)
        {


            int n1 = ReadInt();
            List<Vector> Vectors1 = new List<Vector>();

            Vectors1.Add(new Vector(0, 0));
            for (int i = 0 ; i < n1 ; i++) Vectors1.Add(new Vector(ReadDoubleAr()));
            Vectors1.Add(new Vector(1000, 0));

            int n2 = ReadInt();
            List<Vector> Vectors2 = new List<Vector>();
            Vectors2.Add(new Vector(0, 1000));
            for (int i = 0 ; i < n2 ; i++) Vectors2.Add(new Vector(ReadDoubleAr()));
            Vectors2.Add(new Vector(1000, 1000));

            //折れ線1の頂点からみた折れ線2の距離の最短
            double minDist = double.MaxValue;
            for (int i = 0 ; i < Vectors1.Count ; i++)
            {
                for (int j = 0 ; j < Vectors2.Count - 1 ; j++)
                {
                    minDist = Math.Min(minDist, RangeOfVectorAndLineSegment(Vectors2[j], Vectors2[j + 1], Vectors1[i]));
                }
            }

            //折れ線2の頂点からみた折れ線1の距離の最短
            for (int i = 0 ; i < Vectors2.Count ; i++)
            {
                for (int j = 0 ; j < Vectors1.Count - 1 ; j++)
                {
                    minDist = Math.Min(minDist, RangeOfVectorAndLineSegment(Vectors1[j], Vectors1[j + 1], Vectors2[i]));
                }
            }

            Console.WriteLine(minDist);
        }

        private static double RangeOfVectorAndLineSegment(Vector A, Vector B, Vector P)
        {
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

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }

    }

}

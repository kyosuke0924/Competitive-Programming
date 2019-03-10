using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace ALDS1_5_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int d = ReadInt();
            List<Vector> res = new List<Vector>();
            Kock(d, new Vector(0, 0), new Vector(100, 0), res);

            Console.WriteLine("{0} {1}", 0, 0);
            foreach (var item in res) { Console.WriteLine("{0} {1}", item.X, item.Y); }
            Console.WriteLine("{0} {1}", 100, 0);

        }

        public static void Kock(int d, Vector p1, Vector p2, List<Vector> vectors)
        {
            if (d == 0) return;

            Vector s = (p2 - p1) * 1 / 3 + p1;
            Vector t = (p2 - p1) * 2 / 3 + p1;
            Vector u = Vector.Rotation(t, 60, s);

            Kock(d - 1, p1, s, vectors);
            vectors.Add(s);
            Kock(d - 1, s, u, vectors);
            vectors.Add(u);
            Kock(d - 1, u, t, vectors);
            vectors.Add(t);
            Kock(d - 1, t, p2, vectors);

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

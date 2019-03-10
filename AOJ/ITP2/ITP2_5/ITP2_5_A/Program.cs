using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_5_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            List<Node> coordinates = new List<Node>();
            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                coordinates.Add(new Node(line[0], line[1]));
            }
            coordinates = coordinates.OrderBy(x => x.X).ThenBy(x => x.Y).ToList();
            foreach (var item in coordinates)
            {
                Console.WriteLine("{0} {1}", item.X, item.Y);
            }
        }

        internal struct Node
        {
            internal int X { get; private set; }
            internal int Y { get; private set; }
            internal Node(int x, int y) { X = x; Y = y; }
        }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }
        static string WriteAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }

    }

}

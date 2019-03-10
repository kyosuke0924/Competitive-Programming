using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_5_B
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            Node[] coordinates = new Node[n];
            string[] line;
            for (int i = 0 ; i < n ; i++)
            {
                line = Console.ReadLine().Split(' ');
                coordinates[i] = new Node(int.Parse(line[0]), int.Parse(line[1]), line[2], long.Parse(line[3]), line[4]);
            }

            Array.Sort(coordinates);

            var sb = new StringBuilder();
            for (int i = 0 ; i < n ; i++) sb.AppendLine(coordinates[i].Print());
            Console.Write(sb.ToString());
        }

        internal struct Node:IComparable<Node>
        {
            internal int Value { get;  set; }
            internal int Weight { get;  set; }
            internal string Type { get;  set; }
            internal long Time { get;  set; }
            internal string Name { get;  set; }
            internal Node(int value, int weight, string type, long time, string name)
            { Value = value; Weight = weight; Type = type; Time = time; Name = name; }
            internal string Print() { return Value.ToString() + " " + Weight.ToString() + " " + Type + " " + Time.ToString() + " " + Name; }

            public int CompareTo(Node other)
            {
                if (Value.CompareTo(other.Value) != 0) return Value.CompareTo(other.Value);
                if (Weight.CompareTo(other.Weight) != 0) return Weight.CompareTo(other.Weight);
                if (Type.CompareTo(other.Type) != 0) return Type.CompareTo(other.Type);
                if (Time.CompareTo(other.Time) != 0) return Time.CompareTo(other.Time);
                if (String.CompareOrdinal(Name,other.Name) != 0) return String.CompareOrdinal(Name, other.Name);
                return 0;
            }
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

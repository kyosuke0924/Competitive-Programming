using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0133
{
    public class Program

    {
        public const int SIZE_H = 8;
        public const int SIZE_W = 8;

        public static void Main(string[] args)
        {
            string[] line = new string[SIZE_H];
            for (int i = 0 ; i < SIZE_H ; i++)
            {
                line[i] = RSt();
            }
            Console.WriteLine(90);
            line = Rotate(line);
            foreach (var item in line) Console.WriteLine(item);
            Console.WriteLine(180);
            line = Rotate(line);
            foreach (var item in line) Console.WriteLine(item);
            Console.WriteLine(270);
            line = Rotate(line);
            foreach (var item in line) Console.WriteLine(item);
        }

        public static string[] Rotate(string[] line)
        {
            int newH = line[0].Length;
            int newW = line.Length;
            string[] newline = new string[newH];
            for (int i = 0 ; i < newH ; i++)
            {
                for (int j = 0 ; j < newW ; j++)
                {
                    newline[i] += line[(newW - 1) - j][i];
                }
            }
            return newline;
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

}

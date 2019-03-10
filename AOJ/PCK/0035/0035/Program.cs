using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace _0035
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

                Vector OA = new Vector(items[0], items[1]);
                Vector OB = new Vector(items[2], items[3]);
                Vector OC = new Vector(items[4], items[5]);
                Vector OD = new Vector(items[6], items[7]);

                Vector AB = OB - OA;
                Vector BC = OC - OB;
                Vector CD = OD - OC;
                Vector DA = OA - OD;

                double cProductA = Vector.CrossProduct(DA, AB);
                double cProductB = Vector.CrossProduct(AB, BC);
                double cProductC = Vector.CrossProduct(BC, CD);
                double cProductD = Vector.CrossProduct(CD, DA);

                if (cProductA < 0 && cProductB < 0 && cProductC < 0 && cProductD < 0
                    || cProductA > 0 && cProductB > 0 && cProductC > 0 && cProductD > 0)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
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

}

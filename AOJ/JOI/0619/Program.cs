using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0619
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] science = new int[4];
            int[] socialStudies = new int[2];

            for (int i = 0 ; i < science.Length ; i++)
            {
                science[i] = ReadInt();
            }
            for (int i = 0 ; i < socialStudies.Length ; i++)
            {
                socialStudies[i] = ReadInt();
            }
            Console.WriteLine(science.Sum()-science.Min() + socialStudies.Max());
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

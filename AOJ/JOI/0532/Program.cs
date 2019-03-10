using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0532
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] lineA = ReadIntAr();
            int[] lineB = ReadIntAr();
            int[] lineC = ReadIntAr();
            List<int[]> employee = new List<int[]>() { lineA, lineB, lineC };

            foreach (var item in employee)
            {
                int attendanceTime = item[0] * 3600 + item[1] * 60 + item[2];
                int leavingTime = item[3] * 3600 + item[4] * 60 + item[5];
                int workingTimes = leavingTime - attendanceTime;

                int h = workingTimes / 3600;
                int m = (workingTimes % 3600) / 60;
                int s = (workingTimes % 3600) % 60;

                Console.WriteLine("{0} {1} {2}", h, m, s);
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

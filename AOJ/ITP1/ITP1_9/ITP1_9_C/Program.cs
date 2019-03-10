using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_9_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int turn = ReadInt();
            int taroS = 0;
            int hanakoS = 0;

            for (int i = 0 ; i < turn ; i++)
            {

                string[] line = ReadStAr();
                int res = String.Compare(line[0], line[1]);

                if (res < 0)
                {
                    hanakoS += 3;
                }
                else if (res > 0)
                {
                    taroS += 3;
                }
                else
                {
                    hanakoS++;
                    taroS++;
                }
            }
            Console.WriteLine("{0} {1}",taroS,hanakoS);
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

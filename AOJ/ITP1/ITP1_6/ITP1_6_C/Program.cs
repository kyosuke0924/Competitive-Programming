using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_6_C
{
    public class Program

    {
        public static void Main(string[] args)
        {

            int[,,] house = new int[4, 3, 10];
            int[] line;
            long n = ReadLong();

            for(long i = 0; i < n; i++)
            {
                line = ReadIntAr();
                house[line[0]-1, line[1]-1, line[2]-1] += line[3];
            }

            for (int i = 0; i < house.GetLength(0); i++)
            {
                for (int j = 0; j < house.GetLength(1); j++)
                {
                    for (int k = 0; k < house.GetLength(2); k++)
                    {
                        Console.Write(" ");
                        Console.Write(house[i,j,k].ToString());
                    }
                    Console.Write(Environment.NewLine);
                }
                if(i < house.GetLength(0)-1)Console.WriteLine(new string('#', 20));
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

    }

}

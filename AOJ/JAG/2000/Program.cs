using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2000
{
    public class Program

    {
        public static void Main(string[] args)
        {
            const int FIELD_SIZE = 21;

            while (true)
            {

                int n = ReadInt();
                if (n == 0) break;

                int[,] field = new int[FIELD_SIZE, FIELD_SIZE];
                for (int i = 0 ; i < n ; i++)
                {
                    int[] line = ReadIntAr();
                    field[line[0], line[1]] = 1;
                }

                int obtainedJewels = 0;
                int x = 10;
                int y = 10;
                int m = ReadInt();
                for (int i = 0 ; i < m ; i++)
                {
                    string[] line = ReadStAr();
                    for (int j = 0 ; j < int.Parse(line[1]) ; j++)
                    {
                        switch (line[0])
                        {
                            case "N": y++; break;
                            case "E": x++; break;
                            case "S": y--; break;
                            case "W": x--; break;
                        }
                        if (field[x, y] == 1)
                        {
                            obtainedJewels++;
                            field[x, y] = 0;
                        }
                    }
                }
                Console.WriteLine(obtainedJewels == n ? "Yes" : "No");

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

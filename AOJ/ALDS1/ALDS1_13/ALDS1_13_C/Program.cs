using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib;

namespace ALDS1_13_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            const int VSize = 4;
            const int HSize = 4;
            int[,] board = new int[VSize, HSize];
            NPuzzle np = new NPuzzle(VSize, HSize);

            for (int i = 0 ; i < VSize ; i++)
            {
                int[] tmp = ReadIntAr();
                for (int j = 0 ; j < HSize ; j++)
                {
                    board[i, j] = tmp[j];
                }
            }       
           Console.WriteLine(np.FindShortestRange(board));
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

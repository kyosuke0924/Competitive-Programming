using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_6_B
{
    public class Program

    {
        public static string[] MarksStr = new string[] { "S", "H", "C", "D" };

        public static void Main(string[] args)
        {
            string[] line;
            bool[,] cards = new bool[4,13];
            int n = ReadInt();

            for (int cnt = 0; cnt < n; cnt++)
            {
                line = ReadStAr();
                for (int i = 0; i < MarksStr.Length; i++)
                {
                    if (line[0].Equals(MarksStr[i]))
                    {
                        cards[i, int.Parse(line[1]) - 1] = true;
                        break;
                    }
                }
            } 

            for(int i = 0;i < cards.GetLength(0);i++)
            { 
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    if (!cards[i,j]) Console.WriteLine("{0} {1}", MarksStr[i], j + 1);
                }
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

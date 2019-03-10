using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1147
{
    public class Program

    {
        public static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != "0")
            {
                List<int> scores = new List<int>();
                for (int i = 0 ; i < int.Parse(line) ; i++)
                {
                    scores.Add(ReadInt());
                }
                Console.WriteLine(Math.Floor(scores.OrderBy(x => x).Where((x,i) => i != 0 && i != scores.Count-1).Average()));
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

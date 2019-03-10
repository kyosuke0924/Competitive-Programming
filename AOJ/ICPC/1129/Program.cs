using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1129
{
    public class Program

    {
        public static void Main(string[] args)
        {

            while (true)
            {


                int[] line = ReadIntAr();
                if (line[0] + line[1] == 0) break;

                List<int> cards = new List<int>();
                for (int i = 0 ; i < line[0] ; i++) cards.Add(line[0] - i);
                for (int i = 0 ; i < line[1] ; i++)
                {
                    int[] query = ReadIntAr();
                    List<int> before = cards.Take(query[0] - 1).ToList();
                    List<int> selected = cards.Skip(query[0] - 1).Take(query[1]).ToList();
                    List<int> after = cards.Skip(query[0] - 1 + query[1]).Take(cards.Count - (query[0] - 1) - query[1]).ToList();
                    cards = selected.Concat(before).Concat(after).ToList();
                }
                Console.WriteLine(cards.First());
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

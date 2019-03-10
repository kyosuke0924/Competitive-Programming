using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_1_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] items = ReadIntAr();
            List<int>[] lists = new List<int>[items[0]];

            for (int i = 0 ; i < items[0] ; i++)
            {
                lists[i] = new List<int>();
            }

            for (int i = 0 ; i < items[1] ; i++)
            {
                int[] line = ReadIntAr();

                switch (line[0])
                {
                    case 0:
                        {
                            lists[line[1]].Add(line[2]);
                            break;
                        }
                    case 1:
                        {
                            if (lists[line[1]].Count == 0)
                            {
                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine(String.Join(" ", lists[line[1]].Select(x => x.ToString()).ToArray()));
                            }
                            break;
                        }
                    case 2:
                        {
                            lists[line[1]].Clear();
                            break;
                        }
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

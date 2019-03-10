using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1153
{
    public class Program

    {
        public static void Main(string[] args)
        {

            while (true)
            {
                int[] line = ReadIntAr();
                if (line[0] + line[1] == 0) break;

                int[] tCards = new int[line[0]];
                int[] hCards = new int[line[1]];

                for (int i = 0 ; i < tCards.Length ; i++) tCards[i] = ReadInt();
                for (int i = 0 ; i < hCards.Length ; i++) hCards[i] = ReadInt();

                int tSum = tCards.Sum();
                int hSum = hCards.Sum();
                int changeSum = int.MaxValue;
                string res = "-1";

                for (int i = 0 ; i < tCards.Length ; i++)
                {
                    for (int j = 0 ; j < hCards.Length ; j++)
                    {
                        if (tSum - tCards[i] + hCards[j] == hSum + tCards[i] - hCards[j])
                        {
                            if (changeSum > tCards[i] + hCards[j])
                            {
                                changeSum = tCards[i] + hCards[j];
                                res = tCards[i].ToString() + " " + hCards[j].ToString();
                            }
                        }
                    }
                }

           Console.WriteLine(res);
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

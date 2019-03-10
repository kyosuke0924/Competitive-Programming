using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_9_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            string line = ReadSt();
            char[] lineAr = line.ToArray();
            int n = ReadInt();

            for (int i = 0 ; i < n ; i++)
            {

                string[] com = ReadStAr();

                int s = int.Parse(com[1]);
                int t = int.Parse(com[2]);

                switch (com[0])
                {
                    case "print":
                        Console.WriteLine(String.Join("",lineAr.Select(x => x.ToString()).ToArray()).Substring(s,t-s+1));
                        break;

                    case "reverse":
                        char[] rev = new char[t-s+1];
                        for (int j = s ; j <= t ; j++)
                        {
                            rev[j-s] = lineAr[t-(j-s)];
                        }
                        for (int j = s ; j <= t ; j++)
                        {
                            lineAr[j] = rev[j-s];
                        }
                        break;

                    case "replace":
                        for (int j = s ; j <= t ; j++)
                        {
                            lineAr[j] = com[3][j-s];
                        }
                        break;
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

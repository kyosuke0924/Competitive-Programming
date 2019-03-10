using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1159
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] line = ReadIntAr();
                if (line[0] + line[1] == 0) break;

                int n = line[0];
                int p = line[1];
                int[] hasPebbleCount = new int[n];

                for (int i = 0 ; i < n ; i = (i + 1) % n)
                {
                    if (p>0)
                    {
                        p--;
                        hasPebbleCount[i]++;
                        if(hasPebbleCount[i] == line[1]) { Console.WriteLine(i);break; }
                    }
                    else
                    {
                        p = hasPebbleCount[i];
                        hasPebbleCount[i] = 0;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_8_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            string line;
            Dictionary<char,int> rlt = new Dictionary<char, int>();
            for (char i = 'a' ; i <= 'z' ; i++) rlt.Add(i, 0);

            while ((line = ReadSt()) != null)
            {
                for (int i = 0 ; i < line.Length ; i++)
                {

                    if (char.ToLower(line[i]) >= 'a' && char.ToLower(line[i]) <= 'z')
                    {
                        rlt[char.ToLower(line[i])]++;
                    }
                }
            }

            foreach (var item in rlt)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
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

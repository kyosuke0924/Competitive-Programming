using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1192
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] line = ReadIntAr();
                if (line[0] + line[1] + line[2] == 0) break;

                int beforeTaxRate = line[0];
                int afterTaxRate = line[1];
                int sum = line[2];

                int res = 0;

                for (int i = 1 ; i < sum ; i++)
                {
                    for (int j = 1 ; j < sum ; j++)
                    {
                        if (CalcTaxIncludedPrice(i, beforeTaxRate) + CalcTaxIncludedPrice(j, beforeTaxRate) == sum)
                        {
                            res = Math.Max(res, CalcTaxIncludedPrice(i, afterTaxRate) + CalcTaxIncludedPrice(j, afterTaxRate));
                        }
                        else if (CalcTaxIncludedPrice(i, beforeTaxRate) + CalcTaxIncludedPrice(j, beforeTaxRate) > sum) break;
                    }
                }
                Console.WriteLine(res);
            }
        }

        public static int CalcTaxIncludedPrice(int taxExcludedPrice,int taxRate)
        {
            return taxExcludedPrice * (100 + taxRate) / 100;
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

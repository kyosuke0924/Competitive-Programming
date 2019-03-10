using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0015
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();

            for (int i = 0 ; i < n ; i++)
            {
                string a = ReadSt();
                string b = ReadSt();

                a = string.Join("", a.PadLeft(100, '0').Reverse());
                b = string.Join("", b.PadLeft(100, '0').Reverse());

                string[] resAr = new string[100];
                bool carrying = false;
                for (int j = 0 ; j < resAr.Length ; j++)
                {
                    string tmp = (int.Parse(a[j].ToString()) + int.Parse(b[j].ToString()) + (carrying ? 1 : 0)).ToString();
                    resAr[j] = tmp.Substring(tmp.Length - 1, 1);
                    carrying = (int.Parse(tmp) > 9) ? true : false;
                }

                string res = string.Join("", resAr.Reverse().SkipWhile(x => x == "0").ToArray());
                Console.WriteLine(res.Length > 80 ? "overflow" : res.Count() == 0 ? "0" : res);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2006
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();

            string[] b0 = new string[] { "" };
            string[] b1 = new string[] { ".", ",", "!", "?", " " };
            string[] b2 = new string[] { "a", "b", "c" };
            string[] b3 = new string[] { "d", "e", "f" };
            string[] b4 = new string[] { "g", "h", "i" };
            string[] b5 = new string[] { "j", "k", "l" };
            string[] b6 = new string[] { "m", "n", "o" };
            string[] b7 = new string[] { "p", "q", "r", "s" };
            string[] b8 = new string[] { "t", "u", "v" };
            string[] b9 = new string[] { "w", "x", "y", "z" };
            string[][] buttons = new string[][] { b0, b1, b2, b3, b4, b5, b6, b7, b8, b9 };

            for (int i = 0 ; i < n ; i++)
            {
                string line = ReadSt();
                char num = 'x';
                int pushCnt = 0;
                string res = "";

                for (int j = 0 ; j < line.Length ; j++)
                {
                    if (line[j] == '0' && pushCnt > 0)
                    {
                        res += buttons[int.Parse(num.ToString())][(pushCnt - 1) % buttons[int.Parse(num.ToString())].Length];
                        pushCnt = 0;
                    }
                    else if (line[j] != '0' && line[j] == num)
                    {
                        pushCnt++;
                    }
                    else if (line[j] != '0' && line[j] != num)
                    {
                        num = line[j];
                        pushCnt = 1;
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

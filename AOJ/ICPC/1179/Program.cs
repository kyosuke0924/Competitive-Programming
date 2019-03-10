using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1179
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();

            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                int res = 0;
                for (int j = 999 ; line[0] <= j ; j--)
                {
                    if (j != line[0]) res += (j % 3 == 0) ? 200 : 195;
                    else
                    {
                        for (int k = 10 ; line[1] <= k  ; k--)
                        {
                            if (k != line[1]) res += (j % 3 == 0 || k % 2 == 1) ? 20 : 19;
                            else
                            {
                                res += (j % 3 == 0 || k % 2 == 1) ? 20 - line[2] + 1 : 19 - line[2] + 1;
                            }
                        }

                    }
                }
                Console.WriteLine(res.ToString());
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

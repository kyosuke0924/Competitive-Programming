using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0241
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] operations = new string[,]
            {
                 {"+0" ,"+1" ,"+2" ,"+3"}
                ,{"+1" ,"-0" ,"+3" ,"-2"}
                ,{"+2" ,"-3" ,"-0" ,"+1"}
                ,{"+3" ,"+2" ,"-1" ,"-0"}
            };

            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                for (int k = 0; k < n; k++)
                {

                    int[] vs = RArInt();
                    int[] ar1 = vs.Take(4).ToArray();
                    int[] ar2 = vs.Skip(4).Take(4).ToArray();

                    int[] res = new int[ar1.Length];
                    for (int i = 0; i < ar1.Length; i++)
                    {
                        for (int j = 0; j < ar2.Length; j++)
                        {
                            string operation = operations[i, j];
                            if(operation[0] == '+')
                            {
                                res[int.Parse(operation[1].ToString())] += ar1[i] * ar2[j];
                            }
                            else
                            {
                                res[int.Parse(operation[1].ToString())] -= ar1[i] * ar2[j];
                            }
                        }
                    }
                    Console.WriteLine(WAr(res));
                }
            }
        }
        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RArSt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RArInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RArLong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RArDouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }
}

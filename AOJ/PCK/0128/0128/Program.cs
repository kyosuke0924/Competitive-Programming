using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0128
{
    public class Program

    {
        public static void Main(string[] args)
        {
            char[,] abacus = new char[,]
            {
                 {'*',' ','=',' ','*','*','*','*' }
               , {'*',' ','=','*',' ','*','*','*' }
               , {'*',' ','=','*','*',' ','*','*' }
               , {'*',' ','=','*','*','*',' ','*' }
               , {'*',' ','=','*','*','*','*',' ' }
               , {' ','*','=',' ','*','*','*','*' }
               , {' ','*','=','*',' ','*','*','*' }
               , {' ','*','=','*','*',' ','*','*' }
               , {' ','*','=','*','*','*',' ','*' }
               , {' ','*','=','*','*','*','*',' ' }
            };

            StringBuilder sb = new StringBuilder();
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                line = line.PadLeft(5, '0');

                char[,] ans = new char[5, 8];
                for (int i = 0 ; i < line.Length ; i++)
                {
                    for (int j = 0 ; j < 8 ; j++)
                    {
                        ans[i, j] = abacus[int.Parse(line[i].ToString()), j];
                    }
                }

                if (sb.Length != 0) sb.AppendLine("");
                for (int i = 0 ; i < 8 ; i++)
                {
                    for (int j = 0 ; j < 5 ; j++)
                    {
                        sb.Append(ans[j, i]);
                    }
                    sb.Append(Environment.NewLine);
                }
            }
            Console.Write(sb.ToString());
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}

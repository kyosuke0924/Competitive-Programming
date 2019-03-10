using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_3_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            string[] line = ReadStAr();
            Stack<int> numbers = new Stack<int>();

            for (int i = 0 ; i < line.Length ; i++)
            {

                int a, b;
                switch (line[i])
                {
                    case "+":
                        a = numbers.Pop();
                        b = numbers.Pop();
                        numbers.Push(b + a);
                        break;
                    case "-":
                        a = numbers.Pop();
                        b = numbers.Pop();
                        numbers.Push(b - a);
                        break;
                    case "*":
                        a = numbers.Pop();
                        b = numbers.Pop();
                        numbers.Push(b * a);
                        break;
                    default:
                        numbers.Push(int.Parse(line[i]));
                        break;
                }
            }

            Console.WriteLine(numbers.Pop());
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

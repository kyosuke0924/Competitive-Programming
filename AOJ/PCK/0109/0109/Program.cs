using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0109
{
    public class Program
        
    {
        public class Source
        {
            public string Str { get; }
            public int Pos { get; set; }

            public Source(string str) { Str = str; Pos = 0; }

            public int Peek() { if (Pos < Str.Length) return Str[Pos]; else return -1; }
            public void Next() { Pos++; }
        }

        public static void Main(string[] args)
        {
            int n = RInt();
            for (int i = 0 ; i < n ; i++)
            {
                Console.WriteLine(new Parser(RSt()).Expr());
            }
        }

        public class Parser : Source
        {
            public Parser(string str) : base(str) { }

            public int Number()
            {
                StringBuilder sb = new StringBuilder();
                int ch;
                while ((ch = Peek()) >= 0 && char.IsDigit((char)ch))
                {
                    sb.Append((char)ch);
                    Next();
                }
                return int.Parse(sb.ToString());
            }

            public int Expr()
            {
                int x = Term();
                while (true)
                {
                    switch (Peek())
                    {
                        case '+': Next(); x += Term(); break;
                        case '-': Next(); x -= Term(); break;
                        default:   return x;
                    }
                }
            }

            public int Term()
            {
                int x = Factor();
                while (true)
                {
                    switch (Peek())
                    {
                        case '*': Next(); x *= Factor(); break;
                        case '/': Next(); x /= Factor(); break;
                        default: return x;
                    }
                }
            }

            public int Factor()
            {
                if (Peek() == '(')
                {
                    Next();
                    int ret = Expr();
                    if (Peek() == ')') { Next(); }
                    return ret;
                }
                return Number();
            }
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

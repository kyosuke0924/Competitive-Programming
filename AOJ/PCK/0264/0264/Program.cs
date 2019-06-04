using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0264
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string s = RSt();
                if (s == "0:") break;

                string[] s2 = s.Split(':');
                int mod = int.Parse(s2[0]);
                string formula = s2[1].Replace(" ", "");

                Parser p = new Parser(formula, mod);
                long res = p.Expr();
                Console.WriteLine(p.Has0Div ? "NG" : "{0} = {1} (mod {2})", formula, res, mod);
            }
        }

        public class Source
        {
            public string Str { get; private set; }
            public int Pos { get; set; }
            public int Mod { get; set; }

            public Source(string str, int mod)
            {
                Str = str; Mod = mod; Pos = 0;
            }

            public int Peek() { if (Pos < Str.Length) return Str[Pos]; else return -1; }
            public void Next() { Pos++; }
        }


        public class Parser : Source
        {
            public Parser(string str, int mod) : base(str, mod) { }
            public bool Has0Div { get; set; }

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

            public long Expr()
            {
                long x = Term();
                while (true)
                {
                    switch (Peek())
                    {
                        case '+': Next(); x = (x + Term()) % Mod; break;
                        case '-': Next(); x = (x - Term() + Mod) % Mod; break;
                        default: return x;
                    }
                }
            }

            public long Term()
            {
                long x = Factor();
                while (true)
                {
                    switch (Peek())
                    {
                        case '*':
                            Next();
                            x = x * Factor() % Mod;
                            break;
                        case '/':
                            Next();
                            long reciprocal = Modinv(Factor(), Mod);
                            if (reciprocal == 0) Has0Div = true;
                            x = x * reciprocal % Mod;
                            break;
                        default: return x;
                    }
                }
            }

            public long Factor()
            {
                if (Peek() == '(')
                {
                    Next();
                    long ret = Expr();
                    if (Peek() == ')') { Next(); }
                    return ret;
                }
                return Number();
            }
        }

        /// <summary>
        /// 逆元（拡張ユークリッド互除法）
        /// </summary>
        /// <param name="a">値（法と互いに素であることが前提条件）</param>
        /// <param name="m">法</param>
        /// <returns></returns>
        private static long Modinv(long a, long m)
        {
            long b = m;
            long u = 1;
            long v = 0;
            while (b != 0)
            {
                long t = a / b;
                a -= t * b;
                Swap(ref a, ref b);
                u -= t * v;
                Swap(ref u, ref v);
            }
            u %= m;
            if (u < 0) u += m;
            return u;
        }
        public static void Swap<T>(ref T v1, ref T v2) { var tmp = v1; v1 = v2; v2 = tmp; }

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

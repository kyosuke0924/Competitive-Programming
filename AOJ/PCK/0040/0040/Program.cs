using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0040
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = RInt();
            for (int i = 0 ; i < n ; i++)
            {
                string line = RSt();
                Console.WriteLine(Decode(line));
            }

        }

        private static string Decode(string line)
        {
            string decodeLine = "";

            for (int i = 1 ; i <= 26 ; i++)
            {
                if (Gcd(i, 26) != 1) continue;
                for (int j = 0 ; j < 26 ; j++)
                {
                    decodeLine = DecodeLine(line, i, j);
                    if (decodeLine.Contains("this") || decodeLine.Contains("that")) return decodeLine;
                }
            }
            return string.Empty;
        }

        private static string DecodeLine(string line, int a, int b)
        {
            char[] decodeLine = new char[line.Length];
            long modInvA = modinv(a, 26);

            for (int i = 0 ; i < line.Length ; i++)
            {
                if (line[i] >= 'a' && line[i] <= 'z')
                {
                    decodeLine[i] = (char)((modInvA * ((line[i] - 'a') + (26 - b))) % 26 + 'a');
                }
                else
                {
                    decodeLine[i] = line[i];
                }

            }
            return string.Join("", decodeLine);
        }


        /// <summary>
        ///最大公約数
        /// </summary>
        public static long Gcd(long a, long b)
        {
            if (a < b) return Gcd(b, a);  // 引数を入替えて自分を呼び出す
            if (b == 0) return a; //一方が0の場合は、もう片方の数自身がGCD

            long d = 0;
            do
            {
                d = a % b;
                a = b;
                b = d;
            } while (d != 0);
            return a;
        }

        /// <summary>
        /// 逆元
        /// </summary>
        /// <param name="a"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private static long modinv(long a, long m)
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
        private static void Swap<T>(ref T v1, ref T v2) { var tmp = v1; v1 = v2; v2 = tmp; }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0005
{
    public class Program

    {
        public static void Main(string[] a6mnbrgs)
        {
            while (true)
            {
                string line = ReadSt();
                if (line == null) break;

                int[] items = Array.ConvertAll(line.Split(' '), e => int.Parse(e));
                Console.WriteLine("{0} {1}", Gcd(items[0], items[1]), Lcm(items[0], items[1]));
            }
           
        }

        /// <summary>
        ///最小公倍数
        /// </summary>
        public static long Lcm(long a, long b)
        {
            return a / Gcd(a, b) * b;
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

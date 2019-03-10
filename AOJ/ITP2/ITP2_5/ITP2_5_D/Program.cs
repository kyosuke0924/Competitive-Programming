using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_5_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] line = new int[n];
            for (int i = 0 ; i < n ; i++) { line[i] = i + 1; }
            var sb = new StringBuilder();
            foreach (var item in GetPermutation(line, line.Count()))
            {
                sb.AppendLine(string.Join(" ",item.Select(x => x.ToString()).ToArray()));
            }
            Console.Write(sb.ToString());
        }

        /// <summary>
        /// 配列の順列を列挙する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">配列</param>
        /// <param name="r">取得数</param>
        /// <returns>配列の組み合わせの列挙</returns>
        public static IEnumerable<IEnumerable<T>> GetPermutation<T>(IEnumerable<T> items, int r)
        {
            if (r == 0)
            {
                yield return Enumerable.Empty<T>();
            }
            else
            {
                foreach (var x in items)
                {
                    var xs = items.Where(y => !y.Equals(x));
                    foreach (var c in GetPermutation(xs, r - 1)) yield return Concat(x, c);
                }
            }
        }

        public static IEnumerable<T> Concat<T>(T first, IEnumerable<T> items)
        {
            yield return first;
            foreach (var i in items) yield return i;
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

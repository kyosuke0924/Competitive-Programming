using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cookingTimes = new int[5];

            for (int i = 0; i < cookingTimes.Length; i++)
            {
                cookingTimes[i] = RInt();
            }

 
            int min = int.MaxValue;
            foreach (var idxs in GetPermutation(Enumerable.Range(0, 5), 5))
            {
                int[] order = idxs.ToArray();

                int time = 0;
                for (int i = 0; i < order.Length; i++)
                {
                    time += cookingTimes[order[i]];
                    if (i < 4)
                    {
                        time += cookingTimes[order[i]] % 10 == 0 ? 0 : 10 - cookingTimes[order[i]] % 10;
                    }
                }
                min = Math.Min(min, time);
            }

            Console.WriteLine(min);
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

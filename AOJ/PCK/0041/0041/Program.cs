using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0041
{
    class Program
    {
        static readonly string[] ope = new string[] { "+", "-", "*" };

        static void Main(string[] args)
        {
            while (true)
            {
                int[] vs = RArInt();
                if (vs.Sum() == 0) break;
                GetAns(vs);
            }
        }

        private static void GetAns(int[] vs)
        {
            foreach (var item in GetPermutation(vs, vs.Length))
            {
                string[] nums = item.Select(x => x.ToString()).ToArray();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (Calc(nums[0] + nums[1] + ope[i] + nums[2] + nums[3] + ope[j] + ope[k]))
                            {
                                Console.WriteLine("(({0} {4} {1}) {6} ({2} {5} {3}))", nums[0], nums[1], nums[2], nums[3], ope[i], ope[j], ope[k]);
                                return;
                            }
                            if (Calc(nums[0] + nums[1] + ope[i] + nums[2] + ope[j] + nums[3] + ope[k]))
                            {
                                Console.WriteLine("((({0} {4} {1}) {5} {2}) {6} {3})", nums[0], nums[1], nums[2], nums[3], ope[i], ope[j], ope[k]);
                                return;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("0");
        }

        private static bool Calc(string s)
        {
            Stack<int> st = new Stack<int>();

            foreach (char item in s)
            {
                int res;
                if (int.TryParse(item.ToString(), out res)) st.Push(res);
                else
                {
                    int d2 = st.Pop();
                    int d1 = st.Pop();
                    switch (item)
                    {
                        case '+':
                            st.Push(d1 + d2);
                            break;
                        case '-':
                            st.Push(d1 - d2);
                            break;
                        case '*':
                            st.Push(d1 * d2);
                            break;
                    }
                }
            }
            return st.Pop() == 10;
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
                foreach (var item in items.Select((x, i) => new { x, i }))
                {
                    foreach (var c in GetPermutation(items.Where((x, i) => i != item.i), r - 1)) yield return Concat(item.x, c);
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

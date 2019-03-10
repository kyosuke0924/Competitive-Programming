using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
    public class Combination
    {
        /// <summary>
        /// 配列の組み合わせを列挙する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">配列</param>
        /// <param name="r">取得数</param>
        /// <returns>配列の組み合わせの列挙</returns>
        public static IEnumerable<IEnumerable<T>> GetCombination<T>(IEnumerable<T> items, int r)
        {
            if (r == 0)
            {
                yield return Enumerable.Empty<T>();
            }
            else
            {
                var i = 0;
                foreach (var x in items)
                {
                    i++;
                    var xs = items.Skip(i);
                    foreach (var c in GetCombination(xs, r - 1)) yield return Concat(x, c);
                }
            }
        }

        private static IEnumerable<T> Concat<T>(T first, IEnumerable<T> items)
        {
            yield return first;
            foreach (var i in items) yield return i;
        }

        /// <summary>
        ///組み合わせの数
        /// </summary>
        public static long nCr(long n, long r, long mod = 0)
        {
            checked
            {
                long ans = 1;
                if (r > n / 2) return nCr(n, n - r, mod);//計算量を減らす(5C4 = 5C1)
                long div = 1;
                for (int i = 0 ; i < r ; i++)
                {
                    ans *= n - i;
                    div *= i + 1;
                    if (mod != 0)
                    {
                        ans %= mod;
                        div %= mod;
                    }
                }

                if (mod != 0)
                {
                    ans *= MathX.Powmod(div, mod - 2, mod);
                    return ans % mod;
                }
                else return ans / div;

            }
        }
    }
}

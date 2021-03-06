﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
    public class Permutation
    {

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
    }
}

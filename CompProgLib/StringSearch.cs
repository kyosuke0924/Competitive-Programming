using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
    public class StringSearch
    {

        // BM法
        public HashSet<int> BMSearch(string target, string pattern)
        {

            HashSet<int> hs = new HashSet<int>();
            Dictionary<char, int> table = CreateTable(pattern);

            // 開始位置をパターン末尾に合わせる
            int i = pattern.Length - 1;
            int p = 0;

            while (i < target.Length)
            {
                // パターン末尾に位置を合わせる
                p = pattern.Length - 1;

                while (p >= 0 && i < target.Length)
                {
                    if (target[i] == pattern[p])
                    {
                        i--; p--;
                    }
                    else
                    {
                        break;
                    }
                }
                // 一致判定
                if (p < 0)
                {
                    // 一致した場合はハッシュに追加
                    hs.Add(i + 1);
                    i += pattern.Length - p; // 比較を開始した地点の1つ後ろの文字
                }
                else
                {
                    // 不一致の場合、ずらし表を参照し i を進める
                    // ただし、今比較した位置より後の位置とする
                    var shift1 = table.ContainsKey(pattern[p]) ? table[pattern[p]] : pattern.Length;
                    var shift2 = pattern.Length - p;    // 比較を開始した地点の1つ後ろの文字
                    i += Math.Max(shift1, shift2);
                }
            }
            return hs;
        }

        // ずらし表の作成
        private Dictionary<char, int> CreateTable(string pattern)
        {
            // パターン末尾からの距離(小さい幅を優先)
            var table = new Dictionary<char, int>();
            for (int i = 0 ; i < pattern.Length ; i++)
            {
                table[pattern[i]] = pattern.Length - i - 1;
            }
            return table;
        }

        // ラビンカープ法
        public List<int> RKSearch(string target, string pattern)
        {
            const long B = 100000007;

            List<int> hs = new List<int>();
            if (target.Length < pattern.Length) return hs;

            long t = 1;
            for (int i = 0 ; i < pattern.Length ; i++) t *= B;

            long tHash = 0;
            long pHash = 0;

            for (int i = 0 ; i < pattern.Length ; i++)
            {
                tHash = tHash * B + target[i];
                pHash = pHash * B + pattern[i];
            }

            for (int i = 0 ; i + pattern.Length <= target.Length ; i++)
            {
                if (tHash == pHash) hs.Add(i);
                if (i + pattern.Length < target.Length) tHash = tHash * B + target[i + pattern.Length] - target[i] * t;
            }

            return hs;

        }

        public void RKSearch(string target, string pattern, StringBuilder sb)
        {

            const long B = 100000007;

            List<int> hs = new List<int>();
            if (target.Length < pattern.Length) return;

            long t = 1;
            for (int i = 0 ; i < pattern.Length ; i++) t *= B;

            long tHash = 0;
            long pHash = 0;

            for (int i = 0 ; i < pattern.Length ; i++)
            {
                tHash = tHash * B + target[i];
                pHash = pHash * B + pattern[i];
            }

            for (int i = 0 ; i + pattern.Length <= target.Length ; i++)
            {
                if (tHash == pHash) sb.AppendLine(i.ToString());
                if (i + pattern.Length < target.Length) tHash = tHash * B + target[i + pattern.Length] - target[i] * t;
            }

            return;

        }

        public void PatternMatch(char[,] target, char[,] pattern, StringBuilder sb)
        {

            const long B1 = 100000007;
            const long B2 = 100000009;

            int tRowCnt = target.GetLength(0);
            int pRowCnt = pattern.GetLength(0);
            int tColCnt = target.GetLength(1);
            int pColCnt = pattern.GetLength(1);

            if (pRowCnt > tRowCnt || pColCnt > tColCnt) return;

            //パターンのハッシュ値
            long pHash = 0;
            long[] tmp = new long[pRowCnt];

            for (int i = 0 ; i < pRowCnt ; i++)
            {
                for (int j = 0 ; j < pColCnt ; j++)
                {
                    tmp[i] = tmp[i] * B1 + pattern[i, j];
                }
            }

            for (int i = 0 ; i < pRowCnt ; i++) pHash = pHash * B2 + tmp[i];

            //ターゲットのハッシュ値

            long t1 = 1;
            for (int i = 0 ; i < pColCnt ; i++) t1 *= B1;

            long t2 = 1;
            for (int i = 0 ; i < pRowCnt ; i++) t2 *= B2;

            long[,] tmp2 = new long[tRowCnt, tColCnt - pColCnt + 1];
            bool[,] matchTbl = new bool[tRowCnt - pRowCnt + 1, tColCnt - pColCnt + 1];
            for (int i = 0 ; i < tRowCnt ; i++)
            {
                long e = 0;
                for (int j = 0 ; j < pColCnt ; j++) e = e * B1 + target[i, j];

                for (int j = 0 ; j + pColCnt <= tColCnt ; j++)
                {
                    tmp2[i, j] = e;
                    if (j + pColCnt < tColCnt) e = e * B1 - t1 * target[i, j] + target[i, j + pColCnt];
                }

            }

            for (int j = 0 ; j + pColCnt <= tColCnt ; j++)
            {
                long e = 0;
                for (int i = 0 ; i < pRowCnt ; i++) e = e * B2 + tmp2[i, j];

                for (int i = 0 ; i + pRowCnt <= tRowCnt ; i++)
                {
                    if (e == pHash) matchTbl[i, j] = true;
                    if (i + pRowCnt < tRowCnt) e = e * B2 - t2 * tmp2[i, j] + tmp2[i + pRowCnt, j];
                }
            }

            for (int i = 0 ; i < matchTbl.GetLength(0) ; i++)
            {
                for (int j = 0 ; j < matchTbl.GetLength(1) ; j++)
                {
                    if (matchTbl[i, j]) sb.AppendLine(i.ToString() + " " + j.ToString());
                }
            }

        }

        public class SuffixArray
        {
            private string s;
            private int n;
            private int k;
            private int[] rank;
            private int[] sa;

            public SuffixArray(string target)
            {
                s = target;
                n = s.Length;
                sa = new int[n + 1];
                rank = new int[n + 1];
                Constract_sa();
            }

            private int Compare_sa(int i, int j)
            {
                if (rank[i] != rank[j]) return rank[i] - rank[j];
                else
                {
                    int ri = i + k <= n ? rank[i + k] : -1;
                    int rj = j + k <= n ? rank[j + k] : -1;
                    return ri - rj;
                }
            }

            private void Constract_sa()
            {
                for (int i = 0 ; i <= n ; i++)
                {
                    sa[i] = i;
                    rank[i] = (i < n) ? s[i] : -1;
                }

                int[] tmp = new int[n + 1];
                for (k = 1 ; k <= n ; k *= 2)
                {
                    Array.Sort(sa, Compare_sa);

                    tmp[sa[0]] = 0;
                    for (int i = 1 ; i <= n ; i++)
                    {
                        tmp[sa[i]] = tmp[sa[i - 1]] + (Compare_sa(sa[i - 1], sa[i]) < 0 ? 1 : 0);
                    }
                    for (int i = 0 ; i <= n ; i++)
                    {
                        rank[i] = tmp[i];
                    }
                }
            }

            public bool Contains(string pattern)
            {
                int a = 0, b = n;
                while (b - a > 1)
                {
                    int c = (a + b) / 2;
                    if (string.Compare(s, sa[c], pattern, 0, pattern.Length) < 0) a = c;
                    else b = c;

                }
                return string.Compare(s, sa[b], pattern, 0, pattern.Length) == 0;
            }
        }
    }
}

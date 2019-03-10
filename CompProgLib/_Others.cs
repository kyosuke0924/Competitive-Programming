using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
    public class Others
    {

        /// <summary>
        /// 最長共通部分列 (LongestCommonSubsequence:LCS) の長さを求める
        /// </summary>
        /// <param name="str1">文字列1</param>
        /// <param name="str2">文字列2</param>
        /// <returns>最長共通部分列の長さ</returns>
        public static int GetLCSLength(string str1, string str2)
        {

            int n = str1.Length;
            int m = str2.Length;

            int[,] dp = new int[n + 1, m + 1];

            for (int i = 0 ; i < n ; i++)
            {
                for (int j = 0 ; j < m ; j++)
                {
                    dp[i + 1, j + 1] = (str1[i] == str2[j]) ? dp[i, j] + 1 : Math.Max(dp[i, j + 1], dp[i + 1, j]);
                }
            }
            return dp[n, m];
        }

        /// <summary>
        /// 3点に囲まれた三角形の面積を求める
        /// </summary>
        /// <param name="p1x">p1のx座標</param>
        /// <param name="p1y">p1のy座標</param>
        /// <param name="p2x">p2のx座標</param>
        /// <param name="p2y">p2のy座標</param>
        /// <param name="p3x">p3のx座標</param>
        /// <param name="p3y">p3のy座標</param>
        /// <returns>三角形の面積</returns>
        public static double CalcTriangleArea(double p1x, double p1y, double p2x, double p2y, double p3x, double p3y)
        {
            return Math.Abs((p1x - p3x) * (p2y - p3y) - (p2x - p3x) * (p1y - p3y)) / 2;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0247
{
    class Program
    {
        enum Field { Plain = -3, Mountain = -2, Ice = -1 }
        static readonly int[] di = new int[] { 0, 1, 0, -1 };
        static readonly int[] dj = new int[] { 1, 0, -1, 0 };

        static int h, w;
        static int sI, sJ, gI, gJ;
        static int[,] map;
        static bool[,] visited;
        static int[] passedIce;
        static int[] iceCnts;

        static void Main(string[] args)
        {
            while (true)
            {
                int[] xy = RArInt();
                if (xy.Sum() == 0) break;
                Init(xy);
                for (int u = 0; u < h * w; u++)
                {
                    if (CalcMinCost(u, sI, sJ, 0))
                    {
                        Console.WriteLine(u);
                        break;
                    }
                }
            }
        }

        private static void Init(int[] xy)
        {
            w = xy[0]; h = xy[1];
            map = new int[h, w];
            visited = new bool[h, w];
            for (int i = 0; i < h; i++)
            {
                string ms = RSt();
                for (int j = 0; j < w; j++)
                {
                    switch (ms[j])
                    {
                        case '#':
                            map[i, j] = (int)Field.Mountain;
                            break;
                        case 'X':
                            map[i, j] = (int)Field.Ice;
                            break;
                        default:
                            map[i, j] = (int)Field.Plain;
                            if (ms[j] == 'S') { sI = i; sJ = j; }
                            else if (ms[j] == 'G') { gI = i; gJ = j; }
                            break;
                    }
                }
            }
            SetIce();
            passedIce = new int[iceCnts.Length];
        }

        private static void SetIce()
        {
            iceCnts = new int[100];
            int num = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (map[i, j] == (int)Field.Ice)
                    {
                        SetIceDFS(i, j, num);
                        num++;
                    }
                }
            }
        }

        private static void SetIceDFS(int i, int j, int num)
        {
            map[i, j] = num;
            iceCnts[num]++;
            for (int k = 0; k < di.Length; k++)
            {
                int nI = i + di[k];
                int nJ = j + dj[k];
                if (!(0 <= nI && nI < h && 0 <= nJ && nJ < w) || map[nI, nJ] != (int)Field.Ice) continue;
                SetIceDFS(nI, nJ, num);
            }
        }

        private static bool CalcMinCost(int u, int i, int j, int cost)
        {
            if (i == gI && j == gJ)
            {
                return true;
            }

            visited[i, j] = true;
            int eValue = cost + Math.Abs(i - gI) + Math.Abs(j - gJ);
            if (eValue <= u)
            {
                for (int k = 0; k < di.Length; k++)
                {
                    int nI = i + di[k];
                    int nJ = j + dj[k];
                    if (!(0 <= nI && nI < h && 0 <= nJ && nJ < w) || map[nI, nJ] == (int)Field.Mountain || visited[nI, nJ]) continue;

                    if (map[nI, nJ] != (int)Field.Plain)
                    {
                        int iceIdx = map[nI, nJ];
                        if ((passedIce[iceIdx] + 1) * 2 <= iceCnts[iceIdx])
                        {
                            passedIce[iceIdx]++;
                            visited[nI, nJ] = true;
                            if (CalcMinCost(u, nI, nJ, cost + 1)) return true;
                            visited[nI, nJ] = false;
                            passedIce[iceIdx]--;
                        }
                    }
                    else
                    {
                        visited[nI, nJ] = true;
                        if (CalcMinCost(u, nI, nJ, cost + 1)) return true;
                        visited[nI, nJ] = false;
                    }
                }
            }
            visited[i, j] = false;
            return false;
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

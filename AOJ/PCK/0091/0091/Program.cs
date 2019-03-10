using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0091

{
    public class Program

    {
        public enum DropSize { L = 0, M = 1, S = 2 }
        const int SIZE = 10;
        const int SENT = 2;
        static int[,] map = new int[SIZE + SENT * 2, SIZE + SENT * 2];

        static int[] sDx = new int[] { 0, -1, 1, 0, 0 };
        static int[] sDy = new int[] { 0, 0, 0, -1, 1 };
        static int[] mDx = new int[] { 0, -1, 1, 0, 0, -1, -1, 1, 1 };
        static int[] mDy = new int[] { 0, 0, 0, -1, 1, -1, 1, -1, 1 };
        static int[] lDx = new int[] { 0, -1, 1, 0, 0, -1, -1, 1, 1, -2, 2, 0, 0 };
        static int[] lDy = new int[] { 0, 0, 0, -1, 1, -1, 1, -1, 1, 0, 0, -2, 2 };

        static List<cand>[] cands = new List<cand>[3];
        static int[] candsCnt = new int[3];
        struct cand
        {
            public int I { get; set; }
            public int J { get; set; }
            public DropSize SIZE { get; set; }
            public cand(int i, int j, DropSize size) { I = i; J = j; SIZE = size; }
        }
        static Stack<cand> ans;

        public static void Main(string[] args)
        {
            int n = RInt();

            int mapSum = 0;
            for (int i = 0 ; i < SIZE ; i++)
            {
                int[] line = RIntAr();
                mapSum += line.Sum();
                for (int j = 0 ; j < SIZE ; j++) map[i + SENT, j + SENT] = line[j];
            }

            // 大・中・小の滴下数パターン候補
            List<int[]> dropsLMS = GetDropsCnts(n, mapSum);

            //滴下候補点の算出
            for (int i = 0 ; i < cands.Length ; i++) cands[i] = new List<cand>(SIZE * SIZE);
            for (int i = SENT ; i < SIZE + SENT ; i++)
            {
                for (int j = SENT ; j < SIZE + SENT ; j++)
                {
                    if (CanPut(i, j, DropSize.S))
                    {
                        cands[(int)DropSize.S].Add(new cand(i, j, DropSize.S));
                        candsCnt[(int)DropSize.S]++;
                        if (CanPut(i, j, DropSize.M))
                        {
                            cands[(int)DropSize.M].Add(new cand(i, j, DropSize.M));
                            candsCnt[(int)DropSize.M]++;
                            if (CanPut(i, j, DropSize.L))
                            {
                                cands[(int)DropSize.L].Add(new cand(i, j, DropSize.L));
                                candsCnt[(int)DropSize.L]++;
                            }
                        }
                    }
                }
            }

            int[,] defaultMap = new int[SIZE + SENT * 2, SIZE + SENT * 2];
            Array.Copy(map, defaultMap, map.Length);

            // 滴下数パターンごとに再帰して探索
            foreach (var dropsCmb in dropsLMS)
            {
                ans = new Stack<cand>(12);
                Array.Copy(defaultMap, map, map.Length);
                if (Solve(dropsCmb, 0, new int[] { 0, 0, 0 }, 0)) return;
            }
        }

        private static bool Solve(int[] dropsCmb, int sIdx, int[] Cnt, int k)
        {

            if (Cnt[(int)DropSize.L] == dropsCmb[(int)DropSize.L]
             && Cnt[(int)DropSize.M] == dropsCmb[(int)DropSize.M]
             && Cnt[(int)DropSize.S] == dropsCmb[(int)DropSize.S])
            {
                foreach (var item in ans) Console.WriteLine("{0} {1} {2}", item.J - SENT, item.I - SENT, 3 - (int)item.SIZE);
                return true;
            }

            if (dropsCmb[k] == 0) return Solve(dropsCmb, 0, Cnt, k + 1);
            if (k > (int)DropSize.S) return false;

            for (int i = sIdx ; i < cands[k].Count() ; i++)
            {
                if (CanPut(cands[k][i]))
                {
                    SetMap(cands[k][i]);
                    ans.Push(cands[k][i]);
                    Cnt[(int)cands[k][i].SIZE]++;

                    if (Cnt[k] >= dropsCmb[k])
                    {
                        if (Solve(dropsCmb, 0, Cnt, k + 1)) return true;
                    }
                    else
                    {
                        if (Solve(dropsCmb, i, Cnt, k)) return true;
                    }

                    Cnt[(int)cands[k][i].SIZE]--;
                    ans.Pop();
                    ReSetMap(cands[k][i]);
                }
            }
            return false;
        }

        private static void SetMap(cand cand)
        {
            int[] dj = GetDxOrDy(cand.SIZE, true);
            int[] di = GetDxOrDy(cand.SIZE, false);
            for (int i = 0 ; i < dj.Length ; i++) map[cand.I + di[i], cand.J + dj[i]]--;
        }
        private static void ReSetMap(cand cand)
        {
            int[] dj = GetDxOrDy(cand.SIZE, true);
            int[] di = GetDxOrDy(cand.SIZE, false);
            for (int i = 0 ; i < dj.Length ; i++) map[cand.I + di[i], cand.J + dj[i]]++;
        }

        private static bool CanPut(cand cand) { return CanPut(cand.I, cand.J, cand.SIZE); }
        private static bool CanPut(int i, int j, DropSize size)
        {
            int[] dj = GetDxOrDy(size, true);
            int[] di = GetDxOrDy(size, false);

            for (int k = 0 ; k < dj.Length ; k++) if (map[i + di[k], j + dj[k]] == 0) return false;
            return true;
        }

        private static int[] GetDxOrDy(DropSize size, bool isDj)
        {
            switch (size)
            {
                case DropSize.S: return isDj ? sDx : sDy;
                case DropSize.M: return isDj ? mDx : mDy;
                case DropSize.L: return isDj ? lDx : lDy; ;
            }
            return null;
        }

        private static List<int[]> GetDropsCnts(int n, int sum)
        {
            List<int[]> list = new List<int[]>();
            for (int i = 0 ; i <= n ; i++)
            {
                if (13 * i > sum) break;
                for (int j = 0 ; j <= n ; j++)
                {
                    if (13 * i + 9 * j > sum || i + j > n) break;
                    if (13 * i + 9 * j + 5 * (n - (i + j)) == sum) list.Add(new int[] { i, j, n - (i + j) });
                }
            }
            return list;
        }

        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
    }

}



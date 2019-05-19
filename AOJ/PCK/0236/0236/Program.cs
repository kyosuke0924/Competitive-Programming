using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0236
{
    class Program
    {
        enum Dir { L, U, R, D }
        enum Status { Blank, CannotJoin, MustJoin }

        static readonly int[] di = new int[] { 0, -1, 0, 1 };
        static readonly int[] dj = new int[] { -1, 0, 1, 0 };
        static readonly Tuple<Dir, Dir>[] pieces = new Tuple<Dir, Dir>[]
        {
              new Tuple<Dir, Dir>(Dir.L,Dir.U)
            , new Tuple<Dir, Dir>(Dir.L,Dir.R)
            , new Tuple<Dir, Dir>(Dir.L,Dir.D)
            , new Tuple<Dir, Dir>(Dir.U,Dir.R)
            , new Tuple<Dir, Dir>(Dir.U,Dir.D)
            , new Tuple<Dir, Dir>(Dir.R,Dir.D)
        };

        static int[,] map;
        static Status[,][] statuses;
        static List<Tuple<int, int>> blkCells;

        static void Main(string[] args)
        {
            while (true)
            {
                int[] wh = RArInt();
                if (wh.Sum() == 0) break;
                if (!Init(wh))
                {
                    Console.WriteLine("No");
                    continue;
                }
                Console.WriteLine(CanMakeCircuit(0) && IsLineContinuous() ? "Yes" : "No");
            }
        }

        private static bool Init(int[] wh)
        {
            map = new int[wh[1] + 2, wh[0] + 2];
            for (int i = 1; i < map.GetLength(0) - 1; i++)
            {
                int[] vs = RArInt();
                for (int j = 1; j < map.GetLength(1) - 1; j++)
                {
                    map[i, j] = vs[j - 1] ^ 1;
                }
            }

            statuses = new Status[wh[1] + 2, wh[0] + 2][];
            blkCells = new List<Tuple<int, int>>();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    statuses[i, j] = new Status[di.Length];
                    if (map[i, j] == 0)
                    {
                        for (int k = 0; k < di.Length; k++) statuses[i, j][k] = Status.CannotJoin;
                    }
                    else
                    {
                        blkCells.Add(new Tuple<int, int>(i, j));
                        if (SetDefaultStutas(i, j) < 2) return false; //隣接する空白セルが2未満の空白セルがあればNG
                    }
                }
            }

            if (blkCells.Count() < 4 || blkCells.Count() % 2 == 1) return false; //空白セルが4個未満または奇数だとNG
            else return true;

        }

        private static int SetDefaultStutas(int i, int j)
        {
            int blankCnt = 0;
            for (int k = 0; k < di.Length; k++)
            {
                if (map[i + di[k], j + dj[k]] == 0)
                {
                    statuses[i, j][k] = Status.CannotJoin;
                }
                else
                {
                    statuses[i, j][k] = Status.Blank;
                    blankCnt++;
                }
            }
            return blankCnt;
        }

        private static bool CanMakeCircuit(int v)
        {
            if (v == blkCells.Count())
            {
                return IsLineContinuous(); 
            }
            for (int i = 0; i < pieces.Length; i++)
            {
                if (!CanSetPiece(v, pieces[i])) continue;
                SetPiece(v, pieces[i]);
                if (CanMakeCircuit(v + 1)) return true;
                RemovePiece(v);
            }
            return false;
        }

        private static bool CanSetPiece(int v, Tuple<Dir, Dir> tuple)
        {
            for (int k = 0; k < di.Length; k++)
            {
                var cur = statuses[blkCells[v].Item1 + di[k], blkCells[v].Item2 + dj[k]][(k + 2) % di.Length];
                if (k == (int)tuple.Item1 || k == (int)tuple.Item2)
                {
                    if (cur == Status.CannotJoin) return false;
                }
                else
                {
                    if (cur == Status.MustJoin) return false;
                }
            }
            return true;
        }

        private static void SetPiece(int v, Tuple<Dir, Dir> tuple)
        {
            int i = blkCells[v].Item1;
            int j = blkCells[v].Item2;

            for (int k = 0; k < di.Length; k++)
            {
                if (k == (int)tuple.Item1 || k == (int)tuple.Item2)
                {
                    statuses[i, j][k] = Status.MustJoin;
                }
                else
                {
                    statuses[i, j][k] = Status.CannotJoin;
                }
            }
        }

        private static void RemovePiece(int v)
        {
            SetDefaultStutas(blkCells[v].Item1, blkCells[v].Item2);
        }

        private static bool IsLineContinuous()
        {
            bool[,] visited = new bool[map.GetLength(0), map.GetLength(1)];

            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(blkCells[0]);
            visited[blkCells[0].Item1, blkCells[1].Item2] = true;

            int contCnt = 0;
            while (q.Count() > 0)
            {
                var cur = q.Dequeue();
                contCnt++;

                for (int k = 0; k < di.Length; k++)
                {
                    if (statuses[cur.Item1, cur.Item2][k] != Status.MustJoin) continue;

                    int ni = cur.Item1 + di[k];
                    int nj = cur.Item2 + dj[k];
                    if (!visited[ni, nj])
                    {
                        q.Enqueue(new Tuple<int, int>(ni, nj));
                        visited[ni, nj] = true;
                    }
                }
            }

            //閉路をたどって全ての空白セルに到達できない場合は、単一閉路でないためNG
            if (blkCells.Count() != contCnt) return false;
            else return true;
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


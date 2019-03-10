using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0132bk
{
    public class Program

    {
        public class Puzzle
        {
            private int[,] map;
            private int[,] defauleMap;
            public int BlankAreaSize { get; private set; }
            public int[] BlankAreaSize_row { get; private set; }

            public Puzzle(int[,] v)
            {
                map = new int[v.GetLength(0), v.GetLength(1)];
                defauleMap = new int[v.GetLength(0), v.GetLength(1)];

                Array.Copy(v, this.map, map.Length);
                Array.Copy(v, this.defauleMap, defauleMap.Length);

                SetBlankAreaSize();
            }

            private void SetBlankAreaSize()
            {
                BlankAreaSize_row = new int[map.GetLength(0)];
                int sum_row = 0;
                for (int i = 0 ; i < map.GetLength(0) ; i++)
                {
                    sum_row = 0;
                    for (int j = 0 ; j < map.GetLength(1) ; j++)
                    {
                        sum_row += map[i, j];
                    }
                    BlankAreaSize_row[i] = map.GetLength(1) - sum_row;
                }
                BlankAreaSize = BlankAreaSize_row.Sum();
            }

            public void Clear()
            {
                Array.Copy(defauleMap, map, map.Length);
                SetBlankAreaSize();
            }

            public int GetLength(int v) { return map.GetLength(v); }

            public bool IsComplete()
            {
                for (int i = 0 ; i < map.GetLength(0) ; i++)
                {
                    for (int j = 0 ; j < map.GetLength(1) ; j++)
                    {
                        if (map[i, j] != 1) return false;
                    }
                }
                return true;
            }

            public bool CanSetPiece(int si, int sj, int[,] piece)
            {
                for (int i = 0 ; i < piece.GetLength(0) ; i++)
                {
                    for (int j = 0 ; j < piece.GetLength(1) ; j++)
                    {
                        if ((piece[i, j] & map[i + si, j + sj]) == 1) return false;
                    }
                }
                return true;
            }

            public void SetPiece(int si, int sj, int[,] piece, int d = 1)
            {
                int sum_row;
                for (int i = 0 ; i < piece.GetLength(0) ; i++)
                {
                    sum_row = 0;
                    for (int j = 0 ; j < piece.GetLength(1) ; j++)
                    {
                        if (piece[i, j] == 1)
                        {
                            map[i + si, j + sj] += d;
                            sum_row += d;
                        }
                    }
                    BlankAreaSize_row[i + si] -= sum_row;
                }
            }

            public void RemovePiece(int si, int sj, int[,] piece) { SetPiece(si, sj, piece, -1); }

        }

        public class Piece
        {
            public int[][,] Rotates { get; }
            public int FillAreaSize { get; }
            public int[][] FillAreaSize_row { get; }

            public Piece(int[,] v)
            {
                Rotates = new int[4][,];
                FillAreaSize_row = new int[4][];

                Rotates[0] = v;
                for (int i = 1 ; i <= 3 ; i++) { Rotates[i] = RotateClockwise(Rotates[i - 1]); }   //set rotated shape
                int sum = 0;
                for (int i = 0 ; i < v.GetLength(0) ; i++)
                {
                    for (int j = 0 ; j < v.GetLength(1) ; j++)
                    {
                        sum += v[i, j];
                    }
                }
                FillAreaSize = sum;

                int sum_row = 0;
                for (int k = 0 ; k < Rotates.Length ; k++)
                {
                    FillAreaSize_row[k] = new int[Rotates[k].GetLength(0)];
                    for (int i = 0 ; i < Rotates[k].GetLength(0) ; i++)
                    {
                        sum_row = 0;
                        for (int j = 0 ; j < Rotates[k].GetLength(1) ; j++)
                        {
                            sum_row += Rotates[k][i, j];
                        }
                        FillAreaSize_row[k][i] = sum_row;
                    }
                }
            }

            private int[,] RotateClockwise(int[,] piece)
            {
                int rows = piece.GetLength(0);
                int cols = piece.GetLength(1);
                var t = new int[cols, rows];
                for (int i = 0 ; i < rows ; i++)
                {
                    for (int j = 0 ; j < cols ; j++)
                    {
                        t[j, rows - i - 1] = piece[i, j];
                    }
                }
                return t;
            }

        }

        public static void Main_bk(string[] args)
        {

            Puzzle puzzle;
            Dictionary<int, Piece> pieces;

            var sw = new System.Diagnostics.Stopwatch();
            while (true)
            {
                int[] HWMap = RIntAr();
                if (HWMap.Sum() == 0) break;

#if DEBUG
                if (!sw.IsRunning) sw.Start();
#endif

                string line;
                int[,] map = new int[HWMap[0], HWMap[1]];
                for (int i = 0 ; i < map.GetLength(0) ; i++)
                {
                    line = RSt();
                    for (int j = 0 ; j < map.GetLength(1) ; j++)
                    {
                        map[i, j] = line[j] == '#' ? 1 : 0;
                    }
                }
                puzzle = new Puzzle(map);

                int n = RInt();
                pieces = new Dictionary<int, Piece>(n);

                for (int k = 0 ; k < n ; k++)
                {
                    int[] HWPiece = RIntAr();
                    int[,] piece = new int[HWPiece[0], HWPiece[1]];


                    for (int i = 0 ; i < piece.GetLength(0) ; i++)
                    {
                        line = RSt();
                        for (int j = 0 ; j < piece.GetLength(1) ; j++)
                        {
                            piece[i, j] = line[j] == '#' ? 1 : 0;
                        }
                    }
                    pieces.Add(k + 1, new Piece(piece));
                }

                int p = RInt();
                for (int k = 0 ; k < p ; k++)
                {
                    puzzle.Clear();
                    Console.WriteLine(CanComplete(puzzle, pieces, RIntAr().Skip(1).OrderByDescending(x => pieces[x].FillAreaSize).ToArray()) ? "YES" : "NO");
                }

            }
#if DEBUG
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
#endif
        }

        private static bool CanComplete(Puzzle puzzle, Dictionary<int, Piece> pieces, int[] selected)
        {
            if (puzzle.BlankAreaSize != selected.Select(x => pieces[x].FillAreaSize).Sum()) return false;
            return CanSolvePuzzle(0, puzzle, selected.Select(x => pieces[x]).ToArray());
        }

        private static bool CanSolvePuzzle(int k, Puzzle puzzle, Piece[] pieces)
        {
            if (k == pieces.Count())
            {
                if (puzzle.IsComplete()) return true; else return false;
            }

            for (int r = 0 ; r < pieces[k].Rotates.Length ; r++)
            {
                int iEnd = puzzle.GetLength(0) - pieces[k].Rotates[r].GetLength(0);
                int jEnd = puzzle.GetLength(1) - pieces[k].Rotates[r].GetLength(1);

                for (int i = 0 ; i <= iEnd ; i++)
                {
                    //if (puzzle.BlankAreaSize_row[i] < pieces[k].FillAreaSize_row[r][0]) continue;
                    if (pieces[k].FillAreaSize_row[r].Where((x, idx) => x > puzzle.BlankAreaSize_row[i + idx]).Count() > 0) continue;

                    for (int j = 0 ; j <= jEnd ; j++)
                    {
                        if (puzzle.CanSetPiece(i, j, pieces[k].Rotates[r]))
                        {
                            puzzle.SetPiece(i, j, pieces[k].Rotates[r]);
                            if (CanSolvePuzzle(k + 1, puzzle, pieces)) return true;
                            else puzzle.RemovePiece(i, j, pieces[k].Rotates[r]);
                        }
                    }
                }
            }

            return false;
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0132
{
    public class Program

    {
        internal class Grid
        {
            private int[] Map;
            public int H { get; private set; }
            public int W { get; private set; }
            public int Size { get; private set; }

            internal Grid(string[] v, int h, int w)
            {
                Map = new int[v.Length];
                H = h;
                W = w;
                for (int i = 0 ; i < h ; i++)
                {
                    for (int j = 0 ; j < w ; j++)
                    {
                        if (v[i][j] == '#')
                        {
                            Map[i] = (Map[i] << 1) | 1;
                            Size++;
                        }
                        else
                        {
                            Map[i] = (Map[i] << 1) | 0;
                        }
                    }
                }
            }

            internal Grid(Grid gd)
            {
                H = gd.H;
                W = gd.W;
                Size = gd.Size;
                Map = new int[H];
                for (int i = 0 ; i < H ; i++) { Map[i] = gd.Map[i]; }
            }

            internal bool IsComplete()
            {
                var allFill = Math.Pow(2, W) - 1;
                return Map.All(x => x == allFill) ? true : false;
            }

            internal bool CanSetPiece(int si, int sj, Grid piece)
            {
                for (int i = 0 ; i < piece.H ; i++) if ((Map[si + i] & (piece.Map[i] << ((W - piece.W) - sj))) > 0) return false;
                return true;
            }

            internal void SetPiece(int si, int sj, Grid piece)
            {
                for (int i = 0 ; i < piece.H ; i++) Map[i + si] |= (piece.Map[i] << ((W - piece.W) - sj));
            }

            internal void RemovePiece(int si, int sj, Grid piece)
            {
                for (int i = 0 ; i < piece.H ; i++) Map[i + si] ^= (piece.Map[i] << ((W - piece.W) - sj));
            }

            internal void Rotate()
            {
                int newH = W;
                int newW = H;
                int[] newMap = new int[newH];
                for (int i = 0 ; i < newH ; i++)
                {
                    for (int j = 0 ; j < newW ; j++)
                    {
                        newMap[i] |= ((Map[j] >> newH - (i + 1)) & 1) << j;
                    }
                }
                H = newH; W = newW; Map = newMap;
            }

            internal bool Equals(Grid g)
            {
                if (H != g.H || W != g.W) return false;
                for (int i = 0 ; i < H ; i++)
                    if (Map[i] != g.Map[i]) return false;
                return true;
            }

        }

        internal class Piece
        {
            public List<Rotation> Rotations { get; set; }
            public Piece() { Rotations = new List<Rotation>(); }
        }

        internal class Rotation
        {
            public Grid Map { get; set; }
            public List<P> Candidates { get; set; }
            public Rotation(Grid map, List<P> candidates) { Map = map; Candidates = candidates; }
        }

        internal struct P
        {
            public int i { get; set; }
            public int j { get; set; }
            public P(int i, int j) { this.i = i; this.j = j; }
        }

        static List<P> GetCandidatesP(Grid puzzle, Grid piece)
        {
            int iMax = puzzle.H - piece.H;
            int jMax = puzzle.W - piece.W;

            List<P> Candidates = new List<P>();

            for (int i = 0 ; i <= iMax ; i++)
            {
                for (int j = 0 ; j <= jMax ; j++)
                {
                    if (puzzle.CanSetPiece(i, j, piece)) Candidates.Add(new P(i, j));
                }
            }
            return Candidates;
        }

        static bool CanSetAfter(int inputK, Piece[] pieces, Grid puzzle)
        {
            Grid tmpPuzzle = new Grid(puzzle);

            for (int k = inputK ; k < pieces.Length ; k++)
            {
                Piece piece = pieces[k];
                for (int i = 0 ; i < piece.Rotations.Count ; i++)
                {
                    Rotation rt = piece.Rotations[i];
                    for (int j = 0 ; j < rt.Candidates.Count ; j++)
                    {
                        P pt = rt.Candidates[j];
                        if (puzzle.CanSetPiece(pt.i, pt.j, rt.Map)) tmpPuzzle.SetPiece(pt.i, pt.j, rt.Map);
                    }
                }
            }
            return tmpPuzzle.IsComplete() ? true : false;
        }

        static bool CanSolvePuzzle(int k, Piece[] pieces, Grid puzzle)
        {
            if (k >= pieces.Length) return true;

            Piece piece = pieces[k];
            for (int i = 0 ; i < piece.Rotations.Count ; i++)
            {
                Rotation rt = piece.Rotations[i];
                for (int j = 0 ; j < rt.Candidates.Count ; j++)
                {
                    P pt = rt.Candidates[j];
                    if (puzzle.CanSetPiece(pt.i, pt.j, rt.Map))
                    {
                        puzzle.SetPiece(pt.i, pt.j, rt.Map);
                        if (CanSetAfter(k + 1, pieces, puzzle) && CanSolvePuzzle(k + 1, pieces, puzzle)) return true;
                        puzzle.RemovePiece(pt.i, pt.j, rt.Map);
                    }
                }
            }
            return false;
        }

        internal static void Main(string[] args)
        {

            Grid puzzle;
            Dictionary<int, Piece> pieces;

            var sw = new System.Diagnostics.Stopwatch();
            while (true)
            {
                int[] HWMap = RIntAr();
                if (HWMap.Sum() == 0) break;

#if DEBUG
                if (!sw.IsRunning) sw.Start();
#endif

                string[] lines = new string[HWMap[0]];
                for (int i = 0 ; i < HWMap[0] ; i++) lines[i] = RSt();
                puzzle = new Grid(lines, HWMap[0], HWMap[1]);

                int n = RInt();
                pieces = new Dictionary<int, Piece>(n);

                for (int i = 1 ; i <= n ; i++)
                {
                    int[] HWPiece = RIntAr();
                    lines = new string[HWPiece[0]];
                    for (int j = 0 ; j < HWPiece[0] ; j++) lines[j] = RSt();
                    Grid tmpGrid = new Grid(lines, HWPiece[0], HWPiece[1]);

                    Piece piece = pieces[i] = new Piece();

                    for (int j = 0 ; j <= 3 ; j++)
                    {
                        bool inc = false;
                        for (int k = 0 ; k < piece.Rotations.Count ; k++)
                            if (piece.Rotations[k].Map.Equals(tmpGrid))
                            {
                                inc = true; break;
                            }

                        if (!inc)
                        {
                            List<P> candidates = GetCandidatesP(puzzle, tmpGrid);
                            if (candidates.Count > 0) piece.Rotations.Add(new Rotation(tmpGrid, candidates));
                        }

                        Grid newGrid = new Grid(tmpGrid);
                        newGrid.Rotate();
                        tmpGrid = newGrid;
                    }
                }

                int p = RInt();
                for (int k = 0 ; k < p ; k++)
                {
                    Grid tmpPuzzle = new Grid(puzzle);
                    Console.WriteLine(CanComplete(tmpPuzzle, pieces, RIntAr().Skip(1).OrderByDescending(x => pieces[x].Rotations[0].Map.Size).ToArray()) ? "YES" : "NO");
                }
            }
#if DEBUG
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
#endif
        }

        private static bool CanComplete(Grid puzzle, Dictionary<int, Piece> pieces, int[] selected)
        {
            int puzzlesize = puzzle.H * puzzle.W - puzzle.Size;
            if (puzzlesize != selected.Select(x => pieces[x].Rotations[0].Map.Size).Sum()) return false;
            return CanSolvePuzzle(0, selected.Select(x => pieces[x]).ToArray(), puzzle);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_13_A
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int size = 8;

            int n = ReadInt();
            NQueen nq = new NQueen(size);
            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                nq.InitQueen(line[0], line[1]);
            }
            nq.Solve();

            for (int i = 0 ; i < size ; i++)
            {
                String[] res = Enumerable.Repeat(".", size).ToArray();
                res[nq.qs.Where(x => x.Row == i).First().Col] = "Q";
                Console.WriteLine(String.Join("",res));
            }
        }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }

    }

    public class NQueen
    {
        public struct Queen
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int XPlusY { get; set; }
            public int XminusY { get; set; }

            public Queen(int v1, int v2) : this()
            {
                Row = v1;
                Col = v2;
                XPlusY = v1 + v2;
                XminusY = v1 - v2;
            }
        }

        public List<Queen> qs;

        public NQueen(int v)
        {
            qs = new List<Queen>(8);
        }

        public void InitQueen(int v1, int v2)
        {
            qs.Add(new Queen(v1, v2));
        }

        public void Solve()
        {
            SetQueen(0);
        }

        private void SetQueen(int rowIdx)
        {
            if (rowIdx == qs.Capacity)
            {
                return;
            }
            else
            {
                if (qs.Any(x => x.Row == rowIdx))
                {
                    SetQueen(rowIdx + 1);
                }

                for (int colIdx = 0 ; colIdx < qs.Capacity ; colIdx++)
                {
                    if (CanPut(rowIdx, colIdx))
                    {
                        qs.Add(new Queen(rowIdx, colIdx));
                        SetQueen(rowIdx + 1);
                        if (qs.Count != qs.Capacity) RemoveQueen(rowIdx);
                    }
                }
            }
        }

        private void RemoveQueen(int i)
        {
            qs.Remove(qs.Where(x => x.Row == i).First());
        }

        private bool CanPut(int rowIdx, int colIdx)
        {
            return !qs.Any(x => x.Row == rowIdx ||
                                x.Col == colIdx ||
                                x.XPlusY == rowIdx + colIdx ||
                                x.XminusY == rowIdx - colIdx);
        }

    }


}

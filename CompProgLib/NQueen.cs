using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
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

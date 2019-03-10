using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0121
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int[] items = Array.ConvertAll(line.Trim().Split(' '), e => int.Parse(e));
                int[,] board = new int[2, 4] { { items[0], items[1], items[2], items[3] }, { items[4], items[5], items[6], items[7] } };
                NPuzzle np = new NPuzzle(2, 4);
                Console.WriteLine(np.FindShortestRange(board));
            }
        }
    }

    public class NPuzzle
    {
        public const int MAX_DISTANCE = 45;
        public int[,] move = new int[,] { { 0, 1 }, { -1, 0 }, { 0, -1 }, { 1, 0 } };//R,U,L,D
        public int VSize { get; private set; }
        public int HSize { get; private set; }

        public NPuzzle(int vSize, int hSize)
        {
            VSize = vSize;
            HSize = hSize;
        }

        public struct Node
        {

            public int[,] Board { get; private set; }
            public int Distance { get; private set; }
            public int EvaluationValue { get; private set; }
            public int BlankRow { get; private set; }
            public int BlankCol { get; private set; }

            public Node(int[,] board, int distance, int evaluationValue, int blankRow, int blankCol)
            {
                Board = board;
                Distance = distance;
                EvaluationValue = evaluationValue;
                BlankRow = blankRow;
                BlankCol = blankCol;
            }

            public Node(Node original)
            {
                Board = (int[,])original.Board.Clone();
                Distance = original.Distance;
                EvaluationValue = original.EvaluationValue;
                BlankRow = original.BlankRow;
                BlankCol = original.BlankCol;
            }



        }

        public int FindShortestRange(int[,] board)
        {
            return FindShortestRange_IDAStar(board);
        }

        private int FindShortestRange_IDAStar(int[,] board)
        {

            int bR = 0, bC = 0;
            for (int i = 0 ; i < VSize ; i++)
            {
                for (int j = 0 ; j < HSize ; j++)
                {
                    if (board[i, j] == 0) { bR = i; bC = j; }
                }
            }

            Node start = new Node(board, 0, GetEvaluationValue(board), bR, bC);

            for (int distance = start.EvaluationValue ; distance <= MAX_DISTANCE ; distance++)
            {
                Node StartingPoint = new Node(start);
                if (DFS(int.MinValue, StartingPoint, distance)) return distance;
            }
            return 0;

        }

        private bool DFS(int previous, Node tmp, int limit)
        {

            if (tmp.EvaluationValue == 0)
                return true;
            if (limit < tmp.Distance + tmp.EvaluationValue)
                return false;

            for (int i = 0 ; i < move.GetLength(0) ; i++)
            {
                int tRow = tmp.BlankRow + move[i, 0];
                int tCol = tmp.BlankCol + move[i, 1];

                if (!CanMove(tRow, tCol)) continue;
                if (Math.Max(previous, i) - Math.Min(previous, i) == 2) continue; //直前を戻す手筋は認めない

                int[,] newBoard = (int[,])tmp.Board.Clone();
                newBoard[tmp.BlankRow, tmp.BlankCol] = newBoard[tRow, tCol];
                newBoard[tRow, tCol] = 0;
                int evaluationValue = tmp.EvaluationValue;
                evaluationValue -= (Math.Abs((newBoard[tmp.BlankRow, tmp.BlankCol] ) / HSize - tRow) +
                                    Math.Abs((newBoard[tmp.BlankRow, tmp.BlankCol] ) % HSize - tCol));

                evaluationValue += (Math.Abs((newBoard[tmp.BlankRow, tmp.BlankCol] ) / HSize - tmp.BlankRow) +
                                    Math.Abs((newBoard[tmp.BlankRow, tmp.BlankCol] ) % HSize - tmp.BlankCol));

                if (DFS(i, new Node(newBoard, tmp.Distance + 1, evaluationValue, tRow, tCol), limit))
                { return true; }
            }

            return false;
        }

        private bool CanMove(int row, int col)
        {
            if (col < 0 || col > HSize - 1 || row < 0 || row > VSize - 1) return false;
            else return true;
        }

        private int GetEvaluationValue(int[,] board)
        {
            double res = 0;
            for (int i = 0 ; i < VSize ; i++)
            {
                for (int j = 0 ; j < HSize ; j++)
                {
                    if (board[i, j] != 0)
                    {
                        res += Math.Abs(board[i, j] / board.GetLength(1) - i);//縦方向
                        res += Math.Abs(board[i, j] % board.GetLength(1) - j);//横方向
                    }
                }
            }
            return (int)res;
        }

    }
}

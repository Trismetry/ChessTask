using System;

namespace ChessTask
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Input Row and Cell like 00");
            string input = Console.ReadLine();

            int start1 = int.Parse(input.Trim().Substring(0, 1));
            int start2 = int.Parse(input.Trim().Substring(1, 1));
            // Example start position
            int startRow = start1; // 0-based index
            int startCol = start2; // 0-based index

            // Initialize the board
            int[,] board = new int[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    board[i, j] = -1; // -1 signifies unvisited

            // Call BFS to populate the board
            BFS(startRow, startCol, board);

            // Print the board
            PrintBoard(board);
        }

        static void BFS(int startRow, int startCol, int[,] board)
        {
            // Knight moves
            int[] rowMoves = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] colMoves = { 1, 2, 2, 1, -1, -2, -2, -1 };

            // Queue for BFS
            Queue<(int row, int col, int jumps)> queue = new Queue<(int, int, int)>();
            queue.Enqueue((startRow, startCol, 0));
            board[startRow, startCol] = 0;

            while (queue.Count > 0)
            {
                var (currentRow, currentCol, jumps) = queue.Dequeue();

                for (int i = 0; i < 8; i++)
                {
                    int newRow = currentRow + rowMoves[i];
                    int newCol = currentCol + colMoves[i];

                    if (IsValidPosition(newRow, newCol) && board[newRow, newCol] == -1)
                    {
                        board[newRow, newCol] = jumps + 1;
                        queue.Enqueue((newRow, newCol, jumps + 1));
                    }
                }
            }
        }

        static bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }

        static void PrintBoard(int[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == -1)
                        Console.Write(" - "); // Unreachable square
                    else
                        Console.Write($" {board[i, j],2} ");
                }
                Console.WriteLine();
            }
        }
    }
}

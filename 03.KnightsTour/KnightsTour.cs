﻿namespace _03.KnightsTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class KnightsTour
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());
            int[,] board = new int[boardSize, boardSize];
            int row = 0;
            int col = 0;

            var possibleMoves = new[]
            {
                new {Row = 1, Col = 2},
                new {Row = -1, Col = 2},
                new {Row = 2, Col = 1},
                new {Row = 1, Col = -2},
                new {Row = -1, Col = -2},
                new {Row = -2, Col = 1},
                new {Row = 2, Col = -1},
                new {Row = -2, Col = -1},
            };

            int moves = 1;
            board[0, 0] = moves;

            while (true)
            {
                moves++;
                Dictionary<int[], int> movesFound = new Dictionary<int[], int>();
                foreach (var move in possibleMoves)
                {
                    int nextRow = row + move.Row;
                    int nextCol = col + move.Col;
                    if (nextRow >= 0 && nextCol >= 0 && nextRow < boardSize && nextCol < boardSize && board[nextRow, nextCol] == 0)
                    {
                        int movePossibleMoves = 0;
                        int tempRow;
                        int tempCol;
                        foreach (var subMove in possibleMoves)
                        {
                            tempRow = nextRow + subMove.Row;
                            tempCol = nextCol + subMove.Col;
                            if (tempRow >= 0 && tempCol >= 0 && tempRow < boardSize && tempCol < boardSize && board[tempRow, tempCol] == 0)
                            {
                                movePossibleMoves++;
                            }
                        }

                        movesFound.Add(new[] { nextRow, nextCol }, movePossibleMoves);
                    }
                }

                if (movesFound.Count == 0)
                {
                    break;
                }

                var sortedOptions = movesFound
                    .OrderBy(e => e.Value)
                    .First();

                row = sortedOptions.Key[0];
                col = sortedOptions.Key[1];
                board[row, col] = moves;
            }

            Print(boardSize, board);
        }

        private static void Print(int boardSize, int[,] board)
        {
            for (int r = 0; r < boardSize; r++)
            {
                for (int c = 0; c < boardSize; c++)
                {
                    Console.Write($"{board[r, c],4}");
                }

                Console.WriteLine();
            }
        }
    }
}
using System;

namespace P07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chessBoardSize = int.Parse(Console.ReadLine());
            int rows = chessBoardSize;
            int columns = chessBoardSize;
            char[,] chessBoard = CreateChessBoard(rows, columns);

            bool hasAttackingKnights = true;
            int removedKnightCounter = 0;

            while (hasAttackingKnights)
            {
                int maxAttack = 0;
                int currKnightAttackCount = 0;
                int[] maxAttackKnightCoordinates = new int[2];

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        if (chessBoard[row, col] == 'K')
                        {
                            currKnightAttackCount = GetAttack(chessBoard, row, col);
                        }

                        if (maxAttack < currKnightAttackCount)
                        {
                            maxAttack = currKnightAttackCount;
                            maxAttackKnightCoordinates[0] = row;
                            maxAttackKnightCoordinates[1] = col;

                        }
                    }
                }

                if (maxAttack == 0)
                {
                    hasAttackingKnights = false;
                    break;
                }

                else
                {
                    int row = maxAttackKnightCoordinates[0];
                    int col = maxAttackKnightCoordinates[1];
                    chessBoard[row, col] = '0';
                    removedKnightCounter++;
                }
            }

            Console.WriteLine(removedKnightCounter);
        }
        static int GetAttack(char[,] chessBoard, int row, int col)
        {
            int attackCounter = 0;

            if (IsInRange(chessBoard, row - 2, col + 1) && (chessBoard[row - 2, col + 1] == 'K'))
            {
                attackCounter++;
            }

            if (IsInRange(chessBoard, row - 1, col + 2) && (chessBoard[row - 1, col + 2] == 'K'))
            {
                attackCounter++;
            }

            if (IsInRange(chessBoard, row + 1, col + 2) && (chessBoard[row + 1, col + 2] == 'K'))
            {
                attackCounter++;
            }

            if (IsInRange(chessBoard, row + 2, col + 1) && (chessBoard[row + 2, col + 1] == 'K'))
            {
                attackCounter++;
            }

            if (IsInRange(chessBoard, row + 2, col - 1) && (chessBoard[row + 2, col - 1] == 'K'))
            {
                attackCounter++;
            }

            if (IsInRange(chessBoard, row + 1, col - 2) && (chessBoard[row + 1, col - 2] == 'K'))
            {
                attackCounter++;
            }

            if (IsInRange(chessBoard, row - 1, col - 2) && (chessBoard[row - 1, col - 2] == 'K'))
            {
                attackCounter++;
            }

            if (IsInRange(chessBoard, row - 2, col - 1) && (chessBoard[row - 2, col - 1] == 'K'))
            {
                attackCounter++;
            }

            return attackCounter;
        }

        static bool IsInRange(char[,] chessBoard, int row, int col)
        {
            if (row < 0 || row > chessBoard.GetLength(0) - 1 ||
                col > chessBoard.GetLength(1) - 1 || col < 0)
            {
                return false;
            }

            return true;
        }

        static char[,] CreateChessBoard(int rows, int columns)
        {
            char[,] chessBoard = new char[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                string currRowValues = Console.ReadLine();

                for (int col = 0; col < columns; col++)
                {
                    int index = col;
                    chessBoard[row, col] = currRowValues[index];
                }
            }

            return chessBoard;
        }
    }
}

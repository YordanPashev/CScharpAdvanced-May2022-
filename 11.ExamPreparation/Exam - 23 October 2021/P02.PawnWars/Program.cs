using System;
using System.Text;

namespace P02.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] chessBoard = CreateFieldWithPawns();
            int[] pawsPossition = FindPawsPossitions(chessBoard);
            bool isGameEnd = false;
            int whitePawnCurrRow = pawsPossition[0];
            int whitePawnCurrCol = pawsPossition[1];
            int blackPawnCurrRow = pawsPossition[2];
            int blackPawnCurrCol = pawsPossition[3];

            while (!isGameEnd)
            {
                if (CouldWhitePawnCapture(chessBoard, whitePawnCurrRow, whitePawnCurrCol))
                {
                    string coordinates = TakeCoordinates(blackPawnCurrRow, blackPawnCurrCol);
                    Console.WriteLine($"Game over! White capture on {coordinates}.");
                    isGameEnd = true;
                    continue;
                }

                chessBoard[whitePawnCurrRow, whitePawnCurrCol] = '-';
                whitePawnCurrRow--;
                chessBoard[whitePawnCurrRow, whitePawnCurrCol] = 'w';


                if (whitePawnCurrRow == 0)
                {
                    string coordinates = TakeCoordinates(whitePawnCurrRow, whitePawnCurrCol);
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinates}.");
                    isGameEnd = true;
                    continue;
                }

                if (CouldBlackPawnCapture(chessBoard, blackPawnCurrRow, blackPawnCurrCol))
                {
                    string coordinates = TakeCoordinates(whitePawnCurrRow, whitePawnCurrCol);
                    Console.WriteLine($"Game over! Black capture on {coordinates}.");
                    isGameEnd = true;
                    continue;
                }

                chessBoard[blackPawnCurrRow, blackPawnCurrCol] = '-';
                blackPawnCurrRow++;
                chessBoard[blackPawnCurrRow, blackPawnCurrCol] = 'b';


                if (blackPawnCurrRow == 7)
                {
                    string coordinates = TakeCoordinates(blackPawnCurrRow, blackPawnCurrCol);
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinates}.");
                    isGameEnd = true;
                    continue;
                }
            }

        }

        private static string TakeCoordinates(int pawnCurrRow, int pawnCurrCol)
        {
            StringBuilder resultInChessCorrdinationSystem = new StringBuilder();
            switch (pawnCurrCol)
            {
                case 0:
                    resultInChessCorrdinationSystem.Append('a');
                    break;
                case 1:
                    resultInChessCorrdinationSystem.Append('b');
                    break;
                case 2:
                    resultInChessCorrdinationSystem.Append('c');
                    break;
                case 3:
                    resultInChessCorrdinationSystem.Append('d');
                    break;
                case 4:
                    resultInChessCorrdinationSystem.Append('e');
                    break;
                case 5:
                    resultInChessCorrdinationSystem.Append('f');
                    break;
                case 6:
                    resultInChessCorrdinationSystem.Append('g');
                    break;
                case 7:
                    resultInChessCorrdinationSystem.Append('h');
                    break;
            }

            resultInChessCorrdinationSystem.Append(8 - pawnCurrRow);
            return resultInChessCorrdinationSystem.ToString();
        }

        private static bool CouldBlackPawnCapture(char[,] chessBoard, int blackawnCurrRow, int blackPawnCurrCol)
        {
            if (blackPawnCurrCol == 0 )
            {
                if (chessBoard[blackawnCurrRow + 1, blackPawnCurrCol + 1] == 'w')
                {
                    return true;
                }
            }

            else if (blackPawnCurrCol == 7)
            {
                if (chessBoard[blackawnCurrRow + 1, blackPawnCurrCol - 1] == 'w')
                {
                    return true;
                }
            }

            else if (chessBoard[blackawnCurrRow + 1, blackPawnCurrCol - 1] == 'w' || 
                     chessBoard[blackawnCurrRow + 1, blackPawnCurrCol + 1] == 'w')
            {
                return true;
            }

            return false;
        }

        private static bool CouldWhitePawnCapture(char[,] chessBoard, int whitePawnCurrRow, int whitePawnCurrCol)
        {

            if (whitePawnCurrCol == 0)
            {
                if (chessBoard[whitePawnCurrRow - 1, whitePawnCurrCol + 1] == 'b')
                {
                    return true;
                }
            }

            else if (whitePawnCurrCol == 7)
            {
                if (chessBoard[whitePawnCurrRow - 1, whitePawnCurrCol - 1] == 'b')
                {
                    return true;
                }
            }
            else if (chessBoard[whitePawnCurrRow - 1, whitePawnCurrCol + 1] == 'b' || 
                     chessBoard[whitePawnCurrRow - 1, whitePawnCurrCol - 1] == 'b')
            {
                return true;
            }

            return false;
        }

        private static int[] FindPawsPossitions(char[,] chessBoard)
        {
            int[] whitePawsCoordinates = new int[2];
            int[] blackPawsCoordinates = new int[2];

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (chessBoard[row, col] == 'w')
                    {
                        whitePawsCoordinates = new int[] { row, col };
                    }

                    if (chessBoard[row, col] == 'b')
                    {
                        blackPawsCoordinates = new int[] { row, col };
                    }
                }
            }

            return new int[4]
            {
                whitePawsCoordinates[0],
                whitePawsCoordinates[1],
                blackPawsCoordinates[0],
                blackPawsCoordinates[1]
            };
        }

        private static char[,] CreateFieldWithPawns()
        {
            char[,] chessBoard = new char[8, 8];

            for (int row = 0; row < 8; row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < 8; col++)
                {
                    int squareIndex = col;
                    chessBoard[row, col] = currRow[squareIndex];
                }
            }

            return chessBoard;
        }
    }
}

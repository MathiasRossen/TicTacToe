namespace TicTacToe.Services
{
    public class AI
    {
        public static char Symbol = 'O';

        public static char OppositeOfSymbol
        {
            get
            {
                if (Symbol == 'O')
                    return 'X';
                return 'O';
            }
        }


        private static int[,] CalculateValues(char[,] gameBoard)
        {
            int[,] boardValues = new int[3, 3]
            {
                { 1, 0, 1 },
                { 0, 2, 0 },
                { 1, 0, 1 }
            };

            for (int y = 0; y < 3; y++)
            {
                for(int x = 0; x < 3; x++)
                {
                    if(gameBoard[y, x] == Symbol)
                    {
                        boardValues = IncreaseAdjacent(boardValues, y, x);
                    }
                }
            }

            return boardValues;
        }

        private static int[,] IncreaseAdjacent(int[,] boardValues, int y, int x)
        {
            if (y - 1 >= 0)
            {
                boardValues[y - 1, x] += 1;
                if (x - 1 >= 0)
                    boardValues[y - 1, x - 1] += 1;
                if (x + 1 <= 2)
                    boardValues[y - 1, x + 1] += 1;
            }

            if (x - 1 >= 0)
                boardValues[y, x - 1] += 1;
            if (x + 1 <= 2)
                boardValues[y, x + 1] += 1;

            if (y + 1 <= 2)
            {
                boardValues[y + 1, x] += 1;
                if (x - 1 >= 0)
                    boardValues[y + 1, x - 1] += 1;
                if (x + 1 <= 2)
                    boardValues[y + 1, x + 1] += 1;
            }

            return boardValues;
        }

        public static string TakeTurn(char[,] gameBoard)
        {
            int newX = 0, newY = 0;
            int[,] boardValues = CalculateValues(gameBoard);

            if (CanWin(gameBoard, out newY, out newX))
            {

            }
            else if (CanBlock(gameBoard, out newY, out newX))
            {

            }
            else
            {
                DefaultMove(gameBoard, boardValues, out newY, out newX);
            }

            return ConvertTurnToPosition(newY, newX);
        }

        private static void DefaultMove(char[,] gameBoard, int[,] boardValues, out int highestY, out int highestX)
        {
            int highestVal = 0;
            highestX = 0;
            highestY = 0;

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (boardValues[y, x] > highestVal && gameBoard[y, x] == ' ')
                    {
                        highestVal = boardValues[y, x];
                        highestX = x;
                        highestY = y;
                    }
                }
            }
        }
        private static bool CanWin(char[,] gameBoard, out int y, out int x)
        {
            for (int i = 0; i < 3; i++)
            {
                if(i == 1)
                {
                    if (gameBoard[1, 1] == Symbol && gameBoard[0, 0] == Symbol && gameBoard[2, 2] == ' ')
                    {
                        y = 2;
                        x = 2;
                        return true;
                    }

                    if (gameBoard[1, 1] == Symbol && gameBoard[0, 2] == Symbol && gameBoard[2, 0] == ' ')
                    {
                        y = 2;
                        x = 0;
                        return true;
                    }

                    if (gameBoard[1, 1] == Symbol && gameBoard[2, 0] == Symbol && gameBoard[0, 2] == ' ')
                    {
                        y = 0;
                        x = 2;
                        return true;
                    }

                    if (gameBoard[1, 1] == Symbol && gameBoard[2, 2] == Symbol && gameBoard[0, 0] == ' ')
                    {
                        y = 0;
                        x = 0;
                        return true;
                    }
                }

                if (gameBoard[1, i] == Symbol && gameBoard[0, i] == Symbol && gameBoard[2, i] == ' ')
                {
                    y = 2;
                    x = i;
                    return true;
                }

                if (gameBoard[1, i] == Symbol && gameBoard[2, i] == Symbol && gameBoard[0, i] == ' ')
                {
                    y = 0;
                    x = i;
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[i, 1] == Symbol && gameBoard[i, 0] == Symbol && gameBoard[i, 2] == ' ')
                {
                    y = i;
                    x = 2;
                    return true;
                }

                if (gameBoard[i, 1] == Symbol && gameBoard[i, 2] == Symbol && gameBoard[i, 0] == ' ')
                {
                    y = i;
                    x = 0;
                }
            }

            y = 0;
            x = 0;
            return false;
        }

        private static bool CanBlock(char[,] gameBoard, out int y, out int x)
        {

            y = 0;
            x = 0;

            // Check vertically
            for (int i = 0; i <= 2; i++)
            {
                if (gameBoard[i, 1] == OppositeOfSymbol && gameBoard[i, 2] == OppositeOfSymbol && gameBoard[i, 0] == ' ') { y = i; x = 0; return true; }
                if (gameBoard[i, 0] == OppositeOfSymbol && gameBoard[i, 2] == OppositeOfSymbol && gameBoard[i, 1] == ' ') { y = i; x = 1; return true; }
                if (gameBoard[i, 0] == OppositeOfSymbol && gameBoard[i, 1] == OppositeOfSymbol && gameBoard[i, 2] == ' ') { y = i; x = 2; return true; }
            }

            // Check horizontally
            for (int i = 0; i <= 2; i++)
            {
                if (gameBoard[1, i] == OppositeOfSymbol && gameBoard[2, i] == OppositeOfSymbol && gameBoard[0, i] == ' ') { y = 0; x = i; return true; }
                if (gameBoard[0, i] == OppositeOfSymbol && gameBoard[2, i] == OppositeOfSymbol && gameBoard[1, i] == ' ') { y = 1; x = i; return true; }
                if (gameBoard[0, i] == OppositeOfSymbol && gameBoard[1, i] == OppositeOfSymbol && gameBoard[2, i] == ' ') { y = 2; x = i; return true; }
            }

            // Check diagonally top-left to bottom-right
            if (gameBoard[0, 0] == OppositeOfSymbol && gameBoard[1, 1] == OppositeOfSymbol && gameBoard[2, 2] == ' ') { y = 2; x = 2; return true; }
            if (gameBoard[0, 0] == OppositeOfSymbol && gameBoard[2, 2] == OppositeOfSymbol && gameBoard[1, 1] == ' ') { y = 1; x = 1; return true; }
            if (gameBoard[1, 1] == OppositeOfSymbol && gameBoard[2, 2] == OppositeOfSymbol && gameBoard[0, 0] == ' ') { y = 0; x = 0; return true; }

            // Check diagonally top-right to bottom-left
            if (gameBoard[0, 2] == OppositeOfSymbol && gameBoard[1, 1] == OppositeOfSymbol && gameBoard[2, 0] == ' ') { y = 2; x = 0; return true; }
            if (gameBoard[2, 0] == OppositeOfSymbol && gameBoard[1, 1] == OppositeOfSymbol && gameBoard[0, 2] == ' ') { y = 0; x = 2; return true; }
            if (gameBoard[0, 2] == OppositeOfSymbol && gameBoard[2, 0] == OppositeOfSymbol && gameBoard[1, 1] == ' ') { y = 1; x = 1; return true; }

            return false;

        }

        private static string ConvertTurnToPosition(int y, int x)
        {
            if (y == 0 && x == 0)
                return "1";

            if (y == 0 && x == 1)
                return "2";

            if (y == 0 && x == 2)
                return "3";

            if (y == 1 && x == 0)
                return "4";

            if (y == 1 && x == 1)
                return "5";

            if (y == 1 && x == 2)
                return "6";

            if (y == 2 && x == 0)
                return "7";

            if (y == 2 && x == 1)
                return "8";

            if (y == 2 && x == 2)
                return "9";

            return "";
        }
    }
}

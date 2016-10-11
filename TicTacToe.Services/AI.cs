namespace TicTacToe.Services
{
    public class AI
    {
        public static char Symbol = 'O';

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

        public static char[,] TakeTurn(char[,] gameBoard)
        {
            int highestX = 0, highestY = 0, highestVal = 0;
            int[,] boardValues = CalculateValues(gameBoard);

            for(int y = 0; y < 3; y++)
            {
                for(int x = 0; x < 3; x++)
                {
                    if (boardValues[y, x] > highestVal && gameBoard[y, x] == ' ')
                    {
                        highestVal = boardValues[y, x];
                        highestX = x;
                        highestY = y;
                    }
                }
            }

            int newX, newY;
            if(CanWin(gameBoard, out newY, out newX))
            {
                highestY = newY;
                highestX = newX;
            }

            gameBoard[highestY, highestX] = Symbol;

            return gameBoard;
        }

        private static bool CanWin(char[,] gameBoard, out int y, out int x)
        {
            for (int i = 0; i < 3; i++)
            {
                if(i == 1)
                {
                    if (gameBoard[1, 1] == Symbol && gameBoard[0, 0] == Symbol)
                    {
                        y = 2;
                        x = 2;
                        return true;
                    }

                    if (gameBoard[1, 1] == Symbol && gameBoard[0, 2] == Symbol)
                    {
                        y = 2;
                        x = 0;
                        return true;
                    }

                    if (gameBoard[1, 1] == Symbol && gameBoard[2, 0] == Symbol)
                    {
                        y = 0;
                        x = 2;
                        return true;
                    }

                    if (gameBoard[1, 1] == Symbol && gameBoard[2, 2] == Symbol)
                    {
                        y = 0;
                        x = 0;
                        return true;
                    }
                }

                if (gameBoard[1, i] == Symbol && gameBoard[0, i] == Symbol)
                {
                    y = 2;
                    x = i;
                    return true;
                }

                if (gameBoard[1, i] == Symbol && gameBoard[2, i] == Symbol)
                {
                    y = 0;
                    x = i;
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[i, 1] == Symbol && gameBoard[i, 0] == Symbol)
                {
                    y = i;
                    x = 2;
                    return true;
                }

                if (gameBoard[i, 1] == Symbol && gameBoard[i, 2] == Symbol)
                {
                    y = i;
                    x = 0;
                }
            }

            y = 0;
            x = 0;
            return false;
        }
    }
}

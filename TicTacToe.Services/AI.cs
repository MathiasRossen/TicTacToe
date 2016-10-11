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
            if (y - 1 > 0)
            {
                boardValues[y - 1, x] += 1;
                if(x - 1 > 0)
                    boardValues[y - 1, x - 1] += 1;
                if(x + 1 < 2)
                    boardValues[y - 1, x + 1] += 1;
            }

            if(x - 1 > 0)
                boardValues[y, x - 1] += 1;
            if(x + 1 > 2)
                boardValues[y, x + 1] += 1;

            if (y + 1 < 2)
            {
                boardValues[y + 1, x] += 1;
                if(x - 1 > 0)
                    boardValues[y + 1, x - 1] += 1;
                if(x + 1 < 2)
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

            gameBoard[highestY, highestX] = Symbol;

            return gameBoard;
        }
    }
}

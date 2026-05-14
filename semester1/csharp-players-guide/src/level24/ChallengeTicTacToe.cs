namespace CSharpPlayersGuide.level24;

internal class ChallengeTicTacToe : IExercise
{
    public void Run()
    {
        var game = new Game();
        game.Player1 = new Player("Player 1", GameObject.X);
        game.Player2 = new Player("Player 2", GameObject.O);
        game.GameStart();
    }

    enum GameObject
    {
        EMPTY, X, O,
    }

    class Game
    {
        public GameObject[,] GameBoard { get; private set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Game()
        {
            GameBoard = new GameObject[3, 3];
        }

        public void GameStart()
        {
            var currentPlayer = Player1;

            while (true)
            {
                DisplayBoard();
                Console.WriteLine($"It is {currentPlayer.PlayerName}'s turn.");

                if (!int.TryParse(Console.ReadLine(), out var userchoice))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                int x = 0, y = 0;
                bool validChoice = true;

                switch (userchoice)
                {
                    case 7: x = 0; y = 0; break;
                    case 8: x = 0; y = 1; break;
                    case 9: x = 0; y = 2; break;

                    case 4: x = 1; y = 0; break;
                    case 5: x = 1; y = 1; break;
                    case 6: x = 1; y = 2; break;

                    case 1: x = 2; y = 0; break;
                    case 2: x = 2; y = 1; break;
                    case 3: x = 2; y = 2; break;

                    default:
                        Console.WriteLine("Invalid choice");
                        validChoice = false;
                        break;
                }

                if (!validChoice)
                {
                    SwitchPlayer(ref currentPlayer);
                    continue;
                }

                if (GameBoard[x, y] != GameObject.EMPTY)
                {
                    Console.WriteLine("Cell already taken");
                    SwitchPlayer(ref currentPlayer);
                    continue;
                }

                GameBoard[x, y] = currentPlayer.Symbol;

                if (DidWin(currentPlayer.Symbol))
                {
                    DisplayBoard();
                    Console.WriteLine($"{currentPlayer.PlayerName} won!");
                    break;
                }

                if (!HasEmptyCells())
                {
                    DisplayBoard();
                    Console.WriteLine("Draw!");
                    break;
                }

                SwitchPlayer(ref currentPlayer);
            }
        }

        private void SwitchPlayer(ref Player currentPlayer)
        {
            currentPlayer = currentPlayer == Player1 ? Player2 : Player1;
        }

        private bool HasEmptyCells()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (GameBoard[i, j] == GameObject.EMPTY)
                        return true;

            return false;
        }

        private bool DidWin(GameObject symbol)
        {
            int size = 3;

            for (int i = 0; i < size; i++)
            {
                bool win = true;
                for (int j = 0; j < size; j++)
                    if (GameBoard[i, j] != symbol)
                        win = false;

                if (win) return true;
            }

            for (int j = 0; j < size; j++)
            {
                bool win = true;
                for (int i = 0; i < size; i++)
                    if (GameBoard[i, j] != symbol)
                        win = false;

                if (win) return true;
            }

            bool diag1 = true;
            bool diag2 = true;

            for (int i = 0; i < size; i++)
            {
                if (GameBoard[i, i] != symbol) diag1 = false;
                if (GameBoard[i, size - 1 - i] != symbol) diag2 = false;
            }

            return diag1 || diag2;
        }

        private void DisplayBoard()
        {
            Console.Clear();

            Console.WriteLine("   0   1   2");
            Console.WriteLine(" ┌───┬───┬───┐");

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i}│");

                for (int j = 0; j < 3; j++)
                {
                    string symbol = GameBoard[i, j] switch
                    {
                        GameObject.X => "X",
                        GameObject.O => "O",
                        _ => " "
                    };

                    Console.Write($" {symbol} │");
                }

                Console.WriteLine();

                if (i < 2)
                    Console.WriteLine(" ├───┼───┼───┤");
            }

            Console.WriteLine(" └───┴───┴───┘");
        }
    }

    class Player
    {
        public string PlayerName { get; private set; }
        public GameObject Symbol { get; private set; }

        public Player(string name, GameObject symbol)
        {
            PlayerName = name;
            Symbol = symbol;
        }
    }
}

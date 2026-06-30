namespace CSharpPlayersGuide.level35;

public class ExeptiGame : IExercise
{
    private static readonly Random rand = new Random();

    public int OaRaCo { get; private set; }
    public List<int> Guess { get; private set; }


    public ExeptiGame()
    {
        OaRaCo = rand.Next(0, 10);
        Guess = new List<int>();
    }


    public void Run()
    {
        try
        {
            while (true)
            {
                Console.Write("Player, enter a number (0-9): ");

                if (!int.TryParse(Console.ReadLine(), out int guess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                if (guess < 0 || guess > 9)
                {
                    Console.WriteLine("Number must be between 0 and 9.");
                    continue;
                }

                if (Guess.Contains(guess))
                {
                    Console.WriteLine("That number has already been chosen. Try again.");
                    continue;
                }

                Guess.Add(guess);

                if (guess == OaRaCo)
                {
                    throw new Exception("You found the oatmeal raisin cookie!");
                }

                Console.WriteLine("Chocolate chip! Keep going...");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("Game Over!");
            Console.WriteLine(ex.Message);
        }
    }
}
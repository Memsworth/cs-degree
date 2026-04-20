namespace CSharpPlayersGuide.Level11
{
    internal class ChallengeThePrototype : IExercise
    {
        public void Run()
        {
            var user1Input = 0;

            do
            {
                if (!int.TryParse(Console.ReadLine(), out user1Input))
                    continue;
            } while (user1Input < 0 || user1Input > 100);

            Console.Clear();
            Console.WriteLine("User 2, guess the number.");

            while (true)
            {
                Console.WriteLine("What is your next guess?");
                var user2Input = int.Parse(Console.ReadLine()!);

                if (user2Input > user1Input)
                    Console.WriteLine($"{user2Input} is too high");
                else if (user2Input < user1Input)
                    Console.WriteLine($"{user2Input} is too low");
                else
                {
                    Console.WriteLine("You guessed the number!");
                    break;
                }
            }
        }
    }
}

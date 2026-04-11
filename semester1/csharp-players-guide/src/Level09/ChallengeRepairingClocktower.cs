namespace CSharpPlayersGuide.Level09
{
    internal class ChallengeRepairingClocktower : IExercise
    {
        public void Run()
        {
            Console.WriteLine("Enter a number");
            int.TryParse(Console.ReadLine(), out int num);

            if (num % 2 == 0)
                Console.WriteLine("Tick");
            else if (num % 2 == 1)
                Console.WriteLine("Tok");

        }
    }
}

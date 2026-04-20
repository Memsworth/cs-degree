namespace CSharpPlayersGuide.Level03
{
    internal class ChallengeConsolasTelim : IExercise
    {
        public void Run()
        {
            Console.WriteLine("Bread is ready.");
            Console.WriteLine("Who is the bread for?");
            var userInput = Console.ReadLine();

            Console.WriteLine($"Noted. {userInput} got the bread.");
        }
    }
}

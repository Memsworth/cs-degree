namespace CSharpPlayersGuide.level08
{
    internal class ChallengeDefenseOfConsolas : IExercise
    {
        public void Run()
        {
            Console.Title = "Defense of Consolas";

            Console.Write("Target Row? ");
            var row = int.Parse(Console.ReadLine());


            Console.Write("Target Column? ");
            var col = int.Parse(Console.ReadLine());

            Console.WriteLine("Deploy to: ");


            Console.Beep();

            Console.WriteLine($"({row}, {col - 1})");
            Console.WriteLine($"({row - 1}, {col})");
            Console.WriteLine($"({row}, {col + 1})");
            Console.WriteLine($"({row + 1}, {col})");

        }
    }
}
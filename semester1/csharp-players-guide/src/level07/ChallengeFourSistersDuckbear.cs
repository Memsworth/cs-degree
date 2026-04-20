namespace CSharpPlayersGuide.Level07
{
    internal class ChallengeFourSistersDuckbear : IExercise
    {
        public void Run()
        {
            Console.WriteLine("Choco Eggs gathered: ");
            var chocoEggCount = int.Parse(Console.ReadLine()!);

            int eggPersister = chocoEggCount / 4;

            var remainderEggCountForDuck = eggPersister % 4;


            Console.WriteLine($"Each sister gets: {eggPersister} choco eggs");
            Console.WriteLine($"Duckbear gets: {remainderEggCountForDuck} choco eggs");
        }
    }
}

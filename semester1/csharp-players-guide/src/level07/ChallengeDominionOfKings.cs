namespace CSharpPlayersGuide.level07
{
    internal class ChallengeDominionOfKings : IExercise
    {
        public void Run()
        {
            Console.WriteLine("Enter provinces: ");
            var provInput = Console.ReadLine();

            Console.WriteLine("Enter duchies: ");
            var duchiesInput = Console.ReadLine();

            Console.WriteLine("Enter estaes: ");
            var estatesInput = Console.ReadLine();


            const int estatePoint = 1;
            const int duchiesPoint = 3;
            const int provPoint = 6;



            var total = (int.Parse(estatesInput) * estatePoint) + (int.Parse(duchiesInput) * duchiesPoint) + (int.Parse(provInput) * provPoint);
            Console.WriteLine($"total points = {total}");
        }
    }
}
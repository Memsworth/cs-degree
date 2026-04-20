namespace CSharpPlayersGuide.Level07
{
    internal class ChallengeTriangleFarmer : IExercise
    {
        public void Run()
        {
            Console.WriteLine("Enter a base: ");
            var baseInput = float.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter a height: ");
            var height = float.Parse(Console.ReadLine()!);


            var area = (baseInput * height) / 2;

            Console.WriteLine($"Area: {area:F2}");
        }
    }
}

namespace CSharpPlayersGuide.Level09
{
    internal class ChallengeWatchtower : IExercise
    {
        public void Run()
        {
            Console.WriteLine("Enter X:");
            var x = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter X:");
            var y = int.Parse(Console.ReadLine());

            if (x == 0 && y == 0)
                Console.WriteLine("Enemy is at your position!");
            else if (x == 0 && y > 0)
                Console.WriteLine("Enemy is above you.");
            else if (x == 0 && y < 0)
                Console.WriteLine("Enemy is below you.");
            else if (x > 0 && y == 0)
                Console.WriteLine("Enemy is to your right.");
            else if (x < 0 && y == 0)
                Console.WriteLine("Enemy is to your left.");
            else if (x > 0 && y > 0)
                Console.WriteLine("Enemy is to the top-right.");
            else if (x < 0 && y > 0)
                Console.WriteLine("Enemy is to the top-left.");
            else if (x > 0 && y < 0)
                Console.WriteLine("Enemy is to the bottom-right.");
            else if (x < 0 && y < 0)
                Console.WriteLine("Enemy is to the bottom-left.");
        }
    }
}

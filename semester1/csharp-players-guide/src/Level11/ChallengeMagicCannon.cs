namespace CSharpPlayersGuide.Level11
{
    internal class ChallengeMagicCannon : IExercise
    {
        public void Run()
        {
            for (int i = 1; i < 101; i++)
            {
                string text = "Normal";

                if (i % 3 == 0 && i % 5 == 0)
                {
                    text = "Electric and Fire";
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (i % 3 == 0)
                {
                    text = "Fire";
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (i % 5 == 0)
                {
                    text = "Electric";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                    Console.ResetColor();

                Console.WriteLine($"{i}: {text}");
                Console.ResetColor();
            }
        }
    }
}

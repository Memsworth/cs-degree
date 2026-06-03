namespace CSharpPlayersGuide.level36
{
    internal class ChallengeTheSieve : IExercise
    {
        public void Run()
        {
            Console.WriteLine("Choose a filter:");
            Console.WriteLine("1 - Even Numbers");
            Console.WriteLine("2 - Positive Numbers");
            Console.WriteLine("3 - Multiples of 10");

            string? choice = Console.ReadLine();
            Func<int, bool> filter = choice switch
            {
                "1" => IsEven,
                "2" => IsPositive,
                "3" => IsMultipleOfTen,
                _ => IsEven
            };

            Sieve sieve = new Sieve(filter);



            while (true)
            {
                Console.Write("Enter a number (or q to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    break;

                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Invalid number.");
                    continue;
                }

                Console.WriteLine(sieve.IsGood(number)
                        ? "Good"
                        : "Bad");
            }
        }


        private bool IsEven(int number) => number % 2 == 0;
        private bool IsPositive(int number) => number > 0;
        private bool IsMultipleOfTen(int number) => number % 10 == 0;
        
        public class Sieve
        {
            public bool IsGood(int number) => Filter(number);
            public Func<int, bool> Filter { get; set; }
            public Sieve(Func<int, bool> func)
            {
                Filter = func;
            }
        }
    }
}

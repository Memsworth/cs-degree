namespace CSharpPlayersGuide.level32;

    internal class ChallengeHuntingManticore : IExercise
    {
        public int ManticoreHealthPoints { get; private set; } = MAX_MANTICORE_HP;
        public int CityHealthPoints { get; private set; } = MAX_CITY_HP;
        public int ManticoreLocation { get; set; }
        private static readonly Random rand = new Random();
        private const int MIN_RANGE = 1;
        private const int MAX_RANGE = 100;
        private const int MAX_MANTICORE_HP = 10;
        private const int MAX_CITY_HP = 15;

        public ChallengeHuntingManticore()
        {
            ManticoreLocation = rand.Next(MIN_RANGE, MAX_RANGE);
        }
        public void Run()
        {
            var currentRound = 1;
            var currentDamage = 1;

            Console.WriteLine("Player 1, it is your turn.");


            while (true)
            {
                Console.WriteLine($"STATUS: Round: {currentRound} City: {CityHealthPoints}/{MAX_CITY_HP} Manticore: {ManticoreHealthPoints}/{MAX_MANTICORE_HP}");

                if (currentRound % 3 == 0 && currentRound % 5 == 0)
                    currentDamage = 10;
                else if (currentRound % 3 == 0)
                    currentDamage = 3;
                else if (currentRound % 5 == 0)
                    currentDamage = 3;
                else
                    currentDamage = 1;

                Console.WriteLine($"The cannon is expected to deal {currentDamage} damage this round.");

                var playerTwoInput = AskForNumberInRange("Enter desired cannon range", MIN_RANGE, MAX_RANGE);


                if (playerTwoInput > ManticoreLocation)
                    Console.WriteLine("That round OVERSHOT the target.");
                else if (playerTwoInput < ManticoreLocation)
                    Console.WriteLine("That round FELL SHORT of the target.");
                else
                {
                    ManticoreHealthPoints -= currentDamage;
                    Console.WriteLine("That round was a DIRECT HIT!");
                }

                CityHealthPoints--;
                currentRound++;

                if (CityHealthPoints <= 0 && ManticoreHealthPoints <= 0)
                {
                    Console.WriteLine("Manticore defeated. But at what cost?");
                    break;
                }
                else if (CityHealthPoints <= 0)
                {
                    Console.WriteLine("They won");
                    break;
                }
                else if (ManticoreHealthPoints <= 0)
                {
                    Console.WriteLine("You won");
                    break;
                }
            }
        }


        private int AskForNumberInRange(string text, int min, int max)
        {
            var result = 0;
            while (true)
            {
                Console.WriteLine($"{text} ");
                if (int.TryParse(Console.ReadLine(), out result))
                    if (result > min && result < max)
                        break;
            }
            return result;
        }
    }
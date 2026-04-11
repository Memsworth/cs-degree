namespace CSFundamentals.Sedgewick.Chapter1.Section4
{
    internal class Exercise4_22 : IExercise
    {
        public void Run(string[] args)
        {
            var frequencies = new int[13];
            for (int i = 1; i <= 6; i++)
                for (int j = 1; j <= 6; j++)
                    frequencies[i + j]++;

            var probabilities = new double[13];
            for (int k = 1; k <= 12; k++)
                probabilities[k] = frequencies[k] / 36.0;

            var trials = 100000;
            var simulation = new int[13];
            var rand = new Random();
            var trialFrequency = new int[13];

            for (int k = 0;  k < trials; k++)
            {
                var dice1 = rand.Next(1, 7);
                var dice2 = rand.Next(1, 7);
                trialFrequency[dice1 + dice2]++;
            }

            for (int k = 1; k <= 12; k++)
            {
                var empiricalVal = (double)trialFrequency[k] / trials;
                Console.WriteLine($"{k}: Empirical: {empiricalVal:F3}\t Base Probability: {probabilities[k]:F3}");
            }
        }
    }
}

namespace CSFundamentals.Sedgewick.Chapter1.Section4
{
    internal class Exercise4_26 : IExercise
    {
        private static Random rand = new Random();
        public void Run(string[] args)
        {
            var numOfSongs = int.Parse(args[0]);
            Console.WriteLine($"Current songs = {numOfSongs}");

            var numOfTrials = 10000;
            var count = 0;
            for (int i = 0; i < numOfTrials; i++)
            {
                if (Trial(numOfSongs))
                    count++;
            }

            var estimate = (double)count / numOfTrials;
            Console.WriteLine($"Estimate = {estimate}");
        }

        private bool Trial(int numOfSongs)
        {
            var array1 = new int[numOfSongs];
            for (int i = 0; i < numOfSongs; i++)
                array1[i] = i;
            ShuffleArray(array1);

            for (int i = 0; i < array1.Length - 1; i++)
            {
                if (array1[i] + 1 == array1[i + 1])
                    return false;
            }

            return true;
        }

        private void ShuffleArray(int[] array1)
        {
            for (int i = array1.Length - 1; i > 0; i--)
            {
                var j = rand.Next(0, i + 1);

                var temp = array1[i];
                array1[i] = array1[j];
                array1[j] = temp;
            }
        }
    }
}

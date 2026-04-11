namespace CSFundamentals.Sedgewick.Chapter1.Section4
{
    internal class Exercise4_28 : IExercise
    {
        private static Random rand = new Random();
        public void Run(string[] args)
        {
            var inputNumber = int.Parse(args[0]);

            var array = new int[inputNumber];

            for (int i = 0; i < array.Length; i++)
                array[i] = i;

            ShuffleArray(array);

            var inversePerm = GetInverse(array);

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


        private int[] GetInverse(int[] array)
        {
            var inversePerm = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
                inversePerm[array[i]] = i;

            return inversePerm;
        }
    }
}

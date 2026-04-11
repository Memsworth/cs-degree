namespace CSFundamentals.Sedgewick.Chapter1.Section4
{
    internal class Exercise4_15 : IExercise
    {
        public void Run(string[] args)
        {
            var rand = new Random();

            var baseScope = rand.Next(1,10);
            var baseArray = new int[baseScope, baseScope];

            for (int i = 0; i < baseArray.GetLength(0); i++)
                for (int j = 0; j < baseArray.GetLength(1); j++)
                    baseArray[i, j] = rand.Next(10);

            PrintArray(baseArray, "A");
            Console.WriteLine();

            TransposeArray(baseArray);

            PrintArray(baseArray, "B");
            Console.WriteLine();
        }

        private void TransposeArray(int[,] array)
        {

            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = i+1; j < array.GetLength(1); j++)
                {
                    var temp = array[i, j];
                    array[i, j] = array[j, i];
                    array[j, i] = temp;
                }
            }


        }

        private void PrintArray(int[,] arrayA, string arrayName)
        {
            System.Console.WriteLine($"Array {arrayName}: ");
            for (int i = 0; i < arrayA.GetLength(0); i++)
            {
                for (int j = 0; j < arrayA.GetLength(1); j++)
                {
                    System.Console.Write($" {arrayA[i, j]} ");
                }
                System.Console.WriteLine();
            }
        }
    }
}

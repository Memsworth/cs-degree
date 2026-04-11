namespace CSFundamentals.Sedgewick.Chapter1.Section4
{
    internal class Exercise4_14 : IExercise
    {
        public void Run(string[] args)
        {

            var rand =  new Random();

            var baseArray = new int[rand.Next(1, 10), rand.Next(1,10)];

            for (int i = 0; i < baseArray.GetLength(0); i++)
            {
                for (int j = 0; j < baseArray.GetLength(1); j++)
                {
                    baseArray[i, j] = rand.Next(10);

                }
            }

            var newArray = TransposeArray(baseArray);

            PrintArray(baseArray, "A");
            Console.WriteLine();

            PrintArray(newArray, "B");
            Console.ReadKey();
        }


        private int[,] TransposeArray(int[,] array)
        {
            var newArray = new int[array.GetLength(1), array.GetLength(0)];

            for(var i = 0; i< array.GetLength(1); i++)
            {
                for (var j = 0; j < array.GetLength(0); j++)
                {
                    newArray[i, j] = array[j, i];
                }
            }

            return newArray;
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

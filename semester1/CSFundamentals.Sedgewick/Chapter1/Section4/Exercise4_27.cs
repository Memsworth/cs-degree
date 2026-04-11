namespace CSFundamentals.Sedgewick.Chapter1.Section4
{
    internal class Exercise4_27 : IExercise
    {
        private static Random rand = new Random();
        public void Run(string[] args)
        {
            var firstNumberN = int.Parse(args[0]);
            var secondNumberM = int.Parse(args[1]);

            var array = new int[firstNumberN];

            for (int i = 0; i < firstNumberN; i++)
                array[i] = i;


            ShuffleArray(array);

            var oneDMinVal = array[0];

            var singleArraySmallCount = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (oneDMinVal > array[i])
                {
                    oneDMinVal = array[i];
                    singleArraySmallCount++;
                }
            }



            var array2 = new int[secondNumberM, firstNumberN];


            for (int i = 0; i < secondNumberM; i++)
            {
                var count = 0;
                for (int j = 0; j < firstNumberN; j++)
                {
                    array2[i, j] = count++;
                }
            }

            ShuffleArray(array2);

            var minimaCountFor2d = 0;
            for (int i = 0; i < array2.GetLength(0); i++)
            {
                minimaCountFor2d++;
                var minimaVal = array2[i, 0];
                for (int j = 1; j < array2.GetLength(1); j++)
                {
                    if (minimaVal > array2[i, j])
                    {
                        minimaVal = array2[i, j];
                        minimaCountFor2d++;
                    }
                }
            }


            Console.WriteLine($"Single array count = {singleArraySmallCount}");
            Console.WriteLine($"Two D array minima count = {minimaCountFor2d / secondNumberM}");

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


        private void ShuffleArray(int[,] array1)
        {
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = array1.GetLength(1) - 1; j > 0; j--)
                {
                    var k = rand.Next(0, j + 1);
                    var temp = array1[i, j];
                    array1[i, j] = array1[i, k];
                    array1[i, k] = temp;
                }
            }
        }
    }
}


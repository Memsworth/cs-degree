namespace CSFundamentals.Sedgewick.Chapter1.Section4
{
    internal class Exercise4_16 : IExercise
    {
        public void Run(string[] args)
        {
            var len = int.Parse(args[0]);
            var isPrime = new bool[len];
            var baseArray = new bool[len, len];

            for (var i = 0; i < isPrime.GetLength(0); i++)
            {
                isPrime[i] = true;
            }

            for (var i = 0; i < baseArray.GetLength(0); i++)
            {
                for (var j = 0; j < baseArray.GetLength(0); j++)
                {
                    baseArray[i, j] = true;
                }
            }



            for (var i = 2; i * i < len; i++)
            {
                if (isPrime[i])
                {
                    for (var j = i * i; j < len; j += i)
                        isPrime[j] = false;
                }
            }

            for (var prime = 2; prime < len; prime++)
            {
                if (isPrime[prime])
                {
                    for (int i = prime; i < len; i += prime)
                    {
                        for (int j = prime; j < len; j += prime)
                        {
                            baseArray[i, j] = false;
                        }
                    }
                }
            }


            for (int i = 0; i < len; i++)
            {
                baseArray[0, i] = (i == 1);
                baseArray[i, 0] = (i == 1);
            }

            for (int i = 0; i < len; i++)
            {
                baseArray[1, i] = true; 
                baseArray[i, 1] = true;
            }


            for (var i = 0; i < baseArray.GetLength(0); i++)
            {
                for (var j = 0; j < baseArray.GetLength(0); j++)
                {
                    if (baseArray[i, j])
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}

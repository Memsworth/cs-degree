namespace CSFundamentals.Sedgewick.Chapter1.Section4
{
    internal class Exercise4_6 : IExercise
    {
        public void Run(string[] args)
        {
            if(!ValidateInput(args))
                return;

            var rand = new Random();
            var row = int.Parse(args[0]);
            var col = int.Parse(args[1]);
            var testArray = new bool[row, col];

            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < col; j++)
                {
                    var item = rand.NextDouble();
                    if(item > 0.50)
                        testArray[i, j] = true;
                }
            }

            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < col; j++)
                {
                    if (testArray[i, j])
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

        private bool ValidateInput(string[] args)
        {
            if (!int.TryParse(args[0], out var indexRow) && indexRow < 0)
            {
                Console.WriteLine("invalid number");
                return false;
            }

            if (!int.TryParse(args[1], out var indexCol) && indexCol < 0)
            {
                Console.WriteLine("invalid number");
                return false;
            }

            return true;
        }
    }
}

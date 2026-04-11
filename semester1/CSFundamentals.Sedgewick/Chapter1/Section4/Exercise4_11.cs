namespace CSFundamentals.Sedgewick.Chapter1.Section4
{
    internal class Exercise4_11 : IExercise
    {
        public void Run(string[] args)
        {
            HowMany(args);
        }

        private void HowMany(string[] args)
        {
            Console.WriteLine($"arugment len: {args.Length}");
        }
    }
}

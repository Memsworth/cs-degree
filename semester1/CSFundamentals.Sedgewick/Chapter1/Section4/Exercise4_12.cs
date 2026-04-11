using System;
using System.Collections.Generic;
using System.Text;

namespace CSFundamentals.Sedgewick.Chapter1.Section4
{
    internal class Exercise4_12 : IExercise
    {
        public void Run(string[] args)
        {
            var intArray = new int[args.Length];
            var sumDistribution = 0;
            var currentIndex = 0;

            foreach (var arg in args)
            {
                intArray[currentIndex++] = int.Parse(arg);
                sumDistribution += int.Parse(arg);
            }

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine($"{intArray[i]} = {intArray[i]/sumDistribution}");
            }
        }
    }
}

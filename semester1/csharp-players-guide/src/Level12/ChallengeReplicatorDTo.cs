using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayersGuide.Level12
{
    internal class ChallengeReplicatorDTo : IExercise
    {
        public void Run()
        {
            int[] original = new int[5];

            Console.WriteLine("Enter 5 numbers:");

            for (int i = 0; i < original.Length; i++)
            {
                Console.Write($"Number {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out original[i]))
                {
                    Console.Write("Invalid input, try again: ");
                }
            }

            int[] copy = new int[5];

            for (int i = 0; i < original.Length; i++)
                copy[i] = original[i];

            Console.WriteLine("\nOriginal array:");
            for (int i = 0; i < original.Length; i++)
                Console.WriteLine(original[i]);

            Console.WriteLine("\nCopied array:");
            for (int i = 0; i < copy.Length; i++)
                Console.WriteLine(copy[i]);
        }
    }
}

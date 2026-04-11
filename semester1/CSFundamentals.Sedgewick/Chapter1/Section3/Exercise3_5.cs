using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section3;

/*
 * Roll Loaded Die
 *
 * Write a program RollLoadedDie that prints the result of rolling a loaded die.
 * The die is loaded such that the probability of getting a 1, 2, 3, 4, or 5 is 1/8 each,
 * and the probability of getting a 6 is 3/8.
 *
 * Your program should:
 *   - Simulate rolling a loaded six-sided die.
 *   - Print the outcome of the roll (an integer from 1 to 6).
 *   - Ensure that the probabilities of each face match the specification.
 *
 * Example Output (possible results):
 *   1
 *   3
 *   6
 *   5
 */

public class Exercise3_5 : IExercise
{
    public void Run(string[] args)
    {
        var rand = new Random();

        var roll = rand.NextDouble();
        int dieRoll;

        if (roll > 0.0 && roll < 0.125)
            dieRoll = 1;

        else if (roll > 0.125 && roll < 0.25)
            dieRoll = 2;

        else if (roll > 0.25 && roll < 0.375)
            dieRoll = 3;


        else if (roll > 0.375 && roll < 0.5)
            dieRoll = 4;

        else if (roll > 0.5 && roll < 0.625)
            dieRoll = 5;

        else
            dieRoll = 6;

        System.Console.WriteLine($"{dieRoll}");
    }
}

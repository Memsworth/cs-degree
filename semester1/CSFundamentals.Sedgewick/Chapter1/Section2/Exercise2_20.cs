using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Write a program that prints the sum of two random integers between 1 and 6
 * (such as you might get when rolling two dice).
 *
 * Note:
 *   Each random integer should be between 1 and 6, inclusive.
 *   The program should generate two separate random numbers, then print their sum.
 *
 * Example:
 *   Output: 9   (if the random numbers were 4 and 5)
 *
 *   Output: 3   (if the random numbers were 1 and 2)
 */

public class Exercise2_20
{
    public Exercise2_20() { }

    public void Run()
    {
        var seed = new Random();
        var diceOne = seed.Next(1, 7);
        var diceTwo = seed.Next(1, 7);

        System.Console.WriteLine($"Dice one: {diceOne} \nDice Two: {diceTwo}");
        System.Console.WriteLine($"You rolled: {diceOne+diceTwo}");
    }
}

using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Write a program that takes two integer command-line arguments a and b,
 * and prints a random integer between a and b, inclusive.
 *
 * Note:
 *   The output should include both a and b as possible values.
 *   If a > b, the program should still work by swapping the values if needed.
 *
 * Example:
 *   Input:  5 10
 *   Output: 7   (any number from 5 to 10 inclusive)
 *
 *   Input:  20 15
 *   Output: 16  (any number from 15 to 20 inclusive)
 */

public class Exercise2_19
{
    public Exercise2_19() { }
    
    public void Run(int arg1, int arg2)
    {
        int randomPick;
        var seed = new Random();

        if (arg2 > arg1)
            randomPick = seed.Next(arg1, arg2+1);
        else
            randomPick = seed.Next(arg2, arg1+1);

        System.Console.WriteLine(randomPick);
    }

}

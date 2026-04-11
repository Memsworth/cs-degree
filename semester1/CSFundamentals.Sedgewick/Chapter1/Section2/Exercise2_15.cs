namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Write a program that takes three positive integers as command-line arguments
 * and prints false if any one of them is greater than or equal to the sum
 * of the other two, and true otherwise.
 *
 * Note:
 *   This computation tests whether the three numbers could be the lengths
 *   of the sides of some triangle (Triangle Inequality Theorem).
 *
 * Example:
 *   Input:  3 4 5
 *   Output: True   (valid triangle)
 *
 *   Input:  2 3 10
 *   Output: False  (10 >= 2 + 3, so cannot form a triangle)
 */

public class Exercise2_15
{
    public Exercise2_15() { }

    public void Run(int arg1, int arg2, int arg3)
    {
        var result = ((arg1 >= arg2 + arg3) || (arg2 >= arg1 + arg3) || (arg3 >= arg1 + arg2));
        System.Console.WriteLine(result ? "False" : "True");
    } 
}

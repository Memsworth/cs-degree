using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section3;

/*
 * Quadratic Equation Solver
 *
 * Write a program that takes three numeric command-line arguments
 * representing the coefficients a, b, and c of a quadratic polynomial ax^2 + bx + c,
 * and prints the roots of the polynomial.
 *
 * Your program should:
 *   - Accept three numeric command-line arguments: a, b, and c.
 *   - Handle the case where a is zero (i.e., the equation is linear, bx + c = 0).
 *   - Calculate the discriminant (b^2 - 4ac) when a is not zero.
 *   - Print both real roots if the discriminant is non-negative.
 *   - Print an appropriate message if the discriminant is negative (no real roots).
 *   - Avoid division by zero in all cases.
 *
 * Examples:
 *   Input:  a = 1, b = -3, c = 2
 *   Output: Roots are 2 and 1
 *
 *   Input:  a = 1, b = 2, c = 5
 *   Output: No real roots (discriminant is negative)
 *
 *   Input:  a = 0, b = 2, c = -4
 *   Output: Single root is 2
 *
 *   Input:  a = 0, b = 0, c = 3
 *   Output: Not a valid equation (a and b cannot both be zero)
 */

public class Exercise3_2 : IExercise
{
    public void Run(string[] args)
    {
        int a = int.Parse(args[0]);
        int b = int.Parse(args[1]);
        int c = int.Parse(args[2]);

        double epsilon = 1e-12;

        if (Math.Abs(a) < epsilon)
        {
            if (Math.Abs(b) < epsilon)
            {
                if (Math.Abs(c) < epsilon)
                {
                    System.Console.WriteLine("infinate solutions");
                    return;
                }
                else
                {
                    System.Console.WriteLine("No solutions");
                    return;
                }
            }

            var root = (double)-(c / b);
            System.Console.WriteLine($"There's only one root: {root:F3}");
            return;
        }
        else
        {
            double discriminant = Math.Pow(b, 2) - (4 * a * c);
            if (discriminant < epsilon)
                discriminant = 0;

            if (discriminant < 0)
            {
                System.Console.WriteLine("Complex & has no real roots");
                return;
            }
            else if (Math.Abs(discriminant) < epsilon)
            {
                System.Console.WriteLine("One root");
                System.Console.WriteLine(-b / (2 * a));
                return;
            }
            else
            {
                System.Console.WriteLine("Two roots");
                System.Console.WriteLine((-b + Math.Sqrt(discriminant)) / (2 * a));
                System.Console.WriteLine((-b - Math.Sqrt(discriminant)) / (2 * a));
            }

        }
    }
}

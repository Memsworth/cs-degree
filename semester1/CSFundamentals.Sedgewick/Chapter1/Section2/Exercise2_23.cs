using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Write a program that takes two integer command-line arguments m and d
 * and prints true if day d of month m is between 3/20 and 6/20 (inclusive),
 * and false otherwise.
 *
 * Note:
 *   - m is the month (1 to 12), and d is the day (1 to 31, depending on the month).
 *   - The range from 3/20 to 6/20 corresponds to the beginning of spring to the beginning of summer.
 *   - The comparison should treat the date as a month/day pair.
 *
 * Example:
 *   Input: 3 20
 *   Output: True
 *
 *   Input: 6 21
 *   Output: False
 *
 *   Input: 5 15
 *   Output: True
 */
 
public class Exercise2_23
{
    public Exercise2_23() { }

    public void Run(string[] args)
    {
        var date = int.Parse(args[0]);
        var month = int.Parse(args[1]);
        var validDate = true;
        if (month > 6 || month < 3)
        {
            validDate = false;
        }
        if (date < 20 && month == 3)
        {
            validDate = false;
        }
        if (date < 1)
        {
            validDate = false;
        }
        if ((month == 3 || month == 5) && date > 31)
        {
            validDate = false;
        }

        if ((month == 4 && date > 31) || (month == 6 && date > 20))
        {
            validDate = false;
        }

        var expression = $"{date}/{month}";

        if (validDate)
        {
            expression += " is valid";
        }
        else
        {
            expression += " isn't valid";
        }

        System.Console.WriteLine($"{expression}");
    }
}

using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * RGB to CMYK Conversion
 *
 * Write a program that converts RGB color values to CMYK format.
 * RGB (Red, Green, Blue) is an additive color model commonly used for displays,
 * where each component (r, g, b) is an integer between 0 and 255.
 *
 * CMYK (Cyan, Magenta, Yellow, Black) is a subtractive color model used in printing,
 * where each component (c, m, y, k) is a real number between 0.0 and 1.0.
 *
 * The program should accept three integer command-line arguments:
 *   - r: red component (0–255)
 *   - g: green component (0–255)
 *   - b: blue component (0–255)
 *
 * The conversion formulas are as follows:
 *   - If r = g = b = 0, then:
 *       c = 0, m = 0, y = 0, k = 1
 *   - Otherwise:
 *       w = max(r / 255, g / 255, b / 255)
 *       c = (w - (r / 255)) / w
 *       m = (w - (g / 255)) / w
 *       y = (w - (b / 255)) / w
 *       k = 1 - w
 *
 * Example:
 *   Input: 0 255 255
 *   Output: C = 1.000  M = 0.000  Y = 0.000  K = 0.000
 *
 *   Input: 255 255 255
 *   Output: C = 0.000  M = 0.000  Y = 0.000  K = 0.000
 *
 *   Input: 102 204 255
 *   Output: C = 0.600  M = 0.200  Y = 0.000  K = 0.000
 */

public class Exercise2_32
{
    public Exercise2_32() { }

    public void Run(string[] args)
    {
        var red = int.Parse(args[0]);
        var green = int.Parse(args[1]);
        var blue = int.Parse(args[2]);
        double C, M, Y, K;

        if (red == 0 && green == 0 && blue == 0)
        {
            C = 0;
            M = 0;
            Y = 0;
            K = 1;
            System.Console.WriteLine($"C={C:F3} M={M:F3} Y={Y:F3} K={K:F3}");
            return;
        }
        var rgb = new double[] { red / 255.0, green / 255.0, blue / 255.0 };
        double W = rgb.Max();
        C = (W - (red / 255.0)) / W;
        M = (W - (green / 255.0)) / W;
        Y = (W - (blue / 255.0)) / W;
        K = 1 - W;
        System.Console.WriteLine($"C={C:F3} M={M:F3} Y={Y:F3} K={K:F3}");
    }
}

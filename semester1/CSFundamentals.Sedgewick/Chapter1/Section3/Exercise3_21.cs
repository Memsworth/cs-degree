using System.Text;

namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_21 : IExercise
{
    public void Run(string[] args)
    {
        var i = long.Parse(args[0]);
        var k = int.Parse(args[1]);

        var stack = new Stack<int>();

        while (i > 0)
        {
            stack.Push((int)i % k);
            i /= k;
        }

        var val = new StringBuilder();

        foreach (var item in stack)
        {
            if (item < 10)
                val.Append(item);
            else
                val.Append((char)('A' + (item - 10)));
        }
        
        System.Console.WriteLine(val.ToString());
    }
}
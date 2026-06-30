namespace CSharpPlayersGuide.level34;


public class SafeNumberCrunching : IExercise
{
    public void Run()
    {
        System.Console.WriteLine();
        var item = Test.GetIntValue();
    }

    public class Test
    {
        public static int GetIntValue()
        {
            int result = 0;
            var isValid = false;
            while (!isValid)
            {
                System.Console.WriteLine("Enter an int: ");
                isValid = int.TryParse(Console.ReadLine(), out result);
            }

            return result;
        }
    }
}
namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_16 : IExercise
{
    
    //prints all the positive powers of 2 less than or equal to n
    public void Run(string[] args)
    {
        var target = int.Parse(args[0]);

        if (target is < 1 or > 100)
            return;

        var valToAdd = 1;
        var powersCloseToTarget = new List<int>();

        while (valToAdd <= target)    
        {
            powersCloseToTarget.Add(valToAdd);
            //shift by 1
            valToAdd <<= 1;
        }

        if (powersCloseToTarget.Count <= 0) return;
        foreach (var powOfTwo in powersCloseToTarget) 
            Console.WriteLine($"{powOfTwo} is close to {target}");
    }
}
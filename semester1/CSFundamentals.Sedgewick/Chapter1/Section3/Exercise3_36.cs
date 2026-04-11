namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_36 : IExercise
{
    public void Run(string[] args)
    {
        if (!int.TryParse(args[0], out var n))
        { return; }

        var arrOfBool = new bool[n];
        var listOfNum =  new List<int>();
        
        if (n < 2)
            return;
        
        arrOfBool = Enumerable.Repeat(true, n).ToArray();

        arrOfBool[0] = false;
        arrOfBool[1] = false;
        
        for (var i = 2; i < (int)Math.Sqrt(n); i++)
        {
            if (!arrOfBool[i]) continue;
            for (var j = i*i; j < n; j+=i)
            {
                arrOfBool[j] = false;
            }
        }
        
        for (var i = 0; i < arrOfBool.Length; i++)
        {
            if (!arrOfBool[i]) continue;
            listOfNum.Add(i);
            //Console.Write($"{i}  ");
        }

        Console.WriteLine($"({listOfNum.Count}) numbers are total prime count");
    }
}

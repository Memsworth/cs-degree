namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_34 : IExercise
{
    public void Run(string[] args)
    {
        var n = int.Parse(args[0]);
        var cubeRoot = (int)Math.Floor(Math.Cbrt(n));
        var listOfPossiblePair = new List<(int, int)>();
        for (int i = 1; i <= cubeRoot; i++)
        {
            for (int j = 1; j <= cubeRoot; j++)
            {
                var total = Math.Pow(i, 3) + Math.Pow(j, 3);
                if (total == n && PairExists(listOfPossiblePair, i, j) is false)
                {
                    listOfPossiblePair.Add((i, j));
                }
            }
        }

        foreach(var pair in listOfPossiblePair)
        {
            Console.WriteLine($"Cube({pair.Item1}) + Cube({pair.Item2}) = {n}");
        }
    }

    private bool PairExists(List<(int, int)> list, int a, int b)
    {
        return list.Any(p =>
            (p.Item1 == a && p.Item2 == b) ||
            (p.Item1 == b && p.Item2 == a));
    }
}
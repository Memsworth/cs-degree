namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_42 : IExercise
{
    public void Run(string[] args)
    {
        if (!(int.TryParse(args[0], out int number)))
            return;

        var switchWin = 0;
        var noSwitchWin = 0;
        var rand = new Random();
        
        for (var i = 0; i < number; i++)
        {
            var prize = rand.Next(1, 4);
            var userChoice = rand.Next(1, 4);
            int hostDoor;
            do
            {
                hostDoor = rand.Next(1, 4);
            } while (hostDoor == prize || hostDoor == userChoice);
            
            var remainingDoor = 6 - hostDoor - userChoice;
            
            if(userChoice == prize)
                noSwitchWin++;
            if(remainingDoor == prize)
                switchWin++;
        }

        Console.WriteLine($"{switchWin / (double)number:F2} switch " +
                          $"- {noSwitchWin / (double)number:F2} no switch");
    }
}
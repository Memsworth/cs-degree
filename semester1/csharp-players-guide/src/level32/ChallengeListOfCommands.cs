namespace CSharpPlayersGuide.level32;

public class ChallengeListOfCommands : IExercise
{
    public void Run()
    {
            var robot = new Robot();
var isRun = false;

while (!isRun)
{
    var input = Console.ReadLine();
    switch (input)
    {
        case "on":
            robot.Commands.Add(new OnCommand());
            break;

        case "off":
            robot.Commands.Add(new OffCommand());
            break;

        case "north":
            robot.Commands.Add(new NorthCommand());
            break;

        case "south":
            robot.Commands.Add(new SouthCommand());
            break;

        case "east":
            robot.Commands.Add(new EastCommand());
            break;

        case "west":
            robot.Commands.Add(new WestCommand());
            break;
        case "stop":
            isRun = true;
            break;
        default:
            Console.WriteLine("Invalid command");
            break;
    }
}

robot.Run();

    }






public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    //public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public List<IRobotCommand?> Commands { get; set; } = new List<IRobotCommand?>();
    public void Run()
    {
        foreach (var command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    public void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == false)
        {
            robot.IsPowered = true;
        }
    }
}


public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.IsPowered = false;
        }
    }
}



public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.Y++;
        }
    }
}


public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.Y--;
        }
    }
}



public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.X++;
        }
    }
}


public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.X--;
        }
    }
}
}
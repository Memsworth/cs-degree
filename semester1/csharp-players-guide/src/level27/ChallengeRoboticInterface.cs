using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayersGuide.level27;

internal class ChallengeRoboticInterface : IExercise
{
    public void Run()
    {
        var robot = new Robot();

        for (var i = 0; i < robot.Commands.Length; i++)
        {
            var input = Console.ReadLine();

            switch (input)
            {
                case "on":
                    robot.Commands[i] = new OnCommand();
                    break;

                case "off":
                    robot.Commands[i] = new OffCommand();
                    break;

                case "north":
                    robot.Commands[i] = new NorthCommand();
                    break;

                case "south":
                    robot.Commands[i] = new SouthCommand();
                    break;

                case "east":
                    robot.Commands[i] = new EastCommand();

                    break;

                case "west":
                    robot.Commands[i] = new WestCommand();
                    break;

                default:
                    Console.WriteLine("Invalid command");
                    i--;
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
        public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
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

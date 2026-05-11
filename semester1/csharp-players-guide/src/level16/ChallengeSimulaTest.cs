using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace CSharpPlayersGuide.level16;

internal class ChallengeSimulaTest : IExercise
{
    public void Run()
    {
        var chest = new Chest();
        while (true)
        {
            string statusMessage = "";

            var input = Console.ReadLine();

            switch (input)
            {
                case "close" when chest.ChestStatus == Status.Open:
                    chest.ChangeStatus(Status.Closed);
                    break;
                case "lock" when chest.ChestStatus == Status.Closed:
                    chest.ChangeStatus(Status.Locked);
                    break;
                case "unlock" when chest.ChestStatus == Status.Locked:
                    chest.ChangeStatus(Status.Closed);
                    break;
                case "open" when chest.ChestStatus == Status.Closed:
                    chest.ChangeStatus(Status.Open);
                    break;
            }

        }
    }

    public class Chest
    {
        public Status ChestStatus { get; private set; }

        public Chest()
        {
            ChestStatus = Status.Locked;
        }

        public void ChangeStatus(Status status)
        {
            ChestStatus = status;
        }
    }

    public enum Status
    {
        Open = 0, Closed, Locked
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayersGuide.level24;

internal class ChallengeTheLockedDoor : IExercise
{
    public void Run()
    {
        Console.Write("Set starting passcode: ");
        int startingCode = int.Parse(Console.ReadLine());

        Door door = new Door(startingCode);

        while (true)
        {
            Console.WriteLine($"\nDoor State: {door.State}");
            Console.WriteLine("1- Open");
            Console.WriteLine("2- Close");
            Console.WriteLine("3- Lock");
            Console.WriteLine("4- Unlock");
            Console.WriteLine("5- Change Passcode");
            Console.WriteLine("6- Exit");

            Console.Write("Choose: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    door.Open();
                    break;

                case 2:
                    door.Close();
                    break;

                case 3:
                    door.Lock();
                    break;

                case 4:
                    Console.Write("Enter passcode: ");
                    int unlockCode = int.Parse(Console.ReadLine());
                    door.Unlock(unlockCode);
                    break;

                case 5:
                    Console.Write("Current passcode: ");
                    int current = int.Parse(Console.ReadLine());

                    Console.Write("New passcode: ");
                    int next = int.Parse(Console.ReadLine());

                    door.ChangePasscode(current, next);
                    break;

                case 6:
                    return;
            }
        }
    }

    enum DoorState
    {
        Open, Closed, Locked
    }

    class Door
    {
        private int Passcode { get; set; }
        public DoorState State { get; private set; }

        public Door(int passcode)
        {
            Passcode = passcode;
            State = DoorState.Closed;
        }

        public void Open()
        {
            if (State == DoorState.Closed)
            {
                State = DoorState.Open;
                Console.WriteLine("Door opened.");
            }
            else
                Console.WriteLine("Door cannot be opened.");
        }

        public void Close()
        {
            if (State == DoorState.Open)
            {
                State = DoorState.Closed;
                Console.WriteLine("Door closed.");
            }
            else
                Console.WriteLine("Door cannot be closed.");
        }

        public void Lock()
        {
            if (State == DoorState.Closed)
            {
                State = DoorState.Locked;
                Console.WriteLine("Door locked.");
            }
            else
                Console.WriteLine("Door cannot be locked.");
        }

        public void Unlock(int passcode)
        {
            if (State == DoorState.Locked && passcode == Passcode)
            {
                State = DoorState.Closed;
                Console.WriteLine("Door unlocked.");
            }
            else
                Console.WriteLine("Incorrect passcode or door is not locked.");
        }

        public void ChangePasscode(int currentPasscode, int newPasscode)
        {
            if (currentPasscode == Passcode)
            {
                Passcode = newPasscode;
                Console.WriteLine("Passcode changed.");
            }
            else
                Console.WriteLine("Incorrect current passcode.");
        }
    }
}

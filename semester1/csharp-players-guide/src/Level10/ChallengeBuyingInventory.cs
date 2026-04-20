using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayersGuide.Level10
{
    internal class ChallengeBuyingInventory : IExercise
    {
        public void Run()
        {
            Console.WriteLine("The following items are available:");
            Console.WriteLine("1 - Rope (10 gold)");
            Console.WriteLine("2 - Torches (15 gold)");
            Console.WriteLine("3 - Climbing Equipment (25 gold)");
            Console.WriteLine("4 - Clean Water (1 gold)");
            Console.WriteLine("5 - Machete (20 gold)");
            Console.WriteLine("6 - Canoe (200 gold)");
            Console.WriteLine("7 - Food Supplies (1 gold)");

            Console.Write("Enter the number of your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Rope costs 10 gold.");
                    break;
                case 2:
                    Console.WriteLine("Torches cost 15 gold.");
                    break;
                case 3:
                    Console.WriteLine("Climbing Equipment costs 25 gold.");
                    break;
                case 4:
                    Console.WriteLine("Clean Water costs 1 gold.");
                    break;
                case 5:
                    Console.WriteLine("Machete costs 20 gold.");
                    break;
                case 6:
                    Console.WriteLine("Canoe costs 200 gold.");
                    break;
                case 7:
                    Console.WriteLine("Food Supplies cost 1 gold.");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

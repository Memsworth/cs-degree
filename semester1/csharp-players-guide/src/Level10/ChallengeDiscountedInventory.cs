using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayersGuide.Level10
{
    internal class ChallengeDiscountedInventory : IExercise
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
            int choice = int.Parse(Console.ReadLine());
            var price = 0;
            var name = string.Empty;
            var itemName = string.Empty;

            switch (choice)
            {
                case 1:
                    price = 10;
                    itemName = "Rope";
                    break;
                case 2:
                    itemName = "Torches";
                    price = 15;
                    break;
                case 3:
                    itemName = "Climbing Equipment";
                    price = 25;
                    break;
                case 4:
                    itemName = "Clean Water";
                    price = 1;
                    break;
                case 5:
                    itemName = "Machete";
                    price = 20;
                    break;
                case 6:
                    itemName = "Canoe";
                    price = 200;
                    break;
                case 7:
                    itemName = "Food Supplies";
                    price = 1;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Console.WriteLine($"{itemName} {(choice == 2 || choice == 7 ? "costs" : "cost")} {price} gold.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayersGuide.level26
{
    internal class ChallengeLabelingInventory : IExercise
    {
        public void Run()
        {
            Pack pack = new(10, 20, 5);

            while (true)
            {
                DisplayPackStatus(pack);

                Console.WriteLine("\nChoose an item to add:");
                Console.WriteLine("1 - Arrow");
                Console.WriteLine("2 - Bow");
                Console.WriteLine("3 - Rope");
                Console.WriteLine("4 - Water");
                Console.WriteLine("5 - Food");
                Console.WriteLine("6 - Sword");
                Console.WriteLine("0 - Exit");

                string? choice = Console.ReadLine();

                if (choice == "0")
                    break;

                InventoryItem? item = CreateItem(choice);

                if (item is null)
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                bool added = pack.Add(item);

                Console.WriteLine(added
                    ? $"{item.Name} added."
                    : $"{item.Name} could not be added.");
            }
        }

        private static void DisplayPackStatus(Pack pack)
        {
            Console.WriteLine("\n=== Pack Status ===");
            Console.WriteLine($"Items  : {pack.CurrentItemCount}/{pack.MaxItems}");
            Console.WriteLine($"Weight : {pack.CurrentWeight}/{pack.MaxWeight}");
            Console.WriteLine($"Volume : {pack.CurrentVolume}/{pack.MaxVolume}");
            Console.WriteLine($"{pack}");
        }

        private static InventoryItem? CreateItem(string? choice) =>
            choice switch
            {
                "1" => new Arrow(),
                "2" => new Bow(),
                "3" => new Rope(),
                "4" => new Water(),
                "5" => new Food(),
                "6" => new Sword(),
                _ => null
            };


        abstract class InventoryItem
        {
            public string Name { get; }
            public double Weight { get; }
            public double Volume { get; }

            protected InventoryItem(string name, double weight, double volume)
            {
                Name = name;
                Weight = weight;
                Volume = volume;
            }
        }

        class Arrow : InventoryItem
        {
            public Arrow() : base("Arrow", 0.1, 0.05) { }

            public override string ToString() => "Arrow";
        }

        class Bow : InventoryItem
        {
            public Bow() : base("Bow", 1, 4) { }

            public override string ToString() => "Bow";

        }

        class Rope : InventoryItem
        {
            public Rope() : base("Rope", 1, 1.5) { }
            public override string ToString() => "Rope";

        }

        class Water : InventoryItem
        {
            public Water() : base("Water", 2, 3) { }
            public override string ToString() => "Water";

        }

        class Food : InventoryItem
        {
            public Food() : base("Food", 1, 0.5) { }
            public override string ToString() => "Food";

        }

        class Sword : InventoryItem
        {
            public Sword() : base("Sword", 5, 3) { }
            public override string ToString() => "Sword";

        }

        class Pack
        {
            private readonly InventoryItem[] _items;
            private int _currentCount;
            private double _currentWeight;
            private double _currentVolume;
            public int MaxItems { get; }
            public double MaxWeight { get; }
            public double MaxVolume { get; }

            public int CurrentItemCount => _currentCount;

            public double CurrentWeight => _currentWeight;
            public double CurrentVolume => _currentVolume;

            public Pack(int maxItems, double maxWeight, double maxVolume)
            {
                MaxItems = maxItems;
                MaxWeight = maxWeight;
                MaxVolume = maxVolume;
                _currentCount = 0;
                _items = new InventoryItem[maxItems];
            }

            public bool Add(InventoryItem item)
            {
                if (CurrentItemCount >= MaxItems)
                    return false;

                if (CurrentWeight + item.Weight > MaxWeight)
                    return false;

                if (CurrentVolume + item.Volume > MaxVolume)
                    return false;

                _currentWeight += item.Weight;
                _currentVolume += item.Volume;
                _items[_currentCount++] = item;

                return true;
            }

            public override string ToString()
            {
                var packMessage = "Pack contains ";

                foreach (var item in _items)
                {
                    if (item is not null)
                    {
                        packMessage += $"{item} ";
                    }
                }

                return packMessage;
            }
        }
    }
}

namespace CSharpPlayersGuide.level30
{
    internal class ChallengeColoredItems : IExercise
    {
        public void Run()
        {
            var item1 = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
            var item2 = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
            var item3 = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);

            Console.WriteLine(item1);
            Console.WriteLine(item2);
            Console.WriteLine(item3);
        }


        public class Sword 
        {
            public override string ToString()
            {
                return "Sword";
            }
        }
        public class Bow 
        {
            public override string ToString()
            {
                return "Bow";
            }
        }
        public class Axe 
        {
            public override string ToString()
            {
                return "Axe";
            }
        }


        public class ColoredItem<T>
        {
            public T Item { get; private set; }
            public ConsoleColor Color { get; private set; }

            public ColoredItem(T item, ConsoleColor color)
            {
                Item = item;
                Color = color;
            }

            public void Display()
            {
                var pre = Console.ForegroundColor;
                Console.ForegroundColor = Color;
                Console.WriteLine($"{Color.ToString()} {Item}");
                Console.ForegroundColor = pre;
            }
        }
    }
}

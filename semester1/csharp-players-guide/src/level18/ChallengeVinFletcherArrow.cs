namespace CSharpPlayersGuide.level18;

internal class ChallengeVinFletcherArrow : IExercise
{
    public void Run()
    {
        var arrow = new Arrow();
        var cost = 0.0;
        var headChoice = AskForNumberInRange("1- Steel 2-Wood 3-Obsidian", 0, 4);
        var FletchingChoice = AskForNumberInRange("1-Plastic, 2-TurkeyFeathers, 3-GooseFeathers", 0, 4);
        var shaftChoice = AskForNumberInRange("Shaft length", 5, 20);

        switch (headChoice)
        {
            case 1:
                arrow.Arrowhead = Arrowheads.Steel;
                break;

            case 2:
                arrow.Arrowhead = Arrowheads.Wood;
                break;

            case 3:
                arrow.Arrowhead = Arrowheads.Obsidian;
                break;
        }



        switch (FletchingChoice)
        {
            case 1:
                arrow.Fletching = Fletching.Plastic;
                break;

            case 2:
                arrow.Fletching = Fletching.TurkeyFeathers;
                break;

            case 3:
                arrow.Fletching = Fletching.GooseFeathers;
                break;
        }

        arrow.Shaft = shaftChoice;
        Console.WriteLine($"ArrowPrice: {arrow.GetCost():F2} gold");
    }


    public class Arrow()
    {
        public Arrowheads Arrowhead { get; set; }
        public Fletching Fletching { get; set; }
        public double Shaft { get; set; }

        public double GetCost()
        {
            var cost = 0.0;

            switch(Arrowhead)
            {
                case Arrowheads.Steel:
                    cost += 10.0;
                    break;

                case Arrowheads.Wood:
                    cost += 3.0;
                    break;

                case Arrowheads.Obsidian:
                    cost += 5.0;
                    break;
            }
            switch (Fletching)
            {
                case Fletching.Plastic:
                    cost += 10.0;
                    break;

                case Fletching.TurkeyFeathers:
                    cost += 5.0;
                    break;

                case Fletching.GooseFeathers:
                    cost += 3.0;
                    break;
            }

            cost += (Shaft * 0.05);

            return cost;
        }
    }

    public enum Arrowheads
    {
        Steel, Wood, Obsidian
    }

    public enum Fletching
    {
        Plastic, TurkeyFeathers, GooseFeathers
    }

    private int AskForNumberInRange(string text, int min, int max)
    {
        var result = 0;
        while (true)
        {
            Console.WriteLine($"{text} ");
            if (int.TryParse(Console.ReadLine(), out result))
                if (result > min && result < max)
                    break;
        }
        return result;
    }

}

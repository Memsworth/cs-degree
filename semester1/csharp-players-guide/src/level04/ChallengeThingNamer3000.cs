namespace CSharpPlayersGuide.Level04
{
    internal class ChallengeThingNamer3000 : IExercise
    {
        public void Run()
        {
            //thing namer
            Console.WriteLine("What kind of thing are we talking about?");
            string a = Console.ReadLine();
            //descibes the color
            Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
            string b = Console.ReadLine();
            
            string c = "of Doom"; //descibes doom
            string d = "3000"; //describes 3k
            
            // Change b and a
            Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!");
            Console.WriteLine("The " + a + " " + b + " of " + c + " " + d + "!");

        }
    }
}

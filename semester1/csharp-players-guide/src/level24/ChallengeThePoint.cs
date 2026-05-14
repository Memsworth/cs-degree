namespace CSharpPlayersGuide.level24;

internal class ChallengeThePoint : IExercise
{
    public void Run()
    {
        var pointA = new Point(2, 3);
        var pointB = new Point(-4, 0);

        System.Console.WriteLine(pointA);
        System.Console.WriteLine(pointB);
    }

    class Point
    {
        public int CordX { get; set; }
        public int CordY { get; set; }


        public Point()
        {
            CordX = 0;
            CordY = 0;
        }

        public Point(int cordX, int cordY)
        {
            CordX = cordX;
            CordY = cordY;
        }

        public override string ToString() => $"X: {CordX} Y: {CordY}";
    }
}

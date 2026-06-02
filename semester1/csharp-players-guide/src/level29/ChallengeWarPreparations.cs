namespace CSharpPlayersGuide.level29
{
    internal class ChallengeWarPreparations : IExercise
    {
        public void Run()
        {
            Sword basicSword = new(SwordMaterial.Iron, GemstoneType.None, 100f, 20f);

            Sword sapphireSword = basicSword with
            {
                Gemstone = GemstoneType.Sapphire
            };

            Sword steelSword = basicSword with
            {
                Material = SwordMaterial.Steel,
                Length = 120f
            };

            Console.WriteLine(basicSword);
            Console.WriteLine(sapphireSword);
            Console.WriteLine(steelSword);
        }
    }


    public enum SwordMaterial
    {
        Wood,
        Bronze,
        Iron,
        Steel,
        Binarium
    }

    public enum GemstoneType
    {
        None,
        Emerald,
        Amber,
        Sapphire,
        Diamond,
        Bitstone
    }

    public record Sword(
        SwordMaterial Material,
        GemstoneType Gemstone,
        float Length,
        float CrossguardWidth
    );
}

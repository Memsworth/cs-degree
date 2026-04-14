System.Console.WriteLine("Hello world");

public abstract class Food
{
    private double calories;

    public abstract double PercentProtein();
    public abstract double PercentFat();
    public abstract double PercentCarbohydrates();

    public double GetCalories() { return calories; }
    public void SetCalories(double cal) => calories = cal;

    public Food(double calo)
    {
        calories = calo;
    }
}



public class Vegetable : Food
{
    private const double VEG_FAT_CAL = 12.5;
    private const double VEG_PROTEIN_CAL = 5.5;
    private const double VEG_CARBO_CAL = 30.2;

    public override double PercentFat() => VEG_FAT_CAL / (VEG_FAT_CAL + VEG_PROTEIN_CAL + VEG_CARBO_CAL);
    public override double PercentProtein() => VEG_PROTEIN_CAL / (VEG_FAT_CAL + VEG_PROTEIN_CAL + VEG_CARBO_CAL);
    public override double PercentCarbohydrates() => VEG_CARBO_CAL / (VEG_FAT_CAL + VEG_PROTEIN_CAL + VEG_CARBO_CAL);

    public Vegetable(double calo) : base(calo) { }
}
public abstract class Food
{
    private double calories;

    public abstract double PercentProtein();
    public abstract double PercentFat();
    public abstract double PercentCarbohydrates();

    public double GetCalories() { return calories; }
    public void SetCalories(double cal) => calories = cal;
}
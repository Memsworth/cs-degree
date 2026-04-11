System.Console.WriteLine("Hello world");



public class Person
{
    public string FamilyName { get; set; }
    public string GivenName { get; set; }

    public int CompareTo(Person per)
    {
        if (FamilyName.CompareTo(per.FamilyName) == 0)
            return GivenName.CompareTo(per.GivenName);
        else
            return FamilyName.CompareTo(per.FamilyName);
    }
}


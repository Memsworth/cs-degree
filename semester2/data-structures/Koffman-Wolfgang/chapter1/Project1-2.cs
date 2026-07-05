#!

public class Person
{
    public string Name { get; set; }
    public string SocialSecurityNumber { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    public string TelephoneNumber { get; set; }

    public Person() { }

    public Person(string name, string ssn, int age, string gender, string address, string telephoneNumber)
    {
        Name = name;
        SocialSecurityNumber = ssn;
        Age = age;
        Gender = gender;
        Address = address;
        TelephoneNumber = telephoneNumber;
    }
}
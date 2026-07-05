#!



Person[] people =  {
    new Student("Alice", "111-11-1111", 20, "Female",
                "123 Main St", "555-1234", 3.8, "Computer Science", 2027),

    new HourlyEmployee("Bob", "222-22-2222", 35, "Male",
                "456 Oak St", "555-5678", "IT", "Technician", 2020,
                28.50m, 40, 25m),

    new SalariedEmployee("Carol", "333-33-3333", 42, "Female",
                "789 Pine St", "555-9999", "HR", "Manager", 2018,
                85000m)

                };

foreach (Person person in people)
{
    Console.WriteLine(person);
    Console.WriteLine();
}


public abstract class Person
{
    public string Name { get; set; }
    public string SocialSecurityNumber { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    public string TelephoneNumber { get; set; }

    public Person(string name, string ssn, int age, string gender, string address, string telephoneNumber)
    {
        Name = name;
        SocialSecurityNumber = ssn;
        Age = age;
        Gender = gender;
        Address = address;
        TelephoneNumber = telephoneNumber;
    }

    public override string ToString()
    {
        return $"Name: {Name}\n" +
               $"SSN: {SocialSecurityNumber}\n" +
               $"Age: {Age}\n" +
               $"Gender: {Gender}\n" +
               $"Address: {Address}\n" +
               $"Phone: {TelephoneNumber}";
    }
}


public class Student : Person
{
    public double Gpa { get; set; }
    public string Major { get; set; }
    public int YearOfGrad { get; set; }
    public Student(string name, string ssn, int age, string gender,
                    string address, string telephoneNumber, double gpa, string major, int yearOfGrad)

        : base(name, ssn, age, gender, address, telephoneNumber)
    {
        Gpa = gpa;
        Major = major;
        YearOfGrad = yearOfGrad;
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\nMajor: {Major}" +
               $"\nGPA: {Gpa}" +
               $"\nGraduation Year: {YearOfGrad}";
    }
}


public class Employee : Person
{
    public string Department { get; set; }
    public string JobTitle { get; set; }
    public int YearOfHire { get; set; }
    public Employee(string name, string ssn, int age, string gender,
                    string address, string telephoneNumber, string department, string jobTitle, int yearOfHire)

        : base(name, ssn, age, gender, address, telephoneNumber)
    {
        Department = department;
        JobTitle = jobTitle;
        YearOfHire = yearOfHire;
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\nDepartment: {Department}" +
               $"\nJob Title: {JobTitle}" +
               $"\nYear of Hire: {YearOfHire}";
    }
}


public class HourlyEmployee : Employee
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }
    public decimal UnionDues { get; set; }
    public HourlyEmployee(string name, string ssn, int age,
        string gender, string address, string telephoneNumber,
        string department, string jobTitle, int yearOfHire, decimal hourlyRate, int hoursWorked, decimal unionDues) :
        base(name, ssn, age, gender, address, telephoneNumber, department, jobTitle, yearOfHire)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
        UnionDues = unionDues;
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\nHourly Rate: {HourlyRate:C}" +
               $"\nHours Worked: {HoursWorked}" +
               $"\nUnion Dues: {UnionDues:C}";
    }
}


public class SalariedEmployee : Employee
{
    public decimal Salary { get; set; }
    public SalariedEmployee(string name, string ssn, int age,
        string gender, string address, string telephoneNumber,
        string department, string jobTitle, int yearOfHire, decimal salary) :
        base(name, ssn, age, gender, address, telephoneNumber, department, jobTitle, yearOfHire)
    {
        Salary = salary;
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\nAnnual Salary: {Salary:C}";
    }
}

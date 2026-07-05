#!

namespace Example
{
    class Employee
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public Employee(string name, string address)
        {
            Name = name;
            Address = address;
        }


        public override bool Equals(object? obj)
        {
            if (obj is not Employee other)
                return false;

            return Name == other.Name && Address == other.Address;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Address);
        }
    }
}
#!

Pet[] pets = new Pet[]
        {
            new Dog(),
            new Cat(),
            new Bat(),
            new Snake(),
            new Parrot()
        };

foreach (Pet p in pets)
{
    Console.WriteLine(p.GetType().Name + ": " + p.GetDiet());
}

public abstract class Pet
{
    public abstract string GetDiet();
    public abstract bool IsNocturnal();
    public abstract bool IsPoisonous();
    public abstract bool CanFly();
}

public class Dog : Pet
{
    public override string GetDiet() => "Omnivore";
    public override bool IsNocturnal() => false;
    public override bool IsPoisonous() => false;
    public override bool CanFly() => false;
}

public class Cat : Pet
{
    public override string GetDiet() => "Carnivore";
    public override bool IsNocturnal() => true;
    public override bool IsPoisonous() => false;
    public override bool CanFly() => false;
}

public class Bat : Pet
{
    public override string GetDiet() => "Insectivore";
    public override bool IsNocturnal() => true;
    public override bool IsPoisonous() => false;
    public override bool CanFly() => true;
}

public class Snake : Pet
{
    public override string GetDiet() => "Carnivore";
    public override bool IsNocturnal() => true;
    public override bool IsPoisonous() => true;
    public override bool CanFly() => false;
}

public class Parrot : Pet
{
    public override string GetDiet() => "Herbivore";
    public override bool IsNocturnal() => false;
    public override bool IsPoisonous() => false;
    public override bool CanFly() => true;
}

public class Owl : Pet
{
    public override string GetDiet() => "Carnivore";
    public override bool IsNocturnal() => true;
    public override bool IsPoisonous() => false;
    public override bool CanFly() => true;
}


public class Frog : Pet
{
    public override string GetDiet() => "Insectivore";
    public override bool IsNocturnal() => true;
    public override bool IsPoisonous() => false;
    public override bool CanFly() => false;
}



public class Eagle : Pet
{
    public override string GetDiet() => "Carnivore";
    public override bool IsNocturnal() => false;
    public override bool IsPoisonous() => false;
    public override bool CanFly() => true;
}



public class Turtle : Pet
{
    public override string GetDiet() => "Herbivore";
    public override bool IsNocturnal() => false;
    public override bool IsPoisonous() => false;
    public override bool CanFly() => false;
}



public class Spider : Pet
{
    public override string GetDiet() => "Carnivore";
    public override bool IsNocturnal() => true;
    public override bool IsPoisonous() => true;
    public override bool CanFly() => false;
}


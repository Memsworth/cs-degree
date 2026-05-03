#:property PublishAot=false


//TODO: Implement Circle and RT later

Shape myShape;
double perimeter;
double area;
myShape = GetShape();
myShape.ReadShapeData();
perimeter = myShape.ComputePerimeter();
area = myShape.ComputeArea();

DisplayResult(myShape, area, perimeter);
return;


static Shape GetShape()
{
    System.Console.WriteLine("Enter C for circle");
    System.Console.WriteLine("Enter R for Rectangle");
    System.Console.WriteLine("Enter T for Right Triangle");

    while (true)
    {
        if (!char.TryParse(Console.ReadLine(), out char choice))
            continue;

        if (choice.ToString().Equals("c", StringComparison.InvariantCultureIgnoreCase))
            return new Rectangle();

        else if (choice.ToString().Equals("r", StringComparison.InvariantCultureIgnoreCase))
            return new Rectangle();

        else if (choice.ToString().Equals("t", StringComparison.InvariantCultureIgnoreCase))
            return new Rectangle();
    }
}

static void DisplayResult(Shape myShape, double area, double perim)
{
    System.Console.WriteLine(myShape);
    System.Console.WriteLine($"The area is {area:F2} The perimeter is {perim:F2}");
}



public abstract class Shape
{
    public string ShapeName { get; private set; }
    public override string ToString() => "Shape is a " + ShapeName;
    public abstract double ComputeArea();
    public abstract double ComputePerimeter();
    public abstract void ReadShapeData();

    public Shape(string shapeName)
    {
        ShapeName = shapeName;
    }
}

public class Rectangle : Shape
{
    public double Width { get; private set; }
    public double Height { get; private set; }
    public Rectangle() : base("Rectangle")
    { }

    public Rectangle(double width, double height) : base("Rectangle")
    {
        Width = width;
        Height = height;
    }

    public override double ComputeArea() => Width * Height;
    public override double ComputePerimeter() => 2 * (Height + Width);
    public override void ReadShapeData()
    {
        while (true)
        {

            System.Console.WriteLine("Enter the width of the Rectangle");
            if (!double.TryParse(Console.ReadLine(), out double width))
                continue;


            System.Console.WriteLine("Enter the height of the Rectangle");
            if (!double.TryParse(Console.ReadLine(), out double height))
                continue;


            if (width > 0 && height > 0)
            {
                Width = width;
                Height = height;
                break;
            }
        }
    }
    public override string ToString() => base.ToString() + ": width is " + Width + ", height is " + Height;
}
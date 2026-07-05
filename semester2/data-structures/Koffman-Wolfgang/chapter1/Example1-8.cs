#!

namespace Example
{
    public abstract class Shape
    {
        public string ShapeName { get; private set; }

        public Shape(string shapeName)
        {
            ShapeName = shapeName;
        }

        public override string ToString()
        {
            return "Shape is a " + ShapeName;
        }

        public abstract double ComputeArea();
        public abstract double ComputePerimeter();
        public abstract void ReadShapeData();
    }


    public class Rectangle : Shape
    {

        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle() : base("Rectangle")
        {
        }

        public Rectangle(double width, double height) : base("Rectangle")
        {
            Width = width;
            Height = height;
        }

        public override double ComputeArea() => Height * Width;
        public override double ComputePerimeter() => 2 * (Height + Width);

        public override void ReadShapeData()
        {
            System.Console.WriteLine("Enter the width of the Rectangle");
            Width = double.Parse(Console.ReadLine()!);
            System.Console.WriteLine("Enter the height of the Rectangle");
            Height = double.Parse(Console.ReadLine()!);
        }


        public override string ToString()
        {
            return base.ToString() + ": width is " + Width + ", height is " + Height;
        }
    }
}
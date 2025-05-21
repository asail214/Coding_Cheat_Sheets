// Abstract class - cannot be instantiated, only inherited
public abstract class Shape
{
    // Regular property
    public string Color { get; set; }
    
    // Constructor
    public Shape(string color)
    {
        Color = color;
    }
    
    // Abstract method - must be implemented by derived classes
    public abstract double CalculateArea();
    
    // Regular method (not abstract)
    public void DisplayColor()
    {
        Console.WriteLine($"This shape is {Color}");
    }
    
    // Virtual method with implementation
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a shape");
    }
}

// Concrete class implementing abstract Shape
public class Circle : Shape
{
    public double Radius { get; set; }
    
    // Constructor calling base constructor
    public Circle(double radius, string color) : base(color)
    {
        Radius = radius;
    }
    
    // Implementation of abstract method
    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
    
    // Override of virtual method
    public override void Draw()
    {
        Console.WriteLine($"Drawing a {Color} circle with radius {Radius}");
    }
}

// Another concrete class
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public Rectangle(double width, double height, string color) : base(color)
    {
        Width = width;
        Height = height;
    }
    
    // Implementation of abstract method
    public override double CalculateArea()
    {
        return Width * Height;
    }
    
    public override void Draw()
    {
        Console.WriteLine($"Drawing a {Color} rectangle with dimensions {Width}x{Height}");
    }
}

// Interface definition
public interface IDrawable
{
    // Interface methods (implicitly public and abstract)
    void Draw();
    
    // Interface property (C# 8.0+ supports default implementation)
    string DrawingTool { get; set; }
}

// Interface implementation
public class Triangle : Shape, IDrawable
{
    public double Base { get; set; }
    public double Height { get; set; }
    public string DrawingTool { get; set; }
    
    public Triangle(double baseLength, double height, string color) : base(color)
    {
        Base = baseLength;
        Height = height;
        DrawingTool = "Pencil";  // Default value
    }
    
    public override double CalculateArea()
    {
        return 0.5 * Base * Height;
    }
    
    // Implementing interface method
    public void Draw()
    {
        Console.WriteLine($"Drawing a {Color} triangle with base {Base} and height {Height} using {DrawingTool}");
    }
}

// Another interface
public interface IResizable
{
    void Resize(double factor);
}

// Class implementing multiple interfaces
public class Square : Shape, IDrawable, IResizable
{
    public double Side { get; set; }
    public string DrawingTool { get; set; }
    
    public Square(double side, string color) : base(color)
    {
        Side = side;
        DrawingTool = "Ruler";
    }
    
    public override double CalculateArea()
    {
        return Side * Side;
    }
    
    public void Draw()
    {
        Console.WriteLine($"Drawing a {Color} square with side {Side} using {DrawingTool}");
    }
    
    public void Resize(double factor)
    {
        Side *= factor;
        Console.WriteLine($"Square resized. New side: {Side}");
    }
}

// Using abstract classes and interfaces
Circle circle = new Circle(5.0, "Red");
Rectangle rectangle = new Rectangle(4.0, 6.0, "Blue");

// Polymorphism with abstract class
Shape shape1 = circle;
Shape shape2 = rectangle;

Console.WriteLine($"Circle area: {shape1.CalculateArea()}");
Console.WriteLine($"Rectangle area: {shape2.CalculateArea()}");

shape1.Draw();  // Calls the overridden method in Circle
shape2.Draw();  // Calls the overridden method in Rectangle

// Working with interfaces
IDrawable drawable = new Square(3.0, "Green");
drawable.Draw();

IResizable resizable = (IResizable)drawable;  // Same object, different interface
resizable.Resize(2.0);  // Square's side is now 6.0
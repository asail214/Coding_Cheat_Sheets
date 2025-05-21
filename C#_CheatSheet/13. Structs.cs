// Struct declaration (value type, not reference type like classes)
public struct Point
{
    // Fields
    public int X;
    public int Y;
    
    // Constructor - in structs, must initialize all fields
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    // Method
    public double DistanceFromOrigin()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
    
    // Override ToString method
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

// Using structs
Point p1 = new Point(3, 4);
Console.WriteLine($"Point: {p1}");
Console.WriteLine($"Distance from origin: {p1.DistanceFromOrigin()}");

// Default value initialization
Point p2 = default;  // p2.X = 0, p2.Y = 0

// Custom struct with properties
public struct Temperature
{
    // Private backing field
    private double celsius;
    
    // Properties
    public double Celsius
    {
        get { return celsius; }
        set { celsius = value; }
    }
    
    public double Fahrenheit
    {
        get { return celsius * 9 / 5 + 32; }
        set { celsius = (value - 32) * 5 / 9; }
    }
    
    // Constructor
    public Temperature(double celsius)
    {
        this.celsius = celsius;
    }
    
    // Static method to create from Fahrenheit
    public static Temperature FromFahrenheit(double fahrenheit)
    {
        return new Temperature((fahrenheit - 32) * 5 / 9);
    }
}

// Using custom struct
Temperature temp1 = new Temperature(25);
Console.WriteLine($"Celsius: {temp1.Celsius}°C, Fahrenheit: {temp1.Fahrenheit}°F");

Temperature temp2 = Temperature.FromFahrenheit(98.6);
Console.WriteLine($"Body temperature: {temp2.Celsius:F1}°C");

// Key differences between structs and classes:
// 1. Structs are value types, classes are reference types
// 2. Structs can't inherit from other structs or classes, but can implement interfaces
// 3. Structs have default constructors even if not defined
// 4. Structs are typically used for small, simple data structures

// Example showing value vs reference behavior
struct ValuePoint { public int X, Y; }
class ReferencePoint { public int X, Y; }

// Value type behavior
ValuePoint vp1 = new ValuePoint { X = 10, Y = 20 };
ValuePoint vp2 = vp1;  // Creates a COPY
vp2.X = 30;  // Only changes vp2, not vp1
Console.WriteLine($"vp1: ({vp1.X}, {vp1.Y})");  // Output: (10, 20)

// Reference type behavior
ReferencePoint rp1 = new ReferencePoint { X = 10, Y = 20 };
ReferencePoint rp2 = rp1;  // Both reference the SAME object
rp2.X = 30;  // Changes both rp1 and rp2
Console.WriteLine($"rp1: ({rp1.X}, {rp1.Y})");  // Output: (30, 20)
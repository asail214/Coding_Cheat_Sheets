// Basic method declaration
void SayHello()
{
    Console.WriteLine("Hello!");
}

// Calling a method
SayHello();  // Prints: Hello!

// Method with parameters
void Greet(string name)
{
    Console.WriteLine($"Hello, {name}!");
}

// Calling method with arguments
Greet("Ali");  // Prints: Hello, Ali!

// Method with return value
int Add(int a, int b)
{
    return a + b;
}

// Using the return value
int sum = Add(5, 3);  // sum = 8
Console.WriteLine($"Sum: {sum}");

// Method with optional parameters (default values)
void DisplayInfo(string name, int age = 30, string city = "Cairo")
{
    Console.WriteLine($"Name: {name}, Age: {age}, City: {city}");
}

// Calling with different combinations
DisplayInfo("Omar");                    // Uses default age and city
DisplayInfo("Noor", 25);               // Specifies name and age, uses default city
DisplayInfo("Layla", 28, "Alexandria"); // Specifies all parameters

// Named arguments (order doesn't matter)
DisplayInfo(age: 35, name: "Karim", city: "Dubai");

// Method overloading (same name, different parameters)
int Multiply(int a, int b)
{
    return a * b;
}

double Multiply(double a, double b)
{
    return a * b;
}

// Expression-bodied methods (C# 6.0+)
int Square(int num) => num * num;

// Out parameter (to return multiple values)
void Divide(int dividend, int divisor, out int quotient, out int remainder)
{
    quotient = dividend / divisor;
    remainder = dividend % divisor;
}

// Using out parameters
int q, r;
Divide(10, 3, out q, out r);  // q = 3, r = 1

// Ref parameter (passes variable by reference)
void SwapNumbers(ref int x, ref int y)
{
    int temp = x;
    x = y;
    y = temp;
}

// Using ref parameters
int a = 5, b = 10;
SwapNumbers(ref a, ref b);  // a = 10, b = 5

// Method with variable number of arguments (params)
int Sum(params int[] numbers)
{
    int total = 0;
    foreach (int num in numbers)
    {
        total += num;
    }
    return total;
}

// Using params
int result1 = Sum(1, 2, 3);           // result1 = 6
int result2 = Sum(10, 20, 30, 40);    // result2 = 100
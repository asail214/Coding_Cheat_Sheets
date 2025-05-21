// Class with constructors
public class Student
{
    // Fields
    public string Name;
    public int Age;
    public string Major;
    
    // Default constructor (no parameters)
    public Student()
    {
        Name = "Unknown";
        Age = 18;
        Major = "Undeclared";
    }
    
    // Parameterized constructor
    public Student(string name, int age)
    {
        Name = name;
        Age = age;
        Major = "Undeclared";
    }
    
    // Constructor with all parameters
    public Student(string name, int age, string major)
    {
        Name = name;
        Age = age;
        Major = major;
    }
    
    // Constructor chaining using 'this'
    public Student(string name) : this(name, 18, "Undeclared")
    {
        // The above calls the constructor with all parameters
    }
    
    // Display student info
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Major: {Major}");
    }
}

// Using different constructors
Student student1 = new Student();                        // Using default constructor
Student student2 = new Student("Omar", 20);              // Using 2-parameter constructor
Student student3 = new Student("Noor", 22, "Computer Science"); // Using 3-parameter constructor
Student student4 = new Student("Layla");                 // Using constructor with name only

// Static constructor (called once before any objects are created)
public class Database
{
    private static string connectionString;
    
    // Static constructor - no access modifiers, no parameters
    static Database()
    {
        Console.WriteLine("Static constructor called");
        connectionString = "Server=myserver;Database=mydb;User Id=admin;Password=1234;";
    }
    
    // Instance constructor
    public Database()
    {
        Console.WriteLine("Instance constructor called");
    }
    
    public static void Connect()
    {
        Console.WriteLine($"Connecting to {connectionString}");
    }
}

// Constructor with optional parameters
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    
    public Product(string name, decimal price, string category = "General")
    {
        Name = name;
        Price = price;
        Category = category;
    }
}

// Using constructor with optional parameter
Product product1 = new Product("Laptop", 999.99m);              // Category will be "General"
Product product2 = new Product("Phone", 499.99m, "Electronics"); // Category will be "Electronics"

// Readonly fields that can only be set in constructors
public class Settings
{
    // Readonly field - can only be set in constructor
    public readonly string AppName;
    public readonly string Version;
    
    public Settings(string appName, string version)
    {
        AppName = appName;
        Version = version;
        // These can't be changed after constructor
    }
}
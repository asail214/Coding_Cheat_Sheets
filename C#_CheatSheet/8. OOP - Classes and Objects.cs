// Class declaration
public class Person
{
    // Fields (data)
    private string name;
    private int age;
    
    // Properties (getters and setters)
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    // Auto-implemented property (shorthand)
    public int Age { get; set; }
    
    // Property with validation
    private string email;
    public string Email
    {
        get { return email; }
        set 
        { 
            if (value.Contains("@"))
                email = value;
            else
                throw new ArgumentException("Invalid email format");
        }
    }
    
    // Read-only property
    public bool IsAdult => Age >= 18;  // Expression-bodied property
    
    // Methods
    public void Introduce()
    {
        Console.WriteLine($"Hi, I'm {Name} and I'm {Age} years old.");
    }
    
    public string GetGreeting()
    {
        return $"Hello, my name is {Name}!";
    }
}

// Creating objects
Person person1 = new Person();
person1.Name = "Amir";
person1.Age = 25;
person1.Email = "amir@example.com";

// Using object methods
person1.Introduce();  // Output: Hi, I'm Amir and I'm 25 years old.
string greeting = person1.GetGreeting();

// Using properties
Console.WriteLine($"Is adult: {person1.IsAdult}");  // Output: Is adult: True

// Object initializer syntax
Person person2 = new Person 
{ 
    Name = "Rania", 
    Age = 30,
    Email = "rania@example.com"
};

// Static members (belong to class, not objects)
public class MathHelper
{
    // Static field
    public static readonly double PI = 3.14159;
    
    // Static method
    public static int Add(int a, int b)
    {
        return a + b;
    }
}

// Using static members
double circleArea = MathHelper.PI * radius * radius;
int sum = MathHelper.Add(5, 3);  // sum = 8
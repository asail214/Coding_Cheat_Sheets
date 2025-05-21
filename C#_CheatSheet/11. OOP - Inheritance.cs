// Base class (parent)
public class Animal
{
    // Protected members can be accessed by derived classes
    protected string name;
    
    // Public properties
    public int Age { get; set; }
    public string Species { get; set; }
    
    // Constructor
    public Animal(string name, int age, string species)
    {
        this.name = name;
        Age = age;
        Species = species;
    }
    
    // Methods
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
    
    public void Sleep()
    {
        Console.WriteLine($"{name} is sleeping");
    }
    
    // Virtual method (can be overridden by derived classes)
    public virtual string GetInfo()
    {
        return $"{name} is a {Age}-year-old {Species}";
    }
}

// Derived class (child)
public class Dog : Animal
{
    // Additional property
    public string Breed { get; set; }
    
    // Constructor that calls base constructor
    public Dog(string name, int age, string breed)
        : base(name, age, "Dog") // Call to base constructor
    {
        Breed = breed;
    }
    
    // Override base class method
    public override void MakeSound()
    {
        Console.WriteLine($"{name} barks: Woof woof!");
    }
    
    // Additional method specific to Dog
    public void Fetch()
    {
        Console.WriteLine($"{name} is fetching the ball");
    }
    
    // Override GetInfo to include Breed
    public override string GetInfo()
    {
        return $"{base.GetInfo()} of breed {Breed}";
    }
}

// Another derived class
public class Cat : Animal
{
    public bool IsIndoor { get; set; }
    
    // Constructor calling base
    public Cat(string name, int age, bool isIndoor)
        : base(name, age, "Cat")
    {
        IsIndoor = isIndoor;
    }
    
    // Override MakeSound
    public override void MakeSound()
    {
        Console.WriteLine($"{name} meows: Meow!");
    }
    
    // New method
    public void Purr()
    {
        Console.WriteLine($"{name} is purring");
    }
}

// Using inheritance
Dog rex = new Dog("Rex", 3, "German Shepherd");
rex.MakeSound();  // Calls overridden method in Dog
rex.Sleep();      // Calls method from base class Animal
Console.WriteLine(rex.GetInfo());

Cat whiskers = new Cat("Whiskers", 2, true);
whiskers.MakeSound();  // Calls overridden method in Cat

// Polymorphism - treating derived class objects as base class
Animal animal1 = new Dog("Buddy", 5, "Golden Retriever");
Animal animal2 = new Cat("Mittens", 4, false);

// The correct overridden method is called based on the actual object type
animal1.MakeSound();  // Output: Buddy barks: Woof woof!
animal2.MakeSound();  // Output: Mittens meows: Meow!

// Method that works with any Animal
void FeedAnimal(Animal animal)
{
    Console.WriteLine($"Feeding {animal.Species}: {animal.GetInfo()}");
}

// Can be called with any derived classes
FeedAnimal(rex);
FeedAnimal(whiskers);
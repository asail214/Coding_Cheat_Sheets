// Generic class
public class Box<T>
{
    // Generic field
    private T value;
    
    // Constructor
    public Box(T value)
    {
        this.value = value;
    }
    
    // Generic property
    public T Value
    {
        get { return value; }
        set { this.value = value; }
    }
    
    // Method that uses the generic type
    public void DisplayType()
    {
        Console.WriteLine($"Box contains value of type: {typeof(T).Name}");
    }
    
    // Generic method within generic class
    public bool CompareWith<U>(U other)
    {
        return value.Equals(other);
    }
}

// Using a generic class
Box<int> intBox = new Box<int>(42);
intBox.DisplayType();  // Output: Box contains value of type: Int32
Console.WriteLine(intBox.Value);  // Output: 42

Box<string> stringBox = new Box<string>("Hello");
stringBox.DisplayType();  // Output: Box contains value of type: String

// Generic method
public static class Utilities
{
    // Generic method
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
    
    // Generic method with constraint (where T : class means T must be a reference type)
    public static void PrintCollection<T>(IEnumerable<T> collection) where T : class
    {
        foreach (T item in collection)
        {
            Console.WriteLine(item?.ToString() ?? "null");
        }
    }
    
    // Multiple type parameters
    public static Dictionary<TKey, TValue> CreateDictionary<TKey, TValue>(
        TKey key, TValue value) where TKey : notnull
    {
        return new Dictionary<TKey, TValue> { { key, value } };
    }
}

// Using generic methods
int x = 5, y = 10;
Utilities.Swap(ref x, ref y);  // x = 10, y = 5

List<string> names = new List<string> { "Ali", "Fatima", "Omar" };
Utilities.PrintCollection(names);

var dict = Utilities.CreateDictionary("Name", "Ahmed");

// Generic constraints
// where T : struct         - T must be a value type
// where T : class          - T must be a reference type
// where T : new()          - T must have a parameterless constructor
// where T : BaseClass      - T must inherit from BaseClass
// where T : IInterface     - T must implement IInterface
// where T : unmanaged      - T must be an unmanaged type (C# 7.3+)
// where T : notnull        - T must be a non-nullable type (C# 8.0+)

// Generic class with constraints
public class Repository<T> where T : class, new()
{
    private List<T> items = new List<T>();
    
    public void Add(T item)
    {
        items.Add(item);
    }
    
    public T CreateNew()
    {
        T newItem = new T();  // Only possible with the new() constraint
        items.Add(newItem);
        return newItem;
    }
    
    public List<T> GetAll()
    {
        return items;
    }
}

// Generic interface
public interface IRepository<T>
{
    void Add(T item);
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Update(T item);
    void Delete(T item);
}

// Implementing generic interface
public class ProductRepository : IRepository<Product>
{
    private List<Product> products = new List<Product>();
    
    public void Add(Product item)
    {
        products.Add(item);
    }
    
    public Product GetById(int id)
    {
        return products.FirstOrDefault(p => p.Id == id);
    }
    
    public IEnumerable<Product> GetAll()
    {
        return products;
    }
    
    public void Update(Product item)
    {
        // Update implementation
    }
    
    public void Delete(Product item)
    {
        products.Remove(item);
    }
}
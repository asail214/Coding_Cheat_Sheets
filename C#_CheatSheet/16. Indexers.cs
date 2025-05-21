// Class with an indexer
public class CustomCollection
{
    private string[] items;
    
    public CustomCollection(int size)
    {
        items = new string[size];
    }
    
    // Basic indexer
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= items.Length)
                throw new IndexOutOfRangeException();
            return items[index];
        }
        set
        {
            if (index < 0 || index >= items.Length)
                throw new IndexOutOfRangeException();
            items[index] = value;
        }
    }
    
    // Property to get collection size
    public int Count => items.Length;
}

// Using basic indexer
CustomCollection collection = new CustomCollection(3);
collection[0] = "First";
collection[1] = "Second";
collection[2] = "Third";

for (int i = 0; i < collection.Count; i++)
{
    Console.WriteLine(collection[i]);
}

// Class with multiple indexers
public class MultiIndexCollection
{
    private Dictionary<string, int> nameToAge = new Dictionary<string, int>();
    private Dictionary<int, string> idToName = new Dictionary<int, string>();
    
    // Indexer with string parameter
    public int this[string name]
    {
        get
        {
            if (nameToAge.TryGetValue(name, out int age))
                return age;
            throw new KeyNotFoundException($"Name '{name}' not found");
        }
        set
        {
            nameToAge[name] = value;
        }
    }
    
    // Indexer with int parameter
    public string this[int id]
    {
        get
        {
            if (idToName.TryGetValue(id, out string name))
                return name;
            throw new KeyNotFoundException($"ID {id} not found");
        }
        set
        {
            idToName[id] = value;
        }
    }
    
    // Add a person with id, name, and age
    public void AddPerson(int id, string name, int age)
    {
        idToName[id] = name;
        nameToAge[name] = age;
    }
}

// Using multiple indexers
MultiIndexCollection people = new MultiIndexCollection();
people.AddPerson(1, "Ahmed", 30);
people.AddPerson(2, "Sara", 25);

Console.WriteLine($"Name of ID 2: {people[2]}");  // Sara
Console.WriteLine($"Age of Ahmed: {people["Ahmed"]}");  // 30

// Indexer with multiple parameters
public class Matrix
{
    private int[,] data;
    
    public Matrix(int rows, int columns)
    {
        data = new int[rows, columns];
    }
    
    // Indexer with two parameters (row and column)
    public int this[int row, int col]
    {
        get
        {
            ValidateIndices(row, col);
            return data[row, col];
        }
        set
        {
            ValidateIndices(row, col);
            data[row, col] = value;
        }
    }
    
    private void ValidateIndices(int row, int col)
    {
        if (row < 0 || row >= data.GetLength(0))
            throw new IndexOutOfRangeException("Row index out of range");
            
        if (col < 0 || col >= data.GetLength(1))
            throw new IndexOutOfRangeException("Column index out of range");
    }
    
    // Properties for dimensions
    public int Rows => data.GetLength(0);
    public int Columns => data.GetLength(1);
}

// Using multi-parameter indexer
Matrix matrix = new Matrix(3, 3);
matrix[0, 0] = 1;
matrix[0, 1] = 2;
matrix[0, 2] = 3;
matrix[1, 1] = 5;

Console.WriteLine($"Matrix[1, 1] = {matrix[1, 1]}");  // 5

// Indexer with different return types
public class GenericIndexer<T>
{
    private Dictionary<string, T> items = new Dictionary<string, T>();
    
    // Generic indexer
    public T this[string key]
    {
        get
        {
            if (items.TryGetValue(key, out T value))
                return value;
            throw new KeyNotFoundException($"Key '{key}' not found");
        }
        set
        {
            items[key] = value;
        }
    }
    
    // Method to check if key exists
    public bool ContainsKey(string key)
    {
        return items.ContainsKey(key);
    }
}

// Using generic indexer
GenericIndexer<int> ages = new GenericIndexer<int>();
ages["Ahmed"] = 30;
ages["Sara"] = 25;

GenericIndexer<string> cities = new GenericIndexer<string>();
cities["Ahmed"] = "Cairo";
cities["Sara"] = "Alexandria";

Console.WriteLine($"Ahmed's age: {ages["Ahmed"]}");
Console.WriteLine($"Sara's city: {cities["Sara"]}");
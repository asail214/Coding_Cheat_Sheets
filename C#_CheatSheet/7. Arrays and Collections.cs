// Array declaration and initialization
int[] numbers = new int[5];          // Array of 5 integers (default values)
string[] names = new string[3];      // Array of 3 strings (default values)

// Array initialization with values
int[] scores = new int[] { 85, 92, 78, 95, 88 };
string[] cities = { "Cairo", "Alexandria", "Luxor" };  // Shorthand syntax

// Accessing array elements (zero-based index)
int firstScore = scores[0];    // 85
string secondCity = cities[1]; // Alexandria

// Modifying array elements
scores[2] = 80;
cities[0] = "Giza";

// Array properties and methods
int length = scores.Length;    // 5
Array.Sort(scores);            // Sorts array in ascending order
Array.Reverse(cities);         // Reverses the order of elements

// Multi-dimensional arrays
int[,] matrix = new int[3, 2]  // 3 rows, 2 columns
{
    { 1, 2 },
    { 3, 4 },
    { 5, 6 }
};

// Accessing elements in 2D array
int element = matrix[1, 0];    // Row 1, Column 0 = 3

// Jagged arrays (array of arrays)
int[][] jaggedArray = new int[3][];
jaggedArray[0] = new int[] { 1, 2, 3 };
jaggedArray[1] = new int[] { 4, 5 };
jaggedArray[2] = new int[] { 6, 7, 8, 9 };

// Accessing jagged array elements
int value = jaggedArray[2][1];  // 7

// Lists (dynamic arrays)
List<int> numberList = new List<int>();
numberList.Add(10);              // Add to end
numberList.Add(20);
numberList.Add(30);
numberList.Insert(1, 15);        // Insert at index 1
numberList.Remove(20);           // Remove first occurrence of 20
bool contains = numberList.Contains(15);  // true
int count = numberList.Count;    // 3

// List initialization
List<string> fruits = new List<string> { "Apple", "Banana", "Cherry" };

// Dictionary (key-value pairs)
Dictionary<string, int> ages = new Dictionary<string, int>();
ages.Add("Ahmed", 30);
ages["Sara"] = 28;              // Another way to add or update
ages["Mohamed"] = 35;

if (ages.ContainsKey("Sara"))
{
    int saraAge = ages["Sara"];  // 28
}

// Dictionary initialization
Dictionary<string, string> capitals = new Dictionary<string, string>
{
    { "Egypt", "Cairo" },
    { "France", "Paris" },
    { "Japan", "Tokyo" }
};

// Queue (First In, First Out)
Queue<string> queue = new Queue<string>();
queue.Enqueue("First");          // Add to end
queue.Enqueue("Second");
queue.Enqueue("Third");
string first = queue.Dequeue();  // Remove and return "First"
string peek = queue.Peek();      // View "Second" without removing

// Stack (Last In, First Out)
Stack<int> stack = new Stack<int>();
stack.Push(1);                   // Add to top
stack.Push(2);
stack.Push(3);
int top = stack.Pop();           // Remove and return 3
int peekValue = stack.Peek();    // View 2 without removing

// HashSet (unique elements)
HashSet<int> uniqueNumbers = new HashSet<int>();
uniqueNumbers.Add(1);
uniqueNumbers.Add(2);
uniqueNumbers.Add(1);            // Duplicate ignored
int uniqueCount = uniqueNumbers.Count;  // 2
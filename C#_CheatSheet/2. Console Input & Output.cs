// Basic output to console
Console.WriteLine("Hello World!");   // Prints text with newline at end
Console.Write("No newline ");        // Prints text without newline
Console.Write("here");               // Continues on same line

// String formatting
string name = "Fatima";
int age = 25;
Console.WriteLine("Name: {0}, Age: {1}", name, age);  // Placeholder style
Console.WriteLine($"Name: {name}, Age: {age}");       // String interpolation (C# 6+)

// Reading input from console
Console.Write("Enter your name: ");
string userName = Console.ReadLine();          // Reads a line of text

Console.Write("Enter your age: ");
string ageInput = Console.ReadLine();
int userAge = int.Parse(ageInput);             // Convert to integer
// OR in one step:
int directAge = Convert.ToInt32(Console.ReadLine());

// Reading a character (first character of input)
Console.Write("Enter a character: ");
char inputChar = Console.ReadKey().KeyChar;    // Reads a single character

// Clearing the console
Console.Clear();

// Setting console colors
Console.ForegroundColor = ConsoleColor.Blue;   // Set text color
Console.BackgroundColor = ConsoleColor.White;  // Set background color
Console.WriteLine("Colored text");
Console.ResetColor();                          // Reset to default colors

// Adding beep sound
Console.Beep();
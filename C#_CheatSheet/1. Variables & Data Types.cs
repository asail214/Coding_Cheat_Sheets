// Single line comment in C#

/*
Multi line comment
like this one
spanning multiple lines
*/

// Variable declarations in C#
// syntax: dataType variableName = value;

// Basic data types
int myNumber = 42;        // Integer (whole number)
double myDouble = 3.14;   // Double precision floating-point
float myFloat = 2.5f;     // Single precision floating-point (note the f suffix)
decimal myMoney = 99.99m; // Precise decimal (note the m suffix)
char myChar = 'A';        // Single character (note the single quotes)
bool isTrue = true;       // Boolean (true/false)
string myName = "Ahmed";  // String (text - note the double quotes)

// Constants - cannot be changed after declaration
const double PI = 3.14159;

// Type inference with var (compiler determines the type)
var autoNumber = 10;     // Compiler knows this is an int
var autoText = "Hello";  // Compiler knows this is a string

// Default values
int unassignedInt;      // Default value: 0
bool unassignedBool;    // Default value: false
string unassignedText;  // Default value: null

// Nullable types (can hold null value)
int? nullableInt = null;

Console.WriteLine(myName);  // Prints: Ahmed
Console.WriteLine($"My age is {myNumber}");  // String interpolation

// Type conversion
int x = 10;
double y = x;           // Implicit conversion (safe)
int z = (int)myDouble;  // Explicit conversion (may lose data)

// Other conversions
string numText = "123";
int parsedNum = int.Parse(numText);      // Converts string to int
int convertedNum = Convert.ToInt32(numText);  // Another way to convert

// Data type sizes
// byte: 8 bits (0 to 255)
// short: 16 bits
// int: 32 bits
// long: 64 bits
// float: 32 bits
// double: 64 bits
// decimal: 128 bits
// If statement
int age = 20;

if (age >= 18)
{
    Console.WriteLine("You are an adult");
}

// If-else statement
int number = 7;

if (number % 2 == 0)
{
    Console.WriteLine("Number is even");
}
else
{
    Console.WriteLine("Number is odd");
}

// If-else if-else ladder
int score = 85;

if (score >= 90)
{
    Console.WriteLine("Grade: A");
}
else if (score >= 80)
{
    Console.WriteLine("Grade: B");
}
else if (score >= 70)
{
    Console.WriteLine("Grade: C");
}
else if (score >= 60)
{
    Console.WriteLine("Grade: D");
}
else
{
    Console.WriteLine("Grade: F");
}

// Nested if statements
bool isLoggedIn = true;
bool isAdmin = false;

if (isLoggedIn)
{
    Console.WriteLine("Welcome back!");
    
    if (isAdmin)
    {
        Console.WriteLine("You have admin privileges");
    }
    else
    {
        Console.WriteLine("You have user privileges");
    }
}

// Switch statement
char grade = 'B';

switch (grade)
{
    case 'A':
        Console.WriteLine("Excellent!");
        break;
    case 'B':
        Console.WriteLine("Good job!");
        break;
    case 'C':
        Console.WriteLine("Satisfactory");
        break;
    case 'D':
        Console.WriteLine("You passed");
        break;
    case 'F':
        Console.WriteLine("You failed");
        break;
    default:
        Console.WriteLine("Invalid grade");
        break;
}

// Switch expression (C# 8.0+)
string message = grade switch
{
    'A' => "Excellent!",
    'B' => "Good job!",
    'C' => "Satisfactory",
    'D' => "You passed",
    'F' => "You failed",
    _ => "Invalid grade"  // Default case
};

// Conditional operator (ternary)
int temperature = 5;
string weather = (temperature > 20) ? "Warm" : "Cold";
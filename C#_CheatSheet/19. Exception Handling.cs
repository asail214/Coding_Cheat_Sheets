// Basic try-catch block
public void BasicExceptionHandling()
{
    try
    {
        // Code that might throw an exception
        int[] numbers = { 1, 2, 3 };
        Console.WriteLine(numbers[10]);  // This will throw IndexOutOfRangeException
    }
    catch (Exception ex)
    {
        // Handle the exception
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

// Multiple catch blocks for different exception types
public void MultipleExceptionHandling()
{
    try
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        int result = 10 / number;
        Console.WriteLine($"Result: {result}");
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Cannot divide by zero.");
    }
    catch (Exception ex)
    {
        // General catch for any other exceptions
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

// Using finally block
public void FinallyBlockExample()
{
    System.IO.StreamReader reader = null;
    try
    {
        reader = new System.IO.StreamReader("file.txt");
        string content = reader.ReadToEnd();
        Console.WriteLine(content);
    }
    catch (System.IO.FileNotFoundException)
    {
        Console.WriteLine("File not found.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error reading file: {ex.Message}");
    }
    finally
    {
        // This code always runs, even if an exception occurs
        if (reader != null)
        {
            reader.Close();
            Console.WriteLine("File closed.");
        }
    }
}

// Exception properties
public void ExceptionProperties()
{
    try
    {
        ThrowExceptionMethod();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Message: {ex.Message}");
        Console.WriteLine($"Source: {ex.Source}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");
        Console.WriteLine($"TargetSite: {ex.TargetSite}");
        
        // Check for inner exception
        if (ex.InnerException != null)
        {
            Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
        }
    }
}

// Custom exceptions
public class InvalidAgeException : Exception
{
    public int AttemptedAge { get; }
    
    public InvalidAgeException(string message) : base(message)
    {
    }
    
    public InvalidAgeException(string message, int attemptedAge) : base(message)
    {
        AttemptedAge = attemptedAge;
    }
    
    public InvalidAgeException(string message, Exception inner) : base(message, inner)
    {
    }
}

// Using custom exceptions
public void ValidateAge(int age)
{
    if (age < 0 || age > 120)
    {
        throw new InvalidAgeException("Age must be between 0 and 120", age);
    }
    Console.WriteLine($"Age {age} is valid");
}

// Using exception filters (C# 6.0+)
public void ExceptionFilters()
{
    try
    {
        // Some code that might throw
        ProcessData(-5);
    }
    catch (ArgumentException ex) when (ex.ParamName == "count")
    {
        Console.WriteLine("Invalid count parameter");
    }
    catch (ArgumentException ex) when (ex.ParamName == "name")
    {
        Console.WriteLine("Invalid name parameter");
    }
}

// Using 'using' statement for automatic disposal
public void UsingStatementExample()
{
    // File will be automatically closed even if an exception occurs
    using (System.IO.StreamReader reader = new System.IO.StreamReader("file.txt"))
    {
        string content = reader.ReadToEnd();
        Console.WriteLine(content);
    }
    
    // C# 8.0+ simplified using statement
    using System.IO.StreamReader reader2 = new System.IO.StreamReader("file.txt");
    string content2 = reader2.ReadToEnd();
    Console.WriteLine(content2);
}

// Throwing exceptions
public void ProcessData(int count)
{
    if (count < 0)
    {
        throw new ArgumentException("Count cannot be negative", "count");
    }
    
    // Re-throwing while preserving stack trace
    try
    {
        // Some operation
        if (count == 0)
        {
            throw new InvalidOperationException("Count cannot be zero");
        }
    }
    catch (InvalidOperationException ex)
    {
        // Log the exception
        Console.WriteLine($"Logging: {ex.Message}");
        
        // Re-throw maintaining stack trace
        throw;  // Better than "throw ex" which resets the stack trace
    }
}

// Try-catch-when pattern (C# 6.0+)
public void TryCatchWhen()
{
    try
    {
        int result = Divide(10, 0);
    }
    catch (DivideByZeroException ex) when (LogException(ex))
    {
        // This block won't execute if LogException returns true
        Console.WriteLine("Division by zero error");
    }
}

private bool LogException(Exception ex)
{
    // Log the exception
    Console.WriteLine($"Logging exception: {ex.Message}");
    
    // Return false to allow the catch block to handle the exception
    // Return true to prevent the catch block from executing
    return false;
}

// Exception handling with async/await
public async Task ExceptionHandlingAsync()
{
    try
    {
        await Task.Delay(1000);
        throw new InvalidOperationException("Async exception");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Caught async exception: {ex.Message}");
    }
}
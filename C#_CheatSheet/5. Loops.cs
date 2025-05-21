// For loop
// for (initialization; condition; iteration)
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"For loop iteration: {i}");
}

// While loop
int count = 0;
while (count < 5)
{
    Console.WriteLine($"While loop iteration: {count}");
    count++;
}

// Do-While loop (executes at least once)
int j = 0;
do
{
    Console.WriteLine($"Do-While loop iteration: {j}");
    j++;
} while (j < 5);

// Foreach loop (for collections)
string[] fruits = { "Apple", "Banana", "Cherry" };
foreach (string fruit in fruits)
{
    Console.WriteLine($"Fruit: {fruit}");
}

// Nested loops
for (int row = 1; row <= 3; row++)
{
    for (int col = 1; col <= 3; col++)
    {
        Console.Write($"({row},{col}) ");
    }
    Console.WriteLine();  // New line after each row
}

// Break statement (exits the loop)
for (int i = 0; i < 10; i++)
{
    if (i == 5)
    {
        break;  // Exit loop when i equals 5
    }
    Console.WriteLine($"Break example: {i}");
}

// Continue statement (skips current iteration)
for (int i = 0; i < 5; i++)
{
    if (i == 2)
    {
        continue;  // Skip iteration when i equals 2
    }
    Console.WriteLine($"Continue example: {i}");
}

// Infinite loop with break
int x = 0;
while (true)
{
    Console.WriteLine($"Infinite loop iteration: {x}");
    x++;
    if (x >= 5)
    {
        break;  // Exit after 5 iterations
    }
}
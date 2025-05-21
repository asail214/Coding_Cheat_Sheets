// LINQ - Language Integrated Query
using System;
using System.Collections.Generic;
using System.Linq;

// Sample data
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Basic LINQ queries

// Query syntax
var evenNumbers = from num in numbers
                 where num % 2 == 0
                 select num;

// Method syntax (lambda expressions)
var evenNumbersMethod = numbers.Where(num => num % 2 == 0);

// Select: transform elements
var squaredNumbers = numbers.Select(num => num * num);

// OrderBy: sort elements
var ascendingOrder = numbers.OrderBy(num => num);
var descendingOrder = numbers.OrderByDescending(num => num);

// First, Last, FirstOrDefault, LastOrDefault
int firstEven = numbers.First(num => num % 2 == 0);        // 2
int lastEven = numbers.Last(num => num % 2 == 0);          // 10
int firstOver20 = numbers.FirstOrDefault(num => num > 20); // 0 (default for int)

// Any, All, Contains
bool hasEvenNumbers = numbers.Any(num => num % 2 == 0);    // true
bool allPositive = numbers.All(num => num > 0);            // true
bool containsSeven = numbers.Contains(7);                  // true

// Count, Sum, Min, Max, Average
int count = numbers.Count();                               // 10
int sum = numbers.Sum();                                   // 55
int min = numbers.Min();                                   // 1
int max = numbers.Max();                                   // 10
double average = numbers.Average();                        // 5.5

// Skip, Take
var skipFirstThree = numbers.Skip(3);                      // 4, 5, 6, 7, 8, 9, 10
var takeFirstFour = numbers.Take(4);                       // 1, 2, 3, 4

// Distinct
List<int> duplicates = new List<int> { 1, 2, 2, 3, 3, 3, 4, 5, 5 };
var distinctNumbers = duplicates.Distinct();               // 1, 2, 3, 4, 5

// Complex LINQ example with custom class
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }
    public List<int> Grades { get; set; }
}

// Creating sample data
List<Student> students = new List<Student>
{
    new Student { 
        Id = 1, 
        Name = "Ahmed", 
        Age = 20, 
        Major = "Computer Science", 
        Grades = new List<int> { 85, 90, 78, 92 } 
    },
    new Student { 
        Id = 2, 
        Name = "Fatima", 
        Age = 22, 
        Major = "Engineering", 
        Grades = new List<int> { 95, 88, 91, 87 } 
    },
    new Student { 
        Id = 3, 
        Name = "Omar", 
        Age = 19, 
        Major = "Computer Science", 
        Grades = new List<int> { 75, 80, 82, 79 } 
    },
    new Student { 
        Id = 4, 
        Name = "Layla", 
        Age = 21, 
        Major = "Medicine", 
        Grades = new List<int> { 92, 94, 96, 90 } 
    }
};

// Complex queries

// Group students by major
var studentsByMajor = students.GroupBy(s => s.Major);

foreach (var group in studentsByMajor)
{
    Console.WriteLine($"Major: {group.Key}");
    foreach (var student in group)
    {
        Console.WriteLine($"  {student.Name}, Age: {student.Age}");
    }
}

// Projection to anonymous type
var studentSummaries = students.Select(s => new {
    s.Name,
    s.Major,
    AverageGrade = s.Grades.Average()
});

// OrderBy with ThenBy
var orderedStudents = students
    .OrderBy(s => s.Major)
    .ThenByDescending(s => s.Grades.Average());

// Combining multiple operations
var topComputerScienceStudents = students
    .Where(s => s.Major == "Computer Science")
    .OrderByDescending(s => s.Grades.Average())
    .Take(2)
    .Select(s => new {
        s.Name,
        AverageGrade = Math.Round(s.Grades.Average(), 1)
    });

// Using Join
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Major { get; set; }
}

List<Course> courses = new List<Course>
{
    new Course { Id = 101, Name = "Programming 101", Major = "Computer Science" },
    new Course { Id = 102, Name = "Data Structures", Major = "Computer Science" },
    new Course { Id = 201, Name = "Circuit Theory", Major = "Engineering" },
    new Course { Id = 301, Name = "Anatomy", Major = "Medicine" }
};

// Join students with their major's courses
var studentCourses = students.Join(
    courses,
    student => student.Major,
    course => course.Major,
    (student, course) => new {
        StudentName = student.Name,
        CourseName = course.Name
    }
);

// Using GroupJoin (similar to LEFT OUTER JOIN)
var majorCourses = students.GroupJoin(
    courses,
    student => student.Major,
    course => course.Major,
    (student, courseGroup) => new {
        Student = student,
        Courses = courseGroup
    }
);

// Let clause (in query syntax)
var highGradeStudents = from s in students
                        let avgGrade = s.Grades.Average()
                        where avgGrade >= 85
                        orderby avgGrade descending
                        select new {
                            s.Name,
                            AverageGrade = avgGrade
                        };

// Aggregation with custom objects
var summary = students
    .GroupBy(s => s.Major)
    .Select(g => new {
        Major = g.Key,
        StudentCount = g.Count(),
        AverageAge = g.Average(s => s.Age),
        HighestGrade = g.Max(s => s.Grades.Max())
    });

// Flattening collections
var allGrades = students.SelectMany(s => s.Grades);
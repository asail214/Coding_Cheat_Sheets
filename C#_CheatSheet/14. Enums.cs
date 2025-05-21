// Basic enum declaration
public enum DayOfWeek
{
    Sunday,    // 0 by default
    Monday,    // 1
    Tuesday,   // 2
    Wednesday, // 3
    Thursday,  // 4
    Friday,    // 5
    Saturday   // 6
}

// Using enum
DayOfWeek today = DayOfWeek.Wednesday;

// Comparing enums
if (today == DayOfWeek.Wednesday)
{
    Console.WriteLine("It's Wednesday!");
}

// Converting enums to and from integers
int dayNumber = (int)today;  // 3
DayOfWeek tomorrow = (DayOfWeek)(dayNumber + 1);  // Thursday

// Converting enum to string
string dayName = today.ToString();  // "Wednesday"

// Parsing string to enum
DayOfWeek parsedDay = Enum.Parse<DayOfWeek>("Monday");
// Or using TryParse for safety
if (Enum.TryParse<DayOfWeek>("Monday", out DayOfWeek result))
{
    Console.WriteLine($"Parsed day: {result}");
}

// Enum with explicit values
public enum HttpStatusCode
{
    OK = 200,
    Created = 201,
    Accepted = 202,
    NoContent = 204,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    ServerError = 500
}

HttpStatusCode status = HttpStatusCode.NotFound;
Console.WriteLine($"Status code: {(int)status}");  // 404

// Enum with non-sequential values
public enum Currency
{
    USD = 840,  // ISO 4217 currency codes
    EUR = 978,
    GBP = 826,
    JPY = 392,
    EGP = 818
}

// Get all enum values
foreach (Currency currency in Enum.GetValues(typeof(Currency)))
{
    Console.WriteLine($"{currency} = {(int)currency}");
}

// Flags enum (for bit flags, can combine multiple values)
[Flags]  // Attribute for better ToString() formatting
public enum Permissions
{
    None = 0,        // 00000000
    Read = 1,        // 00000001
    Write = 2,       // 00000010
    Execute = 4,     // 00000100
    Delete = 8,      // 00001000
    ReadWrite = Read | Write,  // 00000011 (3)
    All = Read | Write | Execute | Delete  // 00001111 (15)
}

// Using flags enum
Permissions userPermissions = Permissions.Read | Permissions.Write;  // Combined!

// Checking flags
bool canRead = (userPermissions & Permissions.Read) == Permissions.Read;
bool canExecute = userPermissions.HasFlag(Permissions.Execute);  // More readable

// Adding a permission
userPermissions |= Permissions.Execute;

// Removing a permission
userPermissions &= ~Permissions.Write;

// Toggling a permission
userPermissions ^= Permissions.Read;

Console.WriteLine(userPermissions);  // Shows flags that are set
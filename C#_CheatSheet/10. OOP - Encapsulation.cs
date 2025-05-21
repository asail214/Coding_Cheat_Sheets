// Encapsulation: Hiding data and implementation details
public class BankAccount
{
    // Private fields - not accessible from outside the class
    private string accountNumber;
    private decimal balance;
    private string ownerName;
    
    // Constructor
    public BankAccount(string accountNumber, string ownerName)
    {
        this.accountNumber = accountNumber;
        this.ownerName = ownerName;
        balance = 0;
    }
    
    // Properties with controlled access
    public string AccountNumber 
    { 
        get { return accountNumber; } 
        // No setter - can't be changed after creation
    }
    
    public string OwnerName
    {
        get { return ownerName; }
        set
        {
            // Validation before setting
            if (!string.IsNullOrEmpty(value))
                ownerName = value;
        }
    }
    
    public decimal Balance
    {
        get { return balance; }
        // No public setter - balance can only be modified by methods
    }
    
    // Public methods for controlled operations
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount:C}. New balance: {balance:C}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive");
        }
    }
    
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive");
            return false;
        }
        
        if (amount > balance)
        {
            Console.WriteLine("Insufficient funds");
            return false;
        }
        
        balance -= amount;
        Console.WriteLine($"Withdrew {amount:C}. New balance: {balance:C}");
        return true;
    }
}

// Using the encapsulated class
BankAccount account = new BankAccount("12345", "Fatima Hassan");

// Can access read-only properties
Console.WriteLine($"Account: {account.AccountNumber}");
Console.WriteLine($"Owner: {account.OwnerName}");
Console.WriteLine($"Balance: {account.Balance:C}");

// Can modify through controlled methods
account.Deposit(1000);
account.Withdraw(500);

// Can't directly modify balance:
// account.Balance = 1000000;  // Compilation error

// Property-based encapsulation
public class Employee
{
    // Auto-implemented properties with different access levels
    public string Name { get; set; }           // Public get and set
    public string Title { get; set; }
    public DateTime HireDate { get; private set; }  // Private set
    public int EmployeeId { get; }             // Read-only (get-only)
    
    // Backing field for salary with validation through property
    private decimal _salary;
    public decimal Salary
    {
        get { return _salary; }
        set
        {
            if (value >= 0)
                _salary = value;
            else
                throw new ArgumentException("Salary cannot be negative");
        }
    }
    
    // Constructor
    public Employee(string name, string title, int id)
    {
        Name = name;
        Title = title;
        EmployeeId = id;
        HireDate = DateTime.Now;
    }
    
    // Methods that use encapsulated data
    public decimal CalculateYearlySalary()
    {
        return Salary * 12;
    }
    
    public void Promote(string newTitle)
    {
        Title = newTitle;
        // The method could also give a raise here
    }
}
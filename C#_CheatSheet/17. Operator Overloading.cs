// Class with operator overloading
public struct Money
{
    // Properties
    public decimal Amount { get; }
    public string Currency { get; }
    
    // Constructor
    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    
    // Override ToString for better display
    public override string ToString()
    {
        return $"{Amount} {Currency}";
    }
    
    // Overloading + operator
    public static Money operator +(Money a, Money b)
    {
        // Simplification - assuming same currency
        if (a.Currency != b.Currency)
            throw new ArgumentException("Cannot add different currencies");
            
        return new Money(a.Amount + b.Amount, a.Currency);
    }
    
    // Overloading - operator
    public static Money operator -(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new ArgumentException("Cannot subtract different currencies");
            
        return new Money(a.Amount - b.Amount, a.Currency);
    }
    
    // Overloading * operator (scalar multiplication)
    public static Money operator *(Money a, decimal multiplier)
    {
        return new Money(a.Amount * multiplier, a.Currency);
    }
    
    // Overloading / operator
    public static Money operator /(Money a, decimal divisor)
    {
        if (divisor == 0)
            throw new DivideByZeroException();
            
        return new Money(a.Amount / divisor, a.Currency);
    }
    
    // Overloading comparison operators
    public static bool operator ==(Money a, Money b)
    {
        // For proper comparison, both amount and currency should match
        return a.Currency == b.Currency && a.Amount == b.Amount;
    }
    
    public static bool operator !=(Money a, Money b)
    {
        return !(a == b);
    }
    
    // Overloading > and < operators
    public static bool operator >(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new ArgumentException("Cannot compare different currencies");
            
        return a.Amount > b.Amount;
    }
    
    public static bool operator <(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new ArgumentException("Cannot compare different currencies");
            
        return a.Amount < b.Amount;
    }
    
    // Must override Equals and GetHashCode when overloading == and !=
    public override bool Equals(object obj)
    {
        if (obj is Money other)
            return this == other;
        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Currency);
    }
    
    // Custom conversion operators
    public static explicit operator decimal(Money money)
    {
        return money.Amount;
    }
    
    public static implicit operator Money(decimal amount)
    {
        return new Money(amount, "USD");  // Default currency
    }
}

// Using operator overloading
Money wallet1 = new Money(100.50m, "USD");
Money wallet2 = new Money(200.75m, "USD");

// Using the operators
Money sum = wallet1 + wallet2;
Console.WriteLine($"Sum: {sum}");  // 301.25 USD

Money difference = wallet2 - wallet1;
Console.WriteLine($"Difference: {difference}");  // 100.25 USD

Money doubled = wallet1 * 2;
Console.WriteLine($"Doubled: {doubled}");  // 201.00 USD

Money shared = wallet2 / 4;
Console.WriteLine($"Shared: {shared}");  // 50.19 USD

// Comparison
bool isEqual = wallet1 == wallet2;  // false
bool isGreater = wallet2 > wallet1;  // true

// Conversion operators
decimal amount = (decimal)wallet1;  // Explicit conversion
Money defaultMoney = 50.25m;        // Implicit conversion

// Another example: Complex number
public struct Complex
{
    public double Real { get; }
    public double Imaginary { get; }
    
    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }
    
    // Override ToString
    public override string ToString()
    {
        if (Imaginary >= 0)
            return $"{Real} + {Imaginary}i";
        else
            return $"{Real} - {Math.Abs(Imaginary)}i";
    }
    
    // Overload addition
    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }
    
    // Overload subtraction
    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }
    
    // Overload multiplication (complex number rules)
    public static Complex operator *(Complex a, Complex b)
    {
        // (a + bi)(c + di) = (ac - bd) + (ad + bc)i
        double real = a.Real * b.Real - a.Imaginary * b.Imaginary;
        double imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real;
        return new Complex(real, imaginary);
    }
    
    // Unary negation operator
    public static Complex operator -(Complex a)
    {
        return new Complex(-a.Real, -a.Imaginary);
    }
    
    // Conjugate method (not an operator but useful)
    public Complex Conjugate()
    {
        return new Complex(Real, -Imaginary);
    }
}

// Using Complex with operators
Complex c1 = new Complex(3, 4);    // 3 + 4i
Complex c2 = new Complex(1, -2);   // 1 - 2i

Complex sum = c1 + c2;             // 4 + 2i
Complex product = c1 * c2;         // 3 + 4i * 1 - 2i = 3 - 6i + 4i - 8i² = 3 - 2i + 8 = 11 - 2i
Complex negated = -c1;             // -3 - 4i
Complex conjugate = c1.Conjugate(); // 3 - 4i

Console.WriteLine($"Complex 1: {c1}");
Console.WriteLine($"Complex 2: {c2}");
Console.WriteLine($"Sum: {sum}");
Console.WriteLine($"Product: {product}");
Console.WriteLine($"Negated: {negated}");
Console.WriteLine($"Conjugate: {conjugate}");
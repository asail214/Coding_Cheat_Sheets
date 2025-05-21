// Arithmetic Operators
int a = 10, b = 3;
int sum = a + b;        // Addition (13)
int diff = a - b;       // Subtraction (7)
int product = a * b;    // Multiplication (30)
int quotient = a / b;   // Division (3) - note: integer division
int remainder = a % b;  // Modulus (1) - remainder after division

// Division behavior with different types
double result = a / (double)b;  // 3.33333... (float division)

// Compound assignment operators
int x = 5;
x += 3;  // Same as: x = x + 3 (x becomes 8)
x -= 2;  // Same as: x = x - 2 (x becomes 6)
x *= 4;  // Same as: x = x * 4 (x becomes 24)
x /= 3;  // Same as: x = x / 3 (x becomes 8)
x %= 5;  // Same as: x = x % 5 (x becomes 3)

// Increment and Decrement
int i = 1;
int j = ++i;  // Pre-increment: i becomes 2, then assigned to j (j = 2)
int k = i++;  // Post-increment: i's value assigned to k (k = 2), then i becomes 3

// Comparison Operators
bool isEqual = (a == b);       // Equal to (false)
bool notEqual = (a != b);      // Not equal to (true)
bool greater = (a > b);        // Greater than (true)
bool less = (a < b);           // Less than (false)
bool greaterEqual = (a >= b);  // Greater than or equal to (true)
bool lessEqual = (a <= b);     // Less than or equal to (false)

// Logical Operators
bool p = true, q = false;
bool andResult = p && q;   // Logical AND (false)
bool orResult = p || q;    // Logical OR (true)
bool notResult = !p;       // Logical NOT (false)

// Bitwise Operators
int bits1 = 5;  // 0101 in binary
int bits2 = 3;  // 0011 in binary

int bitwiseAnd = bits1 & bits2;   // Bitwise AND (0001 = 1)
int bitwiseOr = bits1 | bits2;    // Bitwise OR (0111 = 7)
int bitwiseXor = bits1 ^ bits2;   // Bitwise XOR (0110 = 6)
int bitwiseNot = ~bits1;          // Bitwise NOT (inverts all bits)
int leftShift = bits1 << 1;       // Left Shift (1010 = 10)
int rightShift = bits1 >> 1;      // Right Shift (0010 = 2)

// Ternary Operator (condition ? true_value : false_value)
int value = 7;
string result = (value % 2 == 0) ? "Even" : "Odd";  // "Odd"
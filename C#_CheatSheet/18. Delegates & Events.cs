// Delegates - type-safe function pointers
// Delegate declaration
public delegate void MessageHandler(string message);

// Method matching delegate signature
public static void DisplayMessage(string message)
{
    Console.WriteLine($"Message: {message}");
}

public static void LogMessage(string message)
{
    Console.WriteLine($"Log: {message} at {DateTime.Now}");
}

// Using delegates
public class DelegateExample
{
    public static void Run()
    {
        // Creating delegate instance
        MessageHandler handler = DisplayMessage;
        
        // Invoking delegate
        handler("Hello, World!");  // Calls DisplayMessage
        
        // Reassigning to a different method
        handler = LogMessage;
        handler("Testing delegates");  // Calls LogMessage
        
        // Multicast delegate (combining delegates)
        MessageHandler multiHandler = DisplayMessage;
        multiHandler += LogMessage;  // Adds LogMessage to invocation list
        
        // This will call both methods
        multiHandler("Multicast message");
        
        // Removing a method
        multiHandler -= DisplayMessage;
        multiHandler("Only logging now");  // Only calls LogMessage
    }
}

// Func, Action, and Predicate built-in delegates
public class BuiltInDelegatesExample
{
    public static void Run()
    {
        // Action - delegate with void return type (0-16 parameters)
        Action<string> printAction = message => Console.WriteLine(message);
        printAction("Using Action delegate");
        
        // Action with multiple parameters
        Action<string, int> repeatAction = (text, count) => {
            for (int i = 0; i < count; i++)
                Console.WriteLine(text);
        };
        repeatAction("Repeat", 3);
        
        // Func - delegate that returns a value (0-16 parameters)
        Func<int, int, int> add = (a, b) => a + b;
        int result = add(5, 3);  // 8
        
        Func<string, int> getLength = s => s.Length;
        int length = getLength("Hello");  // 5
        
        // Predicate - delegate that returns bool (exactly 1 parameter)
        Predicate<int> isEven = num => num % 2 == 0;
        bool evenCheck = isEven(4);  // true
        
        // Using delegates with LINQ
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        // Using Func with Where
        IEnumerable<int> evenNumbers = numbers.Where(n => isEven(n));
        
        // Using Func with Select
        IEnumerable<string> numberStrings = numbers.Select(n => $"Number: {n}");
    }
}

// Anonymous methods and lambda expressions
public class LambdaExample
{
    public static void Run()
    {
        // Anonymous method (older syntax)
        MessageHandler anonymousHandler = delegate(string message)
        {
            Console.WriteLine($"Anonymous: {message}");
        };
        
        // Lambda expression (modern, concise syntax)
        MessageHandler lambdaHandler = (message) => 
        {
            Console.WriteLine($"Lambda: {message}");
        };
        
        // Even more concise with single parameter
        MessageHandler shortLambda = msg => Console.WriteLine($"Short lambda: {msg}");
        
        anonymousHandler("Testing anonymous method");
        lambdaHandler("Testing lambda expression");
        shortLambda("Testing short lambda");
    }
}

// Events - publisher/subscriber model based on delegates
public class Publisher
{
    // Declare the event using a delegate
    public event EventHandler<string> MessagePublished;
    
    // Event with custom EventArgs
    public event EventHandler<MessageEventArgs> DetailedMessagePublished;
    
    // Method to trigger the event
    public void PublishMessage(string message)
    {
        // Check if there are any subscribers
        MessagePublished?.Invoke(this, message);
        
        // Trigger the event with custom EventArgs
        DetailedMessagePublished?.Invoke(
            this, 
            new MessageEventArgs { Message = message, Timestamp = DateTime.Now }
        );
    }
}

// Custom EventArgs class
public class MessageEventArgs : EventArgs
{
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
}

// Subscriber class
public class Subscriber
{
    private string name;
    
    public Subscriber(string name)
    {
        this.name = name;
    }
    
    // Method that will handle the event
    public void OnMessageReceived(object sender, string message)
    {
        Console.WriteLine($"{name} received: {message}");
    }
    
    // Method that handles the detailed event
    public void OnDetailedMessageReceived(object sender, MessageEventArgs e)
    {
        Console.WriteLine($"{name} received '{e.Message}' at {e.Timestamp}");
    }
}

// Using publisher-subscriber with events
public class EventExample
{
    public static void Run()
    {
        // Create publisher and subscribers
        Publisher publisher = new Publisher();
        Subscriber sub1 = new Subscriber("Subscriber 1");
        Subscriber sub2 = new Subscriber("Subscriber 2");
        
        // Subscribe to events
        publisher.MessagePublished += sub1.OnMessageReceived;
        publisher.MessagePublished += sub2.OnMessageReceived;
        publisher.DetailedMessagePublished += sub1.OnDetailedMessageReceived;
        
        // Publish message - both subscribers will receive it
        publisher.PublishMessage("Hello, subscribers!");
        
        // Unsubscribe sub2
        publisher.MessagePublished -= sub2.OnMessageReceived;
        
        // Publish again - only sub1 receives it
        publisher.PublishMessage("This is for remaining subscribers");
    }
}

// Creating a custom event handler
public delegate void TemperatureChangedEventHandler(object sender, TemperatureEventArgs e);

public class TemperatureEventArgs : EventArgs
{
    public double NewTemperature { get; set; }
    public double OldTemperature { get; set; }
}

public class Thermostat
{
    private double currentTemperature;
    
    // Custom event
    public event TemperatureChangedEventHandler TemperatureChanged;
    
    // Property with event trigger
    public double CurrentTemperature
    {
        get { return currentTemperature; }
        set
        {
            double oldTemperature = currentTemperature;
            currentTemperature = value;
            
            // Trigger event if temperature changed
            if (oldTemperature != currentTemperature)
            {
                OnTemperatureChanged(oldTemperature, currentTemperature);
            }
        }
    }
    
    // Method to raise the event
    protected virtual void OnTemperatureChanged(double oldTemperature, double newTemperature)
    {
        // Check if there are subscribers
        if (TemperatureChanged != null)
        {
            TemperatureEventArgs args = new TemperatureEventArgs
            {
                OldTemperature = oldTemperature,
                NewTemperature = newTemperature
            };
            
            TemperatureChanged(this, args);
        }
    }
}

// Usage of custom events
public class TemperatureMonitor
{
    public void Subscribe(Thermostat thermostat)
    {
        thermostat.TemperatureChanged += OnTemperatureChanged;
    }
    
    public void Unsubscribe(Thermostat thermostat)
    {
        thermostat.TemperatureChanged -= OnTemperatureChanged;
    }
    
    private void OnTemperatureChanged(object sender, TemperatureEventArgs e)
    {
        Console.WriteLine($"Temperature changed from {e.OldTemperature}°C to {e.NewTemperature}°C");
        
        if (e.NewTemperature > 30)
        {
            Console.WriteLine("Warning: Temperature is too high!");
        }
    }
}
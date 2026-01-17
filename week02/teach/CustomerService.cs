/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Tried to serve a new customer  
        // Expected Result: The serviceCustomer method should display the customer that was added and then remove it from the queue
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(4);
        cs1.AddNewCustomer();
        cs1.ServeCustomer();

        // Defect(s) Found: The serveCustomer method removes the customer before actually getting it 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Adding customers to the queue
        // Expected Result: The customer should be added to the queue
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(4);
        cs2.AddNewCustomer();
        Console.WriteLine(cs2);

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: Trying to add more customers than the max size
        // Expected Result: An error message will be displayed.
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(4);
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();

        // Defect(s) Found: The max size check in AddNewCustomer should be >= instead of >
        Console.WriteLine("=================");

        // Test 4
        // Scenario: Serving a customer when there are no customers in the queue
        // Expected Result: An error message will be displayed.
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(4);
        cs4.ServeCustomer();

        // Defect(s) Found: Need to check the length of the queue before serving a customer
        Console.WriteLine("=================");

        //Test 5
        // Scenario: If the max size is set to 0 or negative, it should default to 10
        // Expected Result: The max size should be set to 10
        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(0);
        Console.WriteLine(cs5);

        // Defect(s) Found: None


    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        var customer = _queue[0];
        _queue.RemoveAt(0);
        
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
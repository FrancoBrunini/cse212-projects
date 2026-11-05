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
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 1");
//var cs = new CustomerService(-10);
//Console.WriteLine(cs);
        // Defect(s) Found:  the constructor worked well

        Console.WriteLine("=================");
        Console.WriteLine("Test 2");

      //  var cs2 = new CustomerService(2);
        // simulate the lines
       //  cs2.AddNewCustomer(); // Customer 1
       // cs2.AddNewCustomer(); // Customer 2
       // cs2.AddNewCustomer(); // Customer 3 (should not be added)
     //   Console.WriteLine(cs2);
        //Defect(s) Found: in if (_queue.Count > _maxSize) it was missing the >=, so It can stop there



        Console.WriteLine("=================");
        Console.WriteLine("Test 3");
        // Scenario: it should display the first customer in the queue and then remove it from the queue
        // Expected Result: it should display the information for the first customer in the queue and then remove it from the queue
//var cs3 = new CustomerService(5);
//cs3.AddNewCustomer();
///cs3.AddNewCustomer();
//cs3.ServeCustomer();
// Scenario: we are gonna create a new customer service queue and add 2 customers to it, then we are gonna serve the first customer in the queue and then display the information for the first customer in the queue and then remove it from the queue
// Expected Result: it should appear the information before elmitating
// Defect(s) Found:  it eliminates the first customer in the queue but it doesn't display the information for the first customer in the queue before eliminating it, so I added a line to display the information for the first customer in the queue before eliminating it

        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(5);
        cs4.ServeCustomer();
        // Scenario: we are gonna create a new customer service queue without customers
        // expected Result: it should appear an error message
        // Defect(s) Found:  it doesn't display an error message when the queue is empty, so I added a line to display an error message when the queue is empty



        // Add more Test Cases As Needed Below
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
        if (_queue.Count >= _maxSize) {
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
        if (_queue.Count <= 0) {
            Console.WriteLine("No Customers in Queue.");
            return;
        }
        var customer = _queue[0];
        Console.WriteLine(customer);
         _queue.RemoveAt(0);

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
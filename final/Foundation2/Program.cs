using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L123", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25.99m, 2));

        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "MN789", 199.99m, 1));
        order2.AddProduct(new Product("Keyboard", "K012", 49.99m, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine($"Order for {order.GetShippingLabel()}");
            Console.WriteLine($"Total Cost: {order.CalculateTotalCost()}");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
        }
    }
}

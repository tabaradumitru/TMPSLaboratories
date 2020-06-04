using System;
using PrototypeDecoratorChainOfResponsibility.OrderSaver;

namespace PrototypeDecoratorChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            
            order.AddLine(new OrderLine("507125-B21", 1, 10, 7));
            order.AddLine(new OrderLine("507127-B21", 5, 123, 110));
            order.AddLine(new OrderLine("12239-B21", 14, 85, 67));

            order.CustomerName = "Ingram Micro";
            order.OrderDate = DateTime.Now;
            order.ShippingAddress = new Address
            (
                "Tech Data Drop Ship", 
                "Tech Data Sales Management, Inc.", 
                "5350 Tech Data Drive",
                "Clearwater",
                "USA",
                "33760"
            );
            
            order.PrintOrder();
            
            Order clone = order.CloneOrder();
            clone.PrintOrder();

            order.Lines[0].QuantityOrdered = 999;
            order.CustomerName = "John Doe";
            order.ShippingAddress.Name = "California";
            
            Console.WriteLine("After Edit:");
            order.PrintOrder();
            
            Console.WriteLine("\n");
            clone.PrintOrder();

            order.CustomerName = "";
            
            CDSOrderSaverDecorator cdsOrderSaver = new CDSOrderSaverDecorator(order);

            var saveResult = cdsOrderSaver.Save();
        }
    }
}
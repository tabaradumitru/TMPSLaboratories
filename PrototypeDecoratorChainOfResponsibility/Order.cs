using System;
using System.Collections.Generic;
using System.Linq;

namespace PrototypeDecoratorChainOfResponsibility
{
    public class Order : CloneableOrder
    {
        public string OrderNumber;
        public string CustomerName;
        public DateTime OrderDate;
        public Address ShippingAddress;
        public List<OrderLine> Lines = new List<OrderLine>();

        public Order()
        {
            OrderNumber = GetOrderNumber();
        }

        public Order CloneOrder()
        {
            Order clone = (Order) MemberwiseClone();
            clone.OrderNumber = GetOrderNumber();
            clone.ShippingAddress = ShippingAddress.Clone();
            clone.Lines = new List<OrderLine>();
            foreach (var line in Lines.ToList())
            {
                clone.AddLine(line.Clone());
            }

            return clone;
        }

        private string GetOrderNumber()
        {
            return $"SO-{Guid.NewGuid()}";
        }

        public void AddLine(OrderLine line)
        {
            line.Number = Lines.Count + 1;
            Lines.Add(line);
        }

        public void PrintOrder()
        {
            Console.WriteLine
            (
                $"Order Number: {OrderNumber}\n" +
                $"Customer Name: {CustomerName}\n" +
                $"Order Date: {OrderDate}"
            );

            foreach (var line in Lines)
            {
                Console.WriteLine
                (
                    $"Line {line.Number}: " +
                    $"Part Number: {line.PartNumber} | " +
                    $"Quantity: {line.QuantityOrdered} | " +
                    $"Unit Price: {line.UnitPrice} | " +
                    $"Unit Cost: {line.UnitCost}"
                );
            }
            
            Console.WriteLine
            (
                $"Address:\n" +
                $"\t{ShippingAddress.Name}\n" +
                $"\t{ShippingAddress.Line1}\n" +
                $"\t{ShippingAddress.Line2}\n" +
                $"\t{ShippingAddress.City}\n" +
                $"\t{ShippingAddress.Country}\n" +
                $"\t{ShippingAddress.PostalCode}\n"    
            );
        }

        public void Save()
        {
            Console.WriteLine("Saved Order");
        }
    }
}
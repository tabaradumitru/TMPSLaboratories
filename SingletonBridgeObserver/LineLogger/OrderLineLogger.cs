using System;

namespace SingletonBridgeObserver.LineLogger
{
    public class OrderLineLogger : IOrderLineObserver
    {
        public void Update(OrderLine subject)
        {
            Console.WriteLine
            (
                $"Order Line Created -> " +
                $"Part Number: {subject.PartNumber};  " +
                $"Quantity: {subject.QuantityOrdered}; " +
                $"Unit Price: {subject.UnitPrice}" +
                $"Unit Cost: {subject.UnitCost}"
            );
        }
    }
}
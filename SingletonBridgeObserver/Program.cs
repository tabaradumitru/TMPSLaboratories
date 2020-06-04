using System;
using SingletonBridgeObserver.AmazonEnums;
using SingletonBridgeObserver.LineLogger;
using SingletonBridgeObserver.OrderCalculator;
using SingletonBridgeObserver.OrderNumberGenerator;

namespace SingletonBridgeObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a singleton to get the next database identifier for orders
            var orderNumberSingleton = OrderNumberSingleton.GetInstance();
            
            // LineLogger is part of the Observer pattern
            var lineLogger = new OrderLineLogger();

            
            var amazonOrder = new AmazonOrder((int)AmazonStores.RackIT, "Unshipped", true);
            amazonOrder.OrderNumber = orderNumberSingleton.GetNextAmazonOrderNumber(amazonOrder.Store, amazonOrder.IsPrime);
            amazonOrder.SetOrderCalculator(new AmazonOrderCalculator());
            amazonOrder.AddSubscriber(lineLogger);

            Console.WriteLine("\nAmazon Order Number: " + amazonOrder.OrderNumber);
            amazonOrder.AddLine(new OrderLine("507125-B21", 2, 50, 30));
            amazonOrder.AddLine(new OrderLine("40A20090US", 2, 431, 400));

            Console.WriteLine("Total Commission: " + amazonOrder.GetTotalCommission());
            Console.WriteLine("Total Profit: " + amazonOrder.GetTotalProfit());
            Console.WriteLine("\n");


            var ingramOrder = new IngramOrder("FedEx Ground", "DIST");
            ingramOrder.OrderNumber = orderNumberSingleton.GetNextIngramOrderNumber();
            ingramOrder.SetOrderCalculator(new IngramOrderCalculator());
            ingramOrder.AddSubscriber(lineLogger);

            Console.WriteLine("Ingram Order Number: " + ingramOrder.OrderNumber);
            ingramOrder.AddLine(new OrderLine("192186-001-RF", 20, 123, 105));
            ingramOrder.AddLine(new OrderLine("300588-002", 4, 1230, 1180));

            Console.WriteLine("Total Commission: " + ingramOrder.GetTotalCommission());
            Console.WriteLine("Total Profit: " + ingramOrder.GetTotalProfit());
        }
    }
}
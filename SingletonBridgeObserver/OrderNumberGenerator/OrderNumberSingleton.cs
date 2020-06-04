using System;
using SingletonBridgeObserver.AmazonEnums;

namespace SingletonBridgeObserver.OrderNumberGenerator
{
    public class OrderNumberSingleton
    {
        private OrderNumberSingleton() {}

        private static OrderNumberSingleton _instance;
        
        private static readonly object _lock = new object();

        public static OrderNumberSingleton GetInstance()
        {
            if (_instance != null) return _instance;
            
            lock (_lock)
            {
                _instance ??= new OrderNumberSingleton();
            }

            return _instance;
        }

        public string GetNextAmazonOrderNumber(int source, bool isPrime)
        {
            var guid = Guid.NewGuid();
            
            var orderNumber = source switch
            {
                1 => "RK",
                2 => "OC",
                3 => "PD",
                _ => ""
            };

            if (string.IsNullOrWhiteSpace(orderNumber)) return null;

            orderNumber += isPrime ? "P" : "";

            return $"{orderNumber}-{guid}";
        }

        public string GetNextIngramOrderNumber()
        {
            var guid = Guid.NewGuid();

            return $"IN-{guid}";
        }
    }
}
namespace SingletonBridgeObserver
{
    public class AmazonOrder : Order
    {
        public AmazonOrder(int store, string orderStatus, bool isPrime)
        {
            Store = store;
            OrderStatus = orderStatus;
            IsPrime = isPrime;
        }

        public int Store { get; set; }
        public string OrderStatus { get; set; }
        public bool IsPrime { get; set; }
    }
}
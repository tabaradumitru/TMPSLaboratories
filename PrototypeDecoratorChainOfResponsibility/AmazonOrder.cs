namespace PrototypeDecoratorChainOfResponsibility
{
    public class AmazonOrder : Order
    {
        public AmazonOrder(int store, int fChannel, string orderStatus, bool isPrime)
        {
            Store = store;
            FChannel = fChannel;
            OrderStatus = orderStatus;
            IsPrime = isPrime;
        }

        public int Store { get; set; }
        public int FChannel { get; set; }
        public string OrderStatus { get; set; }
        public bool IsPrime { get; set; }

        public Order CloneOrder()
        {
            AmazonOrder clone = (AmazonOrder)base.CloneOrder();

            clone.Store = Store;
            clone.FChannel = FChannel;
            clone.OrderStatus = OrderStatus;
            clone.IsPrime = IsPrime;

            return clone;
        }
    }
}
namespace SingletonBridgeObserver.LineLogger
{
    public interface IOrderLineSubject
    {
        void AddSubscriber(IOrderLineObserver observer);
        void DetachSubscriber(IOrderLineObserver observer);
        void Notify(OrderLine line);
    }
}
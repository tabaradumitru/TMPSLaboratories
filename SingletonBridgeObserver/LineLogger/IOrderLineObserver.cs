namespace SingletonBridgeObserver.LineLogger
{
    public interface IOrderLineObserver
    {
        void Update(OrderLine subject);
    }
}
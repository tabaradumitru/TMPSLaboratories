namespace SingletonBridgeObserver.OrderCalculator
{
    public interface IOrderCalculator
    {
        public abstract decimal CalculateTotalCommission(Order order);
        public abstract decimal CalculateTotalProfit(Order order);
    }
}
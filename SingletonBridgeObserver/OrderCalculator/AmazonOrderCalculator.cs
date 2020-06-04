using System.Linq;

namespace SingletonBridgeObserver.OrderCalculator
{
    public class AmazonOrderCalculator : IOrderCalculator
    {
        public decimal CalculateTotalCommission(Order order)
        {
            return order.Lines
                .Select(line => line.QuantityOrdered * line.UnitPrice)
                .Select(extPrice => extPrice * 8 / 100)
                .Sum();
        }

        public decimal CalculateTotalProfit(Order order)
        {
            return order.Lines
                .Select(line => line.QuantityOrdered * line.UnitPrice - line.QuantityOrdered * line.UnitCost)
                .Sum() - CalculateTotalCommission(order);
        }
    }
}
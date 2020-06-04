using System.Linq;

namespace SingletonBridgeObserver.OrderCalculator
{
    public class IngramOrderCalculator : IOrderCalculator
    {
        public decimal CalculateTotalCommission(Order order)
        {
            return order.Lines
                .Select(line => line.QuantityOrdered * line.UnitPrice)
                .Select(extPrice => extPrice * 5 / 100)
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
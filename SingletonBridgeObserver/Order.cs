using System.Collections.Generic;
using SingletonBridgeObserver.LineLogger;
using SingletonBridgeObserver.OrderCalculator;

namespace SingletonBridgeObserver
{
    public abstract class Order : IOrderLineSubject
    {
        public string OrderNumber { get; set; }
        public List<OrderLine> Lines = new List<OrderLine>();
        
        private List<IOrderLineObserver> _observers = new List<IOrderLineObserver>();
        protected IOrderCalculator _orderCalculator;

        public Order()
        {
        }

        public Order(IOrderCalculator orderCalculator)
        {
            _orderCalculator = orderCalculator;
        }

        public void AddLine(OrderLine line)
        {
            Lines.Add(line);
            Notify(line);
        }
        
        public void AddSubscriber(IOrderLineObserver observer)
        {
            _observers.Add(observer);
        }

        public void DetachSubscriber(IOrderLineObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(OrderLine line)
        {
            foreach (var observer in _observers)
            {
                observer.Update(line);
            }
        }

        public void SetOrderCalculator(IOrderCalculator orderCalculator)
        {
            _orderCalculator = orderCalculator;
        }

        public decimal GetTotalCommission()
        {
            return _orderCalculator.CalculateTotalCommission(this);
        }

        public decimal GetTotalProfit()
        {
            return _orderCalculator.CalculateTotalProfit(this);
        }
    }
}
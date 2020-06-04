namespace PrototypeDecoratorChainOfResponsibility.OrderSaver
{
    public abstract class OrderSaverDecorator : Order
    {
        protected Order _order;

        public OrderSaverDecorator(Order order)
        {
            _order = order;
        }

        public abstract bool Save();
    }
}
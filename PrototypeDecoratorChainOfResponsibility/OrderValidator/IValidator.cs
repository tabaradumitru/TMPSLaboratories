namespace PrototypeDecoratorChainOfResponsibility.OrderValidator
{
    public interface IValidator
    {
        IValidator SetNext(IValidator validator);
        object Validate(Order request);
    }
}
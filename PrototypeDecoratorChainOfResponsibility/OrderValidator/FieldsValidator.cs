namespace PrototypeDecoratorChainOfResponsibility.OrderValidator
{
    public class FieldsValidator : Validator
    {
        public override object Validate(Order request)
        {
            if (string.IsNullOrWhiteSpace(request.CustomerName))
            {
                return "Order's Customer Name is not valid!";
            }

            return string.IsNullOrWhiteSpace(request.OrderNumber) 
                ? "Order's Number is not valid!" 
                : base.Validate(request);
        }
    }
}
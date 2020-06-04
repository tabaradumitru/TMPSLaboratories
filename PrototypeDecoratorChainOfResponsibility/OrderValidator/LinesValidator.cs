using System.Linq;

namespace PrototypeDecoratorChainOfResponsibility.OrderValidator
{
    public class LinesValidator : Validator
    {
        public override object Validate(Order request)
        {
            
            if (request.Lines == null || request.Lines.Count == 0)
            {
                return "Order must have at least one line";
            }
            
            if (request.Lines.Any(l => l.UnitPrice == 0))
            {
                return "Order Line's Unit Price can't be 0";
            }

            if (request.Lines.Any(l => l.QuantityOrdered < 0))
            {
                return "Order Line's Quantity can't be negative";
            }
            return base.Validate(request);
        }
    }
}
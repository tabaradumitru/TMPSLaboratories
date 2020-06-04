using System;
using PrototypeDecoratorChainOfResponsibility.OrderValidator;

namespace PrototypeDecoratorChainOfResponsibility.OrderSaver
{
    public class CDSOrderSaverDecorator : OrderSaverDecorator
    {
        public CDSOrderSaverDecorator(Order order) : base(order)
        {
        }
        
        public override bool Save()
        {
            var fieldsValidator = new FieldsValidator();
            var linesValidator = new LinesValidator();

            fieldsValidator.SetNext(linesValidator);

            var validateResult = fieldsValidator.Validate(_order);

            if (validateResult == null)
            {
                Console.WriteLine("Order saved successfully!");
                
                return true;
            }
            
            Console.WriteLine($"Validation Error: {validateResult}");
            
            return false;
        }
    }
}
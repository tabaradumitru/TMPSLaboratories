using System;
using PrototypeDecoratorChainOfResponsibility.OrderValidator;

namespace PrototypeDecoratorChainOfResponsibility.OrderSaver
{
    public class MASOrderSaverDecorator : OrderSaverDecorator
    {
        public MASOrderSaverDecorator(Order order) : base(order)
        {
        }

        public override bool Save()
        {
            var fieldsValidator = new FieldsValidator();

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
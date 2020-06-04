namespace PrototypeDecoratorChainOfResponsibility.OrderValidator
{
    public abstract class Validator : IValidator
    {
        private IValidator _nextValidator;

        public IValidator SetNext(IValidator validator)
        {
            _nextValidator = validator;

            return validator;
        }

        public virtual object Validate(Order request)
        {
            return _nextValidator?.Validate(request);
        }
    }
}
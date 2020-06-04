namespace BuilderCompositeVisitor.Builder
{
    public class DepartmentDirector
    {
        private IDepartmentBuilder _builder;

        public IDepartmentBuilder Builder
        {
            set => _builder = value;
        }

        public void BuildSalesDepartment(string name, Employee manager, Address address)
        {
            _builder.SetDepartmentName(name);
            _builder.SetManager(manager);
            _builder.SetAddress(address);
        }
    }
}
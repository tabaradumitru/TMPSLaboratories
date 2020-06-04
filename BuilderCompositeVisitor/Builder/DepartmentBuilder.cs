namespace BuilderCompositeVisitor.Builder
{
    public class DepartmentBuilder : IDepartmentBuilder
    {
        private Department _department = new Department();

        public DepartmentBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _department = new Department();
        }

        public Department GetDepartment()
        {
            Department department = _department;

            Reset();

            return department;
        }

        public void SetManager(Employee manager)
        {
            _department.Manager = manager;
        }

        public void SetAddress(Address address)
        {
            _department.Address = address;
        }

        public void SetDepartmentName(string name)
        {
            _department.DepartmentName = name;
        }
    }
}
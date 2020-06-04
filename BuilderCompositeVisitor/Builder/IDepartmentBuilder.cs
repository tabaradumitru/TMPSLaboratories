namespace BuilderCompositeVisitor.Builder
{
    public interface IDepartmentBuilder
    {
        void Reset();
        Department GetDepartment();
        void SetManager(Employee manager);
        void SetAddress(Address address);
        void SetDepartmentName(string name);
    }
}